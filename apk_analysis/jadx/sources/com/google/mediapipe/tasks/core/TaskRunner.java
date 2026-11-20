package com.google.mediapipe.tasks.core;

import android.content.Context;
import android.util.Log;
import com.google.mediapipe.framework.AndroidAssetUtil;
import com.google.mediapipe.framework.AndroidPacketCreator;
import com.google.mediapipe.framework.Graph;
import com.google.mediapipe.framework.MediaPipeException;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.PacketListCallback;
import com.google.mediapipe.proto.CalculatorProto;
import com.google.mediapipe.tasks.core.logging.TasksStatsLogger;
import com.google.mediapipe.tasks.core.logging.TasksStatsLoggerFactory;
import java.util.List;
import java.util.Map;
import java.util.concurrent.atomic.AtomicBoolean;

/* JADX INFO: loaded from: classes3.dex */
public class TaskRunner implements AutoCloseable {
    private static final String TAG = "TaskRunner";
    private static final long TIMESATMP_UNITS_PER_SECOND = 1000000;
    private ErrorListener errorListener;
    private final Graph graph;
    private final AtomicBoolean graphStarted;
    private long lastSeenTimestamp;
    private final ModelResourcesCache modelResourcesCache;
    private final OutputHandler<? extends TaskResult, ?> outputHandler;
    private final AndroidPacketCreator packetCreator;
    private final TasksStatsLogger statsLogger;

    public static TaskRunner create(Context context, TaskInfo<? extends TaskOptions> taskInfo, final OutputHandler<? extends TaskResult, ?> outputHandler) throws Throwable {
        final TasksStatsLogger tasksStatsLoggerCreate = TasksStatsLoggerFactory.create(context, taskInfo.taskName(), taskInfo.taskRunningModeName());
        AndroidAssetUtil.initializeNativeAssetManager(context);
        Graph graph = new Graph();
        graph.loadBinaryGraph(taskInfo.generateGraphConfig());
        ModelResourcesCache modelResourcesCache = new ModelResourcesCache();
        graph.setServiceObject(new ModelResourcesCacheService(), modelResourcesCache);
        graph.addMultiStreamCallback(taskInfo.outputStreamNames(), new PacketListCallback() { // from class: com.google.mediapipe.tasks.core.TaskRunner$$ExternalSyntheticLambda0
            @Override // com.google.mediapipe.framework.PacketListCallback
            public final void process(List list) {
                TaskRunner.$r8$lambda$uV5eJ0E2p93kwD73qbTBFaFAplg(outputHandler, tasksStatsLoggerCreate, list);
            }
        }, outputHandler.handleTimestampBoundChanges());
        graph.startRunningGraph();
        graph.waitUntilGraphIdle();
        return new TaskRunner(graph, modelResourcesCache, outputHandler, tasksStatsLoggerCreate);
    }

    public static /* synthetic */ void $r8$lambda$uV5eJ0E2p93kwD73qbTBFaFAplg(OutputHandler outputHandler, TasksStatsLogger tasksStatsLogger, List list) {
        outputHandler.run(list);
        tasksStatsLogger.recordInvocationEnd(((Packet) list.get(0)).getTimestamp());
    }

    public void setErrorListener(ErrorListener errorListener) {
        this.errorListener = errorListener;
    }

    public AndroidPacketCreator getPacketCreator() {
        return this.packetCreator;
    }

    public synchronized TaskResult process(Map<String, Packet> map) {
        long jGenerateSyntheticTimestamp = generateSyntheticTimestamp();
        this.statsLogger.recordCpuInputArrival(jGenerateSyntheticTimestamp);
        addPackets(map, jGenerateSyntheticTimestamp);
        this.graph.waitUntilGraphIdle();
        this.lastSeenTimestamp = this.outputHandler.getLatestOutputTimestamp();
        return this.outputHandler.retrieveCachedTaskResult();
    }

    public synchronized TaskResult process(Map<String, Packet> map, long j) {
        validateInputTimstamp(j);
        this.statsLogger.recordCpuInputArrival(j);
        addPackets(map, j);
        this.graph.waitUntilGraphIdle();
        return this.outputHandler.retrieveCachedTaskResult();
    }

