package com.yandex.mapkit.offline_cache.internal;

import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import androidx.work.ForegroundInfo;
import androidx.work.ListenableWorker;
import androidx.work.Worker;
import androidx.work.WorkerParameters;
import java.util.logging.Logger;

/* JADX INFO: loaded from: classes3.dex */
public class BackgroundDownloadJob extends Worker implements BackgroundWorkerListener {
    private static Logger LOGGER = Logger.getLogger(BackgroundDownloadJob.class.getCanonicalName());
    protected static final String TAG = "mapkit_background_download";

    protected BackgroundDownloadJob(Context context, WorkerParameters workerParameters) {
        super(context, workerParameters);
    }

    @Override // androidx.work.Worker
    public synchronized ListenableWorker.Result doWork() {
        LOGGER.info("Start background download job");
        final BackgroundDownloadInitializer initializer = BackgroundDownloadManager.getInitializer();
        if (initializer != null) {
            new Handler(Looper.getMainLooper()).post(new Runnable() { // from class: com.yandex.mapkit.offline_cache.internal.BackgroundDownloadJob$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    this.f$0.lambda$doWork$0(initializer);
                }
            });
        }
        try {
            try {
                wait();
                if (initializer != null) {
                    new Handler(Looper.getMainLooper()).post(new Runnable() { // from class: com.yandex.mapkit.offline_cache.internal.BackgroundDownloadJob$$ExternalSyntheticLambda1
                        @Override // java.lang.Runnable
                        public final void run() {
                            initializer.setListener(null);
                        }
                    });
                }
                LOGGER.info("Stop background download job");
            } catch (Throwable th) {
                if (initializer != null) {
                    new Handler(Looper.getMainLooper()).post(new Runnable() { // from class: com.yandex.mapkit.offline_cache.internal.BackgroundDownloadJob$$ExternalSyntheticLambda1
                        @Override // java.lang.Runnable
                        public final void run() {
                            initializer.setListener(null);
                        }
                    });
                }
                throw th;
            }
        } catch (InterruptedException unused) {
            LOGGER.info("Background download job interrupted");
            ListenableWorker.Result resultRetry = ListenableWorker.Result.retry();
            if (initializer != null) {
                new Handler(Looper.getMainLooper()).post(new Runnable() { // from class: com.yandex.mapkit.offline_cache.internal.BackgroundDownloadJob$$ExternalSyntheticLambda1
                    @Override // java.lang.Runnable
                    public final void run() {
                        initializer.setListener(null);
                    }
                });
            }
            return resultRetry;
        }
        return ListenableWorker.Result.success();
    }

    /* JADX INFO: Access modifiers changed from: private */
    public /* synthetic */ void lambda$doWork$0(BackgroundDownloadInitializer backgroundDownloadInitializer) {
        backgroundDownloadInitializer.setListener(this);
        backgroundDownloadInitializer.initializeMapkit();
    }

    @Override // com.yandex.mapkit.offline_cache.internal.BackgroundWorkerListener
    public void updateForegroundInfo(ForegroundInfo foregroundInfo) {
        setForegroundAsync(foregroundInfo);
    }

    @Override // androidx.work.ListenableWorker
    public synchronized void onStopped() {
        notifyAll();
    }
}
