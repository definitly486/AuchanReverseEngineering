package com.google.mediapipe.tasks.vision.objectdetector;

import android.content.Context;
import android.os.ParcelFileDescriptor;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.DetectionProto;
import com.google.mediapipe.framework.AndroidPacketGetter;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.PacketGetter;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.core.TaskInfo;
import com.google.mediapipe.tasks.core.TaskOptions;
import com.google.mediapipe.tasks.core.TaskResult;
import com.google.mediapipe.tasks.core.TaskRunner;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.mediapipe.tasks.vision.core.BaseVisionTaskApi;
import com.google.mediapipe.tasks.vision.core.ImageProcessingOptions;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import com.google.mediapipe.tasks.vision.facedetector.FaceDetector$$ExternalSyntheticLambda0;
import com.google.mediapipe.tasks.vision.facedetector.FaceDetector$$ExternalSyntheticLambda1;
import com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto;
import java.io.File;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Objects;
import java.util.Optional;
import java.util.function.Consumer;

/* JADX INFO: loaded from: classes3.dex */
public final class ObjectDetector extends BaseVisionTaskApi {
    private static final int DETECTIONS_OUT_STREAM_INDEX = 0;
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final int IMAGE_OUT_STREAM_INDEX = 1;
    private static final String NORM_RECT_IN_STREAM_NAME = "norm_rect_in";
    private static final String TAG = "ObjectDetector";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.ObjectDetectorGraph";
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in", "NORM_RECT:norm_rect_in"));
    private static final List<String> OUTPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("DETECTIONS:detections_out", "IMAGE:image_out"));

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
    }

    public static ObjectDetector createFromFile(Context context, String str) {
        return createFromOptions(context, ObjectDetectorOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetPath(str).build()).build());
    }

    public static ObjectDetector createFromFile(Context context, File file) throws IOException {
        ParcelFileDescriptor parcelFileDescriptorOpen = ParcelFileDescriptor.open(file, 268435456);
        try {
            ObjectDetector objectDetectorCreateFromOptions = createFromOptions(context, ObjectDetectorOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetFileDescriptor(Integer.valueOf(parcelFileDescriptorOpen.getFd())).build()).build());
            parcelFileDescriptorOpen.close();
            return objectDetectorCreateFromOptions;
        } catch (Throwable th) {
            if (parcelFileDescriptorOpen != null) {
                try {
                    parcelFileDescriptorOpen.close();
                } catch (Throwable th2) {
                    th.addSuppressed(th2);
                }
            }
            throw th;
        }
    }

    public static ObjectDetector createFromBuffer(Context context, ByteBuffer byteBuffer) {
        return createFromOptions(context, ObjectDetectorOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetBuffer(byteBuffer).build()).build());
    }

    public static ObjectDetector createFromOptions(Context context, final ObjectDetectorOptions objectDetectorOptions) {
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<ObjectDetectorResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public ObjectDetectorResult convertToTaskResult(List<Packet> list) {
                if (list.get(0).isEmpty()) {
                    return ObjectDetectorResult.create((List<DetectionProto.Detection>) new ArrayList(), BaseVisionTaskApi.generateResultTimestampMs(objectDetectorOptions.runningMode(), list.get(0)));
                }
                return ObjectDetectorResult.create((List<DetectionProto.Detection>) PacketGetter.getProtoVector(list.get(0), DetectionProto.Detection.parser()), BaseVisionTaskApi.generateResultTimestampMs(objectDetectorOptions.runningMode(), list.get(0)));
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(1))).build();
            }
        });
        objectDetectorOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        objectDetectorOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new ObjectDetector(TaskRunner.create(context, TaskInfo.builder().setTaskName(ObjectDetector.class.getSimpleName()).setTaskRunningModeName(objectDetectorOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(OUTPUT_STREAMS).setTaskOptions(objectDetectorOptions).setEnableFlowLimiting(objectDetectorOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), objectDetectorOptions.runningMode());
    }

    private ObjectDetector(TaskRunner taskRunner, RunningMode runningMode) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, NORM_RECT_IN_STREAM_NAME);
    }

    public ObjectDetectorResult detect(MPImage mPImage) {
        return detect(mPImage, ImageProcessingOptions.builder().build());
    }

    public ObjectDetectorResult detect(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (ObjectDetectorResult) processImageData(mPImage, imageProcessingOptions);
    }

    public ObjectDetectorResult detectForVideo(MPImage mPImage, long j) {
        return detectForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public ObjectDetectorResult detectForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (ObjectDetectorResult) processVideoData(mPImage, imageProcessingOptions, j);
    }

    public void detectAsync(MPImage mPImage, long j) {
        detectAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void detectAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        sendLiveStreamData(mPImage, imageProcessingOptions, j);
    }

    @AutoValue
    public static abstract class ObjectDetectorOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract List<String> categoryAllowlist();

        abstract List<String> categoryDenylist();

        abstract Optional<String> displayNamesLocale();

        abstract Optional<ErrorListener> errorListener();

        abstract Optional<Integer> maxResults();

        abstract Optional<OutputHandler.ResultListener<ObjectDetectorResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        abstract Optional<Float> scoreThreshold();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract ObjectDetectorOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setCategoryAllowlist(List<String> list);

            public abstract Builder setCategoryDenylist(List<String> list);

            public abstract Builder setDisplayNamesLocale(String str);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setMaxResults(Integer num);

            public abstract Builder setResultListener(OutputHandler.ResultListener<ObjectDetectorResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public abstract Builder setScoreThreshold(Float f);

            public final ObjectDetectorOptions build() {
                ObjectDetectorOptions objectDetectorOptionsAutoBuild = autoBuild();
                if (objectDetectorOptionsAutoBuild.runningMode() == RunningMode.LIVE_STREAM) {
                    if (!objectDetectorOptionsAutoBuild.resultListener().isPresent()) {
                        throw new IllegalArgumentException("The object detector is in the live stream mode, a user-defined result listener must be provided in ObjectDetectorOptions.");
                    }
                } else if (objectDetectorOptionsAutoBuild.resultListener().isPresent()) {
                    throw new IllegalArgumentException("The object detector is in the image or the video mode, a user-defined result listener shouldn't be provided in ObjectDetectorOptions.");
                }
                return objectDetectorOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            Builder runningMode = new AutoValue_ObjectDetector_ObjectDetectorOptions.Builder().setRunningMode(RunningMode.IMAGE);
            List<String> list = Collections.EMPTY_LIST;
            return runningMode.setCategoryAllowlist(list).setCategoryDenylist(list);
        }

        /* JADX WARN: Multi-variable type inference failed */
        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
            BaseOptionsProto.BaseOptions.Builder builderNewBuilder = BaseOptionsProto.BaseOptions.newBuilder();
            builderNewBuilder.setUseStreamMode(runningMode() != RunningMode.IMAGE);
            builderNewBuilder.mergeFrom(convertBaseOptionsToProto(baseOptions()));
            final ObjectDetectorOptionsProto.ObjectDetectorOptions.Builder baseOptions = ObjectDetectorOptionsProto.ObjectDetectorOptions.newBuilder().setBaseOptions(builderNewBuilder);
            Optional<String> optionalDisplayNamesLocale = displayNamesLocale();
            Objects.requireNonNull(baseOptions);
            optionalDisplayNamesLocale.ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector$ObjectDetectorOptions$$ExternalSyntheticLambda0
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    baseOptions.setDisplayNamesLocale((String) obj);
                }
            });
            maxResults().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector$ObjectDetectorOptions$$ExternalSyntheticLambda1
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    baseOptions.setMaxResults(((Integer) obj).intValue());
                }
            });
            scoreThreshold().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.objectdetector.ObjectDetector$ObjectDetectorOptions$$ExternalSyntheticLambda2
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    baseOptions.setScoreThreshold(((Float) obj).floatValue());
                }
            });
            if (!categoryAllowlist().isEmpty()) {
                baseOptions.addAllCategoryAllowlist(categoryAllowlist());
            }
            if (!categoryDenylist().isEmpty()) {
                baseOptions.addAllCategoryDenylist(categoryDenylist());
            }
            return (CalculatorOptionsProto.CalculatorOptions) CalculatorOptionsProto.CalculatorOptions.newBuilder().setExtension(ObjectDetectorOptionsProto.ObjectDetectorOptions.ext, baseOptions.build()).build();
        }
    }

    private static void validateImageProcessingOptions(ImageProcessingOptions imageProcessingOptions) {
        if (imageProcessingOptions.regionOfInterest().isPresent()) {
            throw new IllegalArgumentException("ObjectDetector doesn't support region-of-interest.");
        }
    }
}