    public synchronized void send(Map<String, Packet> map, long j) {
        validateInputTimstamp(j);
        this.statsLogger.recordCpuInputArrival(j);
        addPackets(map, j);
    }

    public void restart() throws Throwable {
        if (this.graphStarted.get()) {
            try {
                this.graphStarted.set(false);
                this.graph.closeAllPacketSources();
                this.graph.waitUntilGraphDone();
                this.statsLogger.logSessionEnd();
            } catch (MediaPipeException e) {
                reportError(e);
            }
        }
        try {
            this.graph.startRunningGraph();
            this.graph.waitUntilGraphIdle();
            this.graphStarted.set(true);
            this.statsLogger.logSessionStart();
        } catch (MediaPipeException e2) {
            reportError(e2);
        }
    }

    @Override // java.lang.AutoCloseable
    public void close() {
        if (this.graphStarted.get()) {
            try {
                this.graphStarted.set(false);
                this.graph.closeAllPacketSources();
                this.graph.waitUntilGraphDone();
                this.statsLogger.logSessionEnd();
                ModelResourcesCache modelResourcesCache = this.modelResourcesCache;
                if (modelResourcesCache != null) {
                    modelResourcesCache.release();
                }
            } catch (MediaPipeException e) {
                reportError(e);
            }
            try {
                this.graph.tearDown();
            } catch (MediaPipeException e2) {
                reportError(e2);
            }
        }
    }

    public CalculatorProto.CalculatorGraphConfig getCalculatorGraphConfig() {
        return this.graph.getCalculatorGraphConfig();
    }

    private synchronized void addPackets(Map<String, Packet> map, long j) {
        if (!this.graphStarted.get()) {
            reportError(new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "The task graph hasn't been successfully started or error occurs during graph initializaton."));
        }
        try {
            try {
                for (Map.Entry<String, Packet> entry : map.entrySet()) {
                    this.graph.addConsumablePacketToInputStream(entry.getKey(), entry.getValue(), j);
                    entry.setValue(null);
                }
                for (Packet packet : map.values()) {
                    if (packet != null) {
                        packet.release();
                    }
                }
            } catch (MediaPipeException e) {
                if (this.errorListener == null) {
                    Log.e(TAG, "Mediapipe error: ", e);
                    for (Packet packet2 : map.values()) {
                        if (packet2 != null) {
                            packet2.release();
                        }
                    }
                } else {
                    throw e;
                }
            }
        } catch (Throwable th) {
            for (Packet packet3 : map.values()) {
                if (packet3 != null) {
                    packet3.release();
                }
            }
            throw th;
        }
    }

    private void validateInputTimstamp(long j) {
        if (this.lastSeenTimestamp >= j) {
            reportError(new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "The received packets having a smaller timestamp than the processed timestamp."));
        }
        this.lastSeenTimestamp = j;
    }

    private long generateSyntheticTimestamp() {
        long j = this.lastSeenTimestamp;
        long j2 = j == Long.MIN_VALUE ? 0L : j + TIMESATMP_UNITS_PER_SECOND;
        this.lastSeenTimestamp = j2;
        return j2;
    }

    private TaskRunner(Graph graph, ModelResourcesCache modelResourcesCache, OutputHandler<? extends TaskResult, ?> outputHandler, TasksStatsLogger tasksStatsLogger) {
        AtomicBoolean atomicBoolean = new AtomicBoolean(false);
        this.graphStarted = atomicBoolean;
        this.lastSeenTimestamp = Long.MIN_VALUE;
        this.outputHandler = outputHandler;
        this.graph = graph;
        this.modelResourcesCache = modelResourcesCache;
        this.packetCreator = new AndroidPacketCreator(graph);
        this.statsLogger = tasksStatsLogger;
        atomicBoolean.set(true);
        tasksStatsLogger.logSessionStart();
    }

    private void reportError(MediaPipeException mediaPipeException) {
        ErrorListener errorListener = this.errorListener;
        if (errorListener != null) {
            errorListener.onError(mediaPipeException);
            return;
        }
        throw mediaPipeException;
    }
}
