package com.scanflow.datacapture.barinternal.androidx.camera.core.internal;

import androidx.camera.core.ImageCapture;
import androidx.camera.core.Logger;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ScreenFlashWrapper.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ScreenFlashWrapper implements ImageCapture.ScreenFlash {
    public static final Companion Companion = new Companion(null);
    private boolean isClearScreenFlashPending;
    private final Object lock;
    private ImageCapture.ScreenFlashListener pendingListener;
    private final ImageCapture.ScreenFlash screenFlash;

    public /* synthetic */ ScreenFlashWrapper(ImageCapture.ScreenFlash screenFlash, DefaultConstructorMarker defaultConstructorMarker) {
        this(screenFlash);
    }

    public static final ScreenFlashWrapper from(ImageCapture.ScreenFlash screenFlash) {
        return Companion.from(screenFlash);
    }

    private ScreenFlashWrapper(ImageCapture.ScreenFlash screenFlash) {
        this.screenFlash = screenFlash;
        this.lock = new Object();
    }

    /* JADX INFO: compiled from: ScreenFlashWrapper.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final ScreenFlashWrapper from(ImageCapture.ScreenFlash screenFlash) {
            return new ScreenFlashWrapper(screenFlash, null);
        }
    }

    @Override // androidx.camera.core.ImageCapture.ScreenFlash
    public void apply(long j, ImageCapture.ScreenFlashListener screenFlashListener) {
        Unit unit;
        Intrinsics.checkNotNullParameter(screenFlashListener, "screenFlashListener");
        synchronized (this.lock) {
            this.isClearScreenFlashPending = true;
            this.pendingListener = screenFlashListener;
            Unit unit2 = Unit.INSTANCE;
        }
        ImageCapture.ScreenFlash screenFlash = this.screenFlash;
        if (screenFlash != null) {
            screenFlash.apply(j, new ImageCapture.ScreenFlashListener() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.core.internal.ScreenFlashWrapper$$ExternalSyntheticLambda0
                @Override // androidx.camera.core.ImageCapture.ScreenFlashListener
                public final void onCompleted() {
                    ScreenFlashWrapper.apply$lambda$2(this.f$0);
                }
            });
            unit = Unit.INSTANCE;
        } else {
            unit = null;
        }
        if (unit == null) {
            Logger.e("ScreenFlashWrapper", "apply: screenFlash is null!");
            completePendingScreenFlashListener();
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void apply$lambda$2(ScreenFlashWrapper this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        synchronized (this$0.lock) {
            try {
                if (this$0.pendingListener == null) {
                    Logger.w("ScreenFlashWrapper", "apply: pendingListener is null!");
                }
                this$0.completePendingScreenFlashListener();
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // androidx.camera.core.ImageCapture.ScreenFlash
    public void clear() {
        completePendingScreenFlashClear();
    }

    public final ImageCapture.ScreenFlash getBaseScreenFlash() {
        return this.screenFlash;
    }

    private final void completePendingScreenFlashListener() {
        synchronized (this.lock) {
            try {
                ImageCapture.ScreenFlashListener screenFlashListener = this.pendingListener;
                if (screenFlashListener != null) {
                    screenFlashListener.onCompleted();
                }
                this.pendingListener = null;
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    private final void completePendingScreenFlashClear() {
        Unit unit;
        synchronized (this.lock) {
            try {
                if (this.isClearScreenFlashPending) {
                    ImageCapture.ScreenFlash screenFlash = this.screenFlash;
                    if (screenFlash != null) {
                        screenFlash.clear();
                        unit = Unit.INSTANCE;
                    } else {
                        unit = null;
                    }
                    if (unit == null) {
                        Logger.e("ScreenFlashWrapper", "completePendingScreenFlashClear: screenFlash is null!");
                    }
                } else {
                    Logger.w("ScreenFlashWrapper", "completePendingScreenFlashClear: none pending!");
                }
                this.isClearScreenFlashPending = false;
                Unit unit2 = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final void completePendingTasks() {
        completePendingScreenFlashListener();
        completePendingScreenFlashClear();
    }
}
