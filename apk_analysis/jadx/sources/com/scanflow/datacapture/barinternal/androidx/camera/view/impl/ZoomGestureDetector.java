package com.scanflow.datacapture.barinternal.androidx.camera.view.impl;

import android.content.Context;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.ViewConfiguration;
import com.scanflow.datacapture.barinternal.kotlin.math.MathKt;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ZoomGestureDetector.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ZoomGestureDetector {
    public static final Companion Companion = new Companion(null);
    private int anchoredZoomMode;
    private float anchoredZoomStartX;
    private float anchoredZoomStartY;
    private final Context context;
    private float currentSpan;
    private float currentSpanX;
    private float currentSpanY;
    private boolean eventBeforeOrAboveStartingGestureEvent;
    private long eventTime;
    private int focusX;
    private int focusY;
    private GestureDetector gestureDetector;
    private float initialSpan;
    private boolean isInProgress;
    private boolean isQuickZoomEnabled;
    private boolean isStylusZoomEnabled;
    private final OnZoomGestureListener listener;
    private final int minSpan;
    private long prevTime;
    private float previousSpan;
    private float previousSpanX;
    private float previousSpanY;
    private final int spanSlop;

    /* JADX INFO: compiled from: ZoomGestureDetector.kt */
    public interface OnZoomGestureListener {
        boolean onZoomEvent(ZoomEvent zoomEvent);
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public ZoomGestureDetector(Context context, OnZoomGestureListener listener) {
        this(context, 0, 0, listener, 6, null);
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(listener, "listener");
    }

    public ZoomGestureDetector(Context context, int i, int i2, OnZoomGestureListener listener) {
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(listener, "listener");
        this.context = context;
        this.spanSlop = i;
        this.minSpan = i2;
        this.listener = listener;
        this.isQuickZoomEnabled = true;
        this.isStylusZoomEnabled = true;
        this.gestureDetector = new GestureDetector(context, new GestureDetector.SimpleOnGestureListener() { // from class: com.scanflow.datacapture.barinternal.androidx.camera.view.impl.ZoomGestureDetector$gestureDetector$1
            @Override // android.view.GestureDetector.SimpleOnGestureListener, android.view.GestureDetector.OnDoubleTapListener
            public boolean onDoubleTap(MotionEvent e) {
                Intrinsics.checkNotNullParameter(e, "e");
                this.this$0.anchoredZoomStartX = e.getX();
                this.this$0.anchoredZoomStartY = e.getY();
                this.this$0.anchoredZoomMode = 1;
                return true;
            }
        });
    }

    public /* synthetic */ ZoomGestureDetector(Context context, int i, int i2, OnZoomGestureListener onZoomGestureListener, int i3, DefaultConstructorMarker defaultConstructorMarker) {
        this(context, (i3 & 2) != 0 ? ViewConfiguration.get(context).getScaledTouchSlop() * 2 : i, (i3 & 4) != 0 ? 0 : i2, onZoomGestureListener);
    }

    /* JADX INFO: compiled from: ZoomGestureDetector.kt */
    public static abstract class ZoomEvent {
        private final long eventTime;
        private final int focusX;
        private final int focusY;

        public /* synthetic */ ZoomEvent(long j, int i, int i2, DefaultConstructorMarker defaultConstructorMarker) {
            this(j, i, i2);
        }

        private ZoomEvent(long j, int i, int i2) {
            this.eventTime = j;
            this.focusX = i;
            this.focusY = i2;
        }

        /* JADX INFO: compiled from: ZoomGestureDetector.kt */
        public static final class Begin extends ZoomEvent {
            public Begin(long j, int i, int i2) {
                super(j, i, i2, null);
            }
        }

        /* JADX INFO: compiled from: ZoomGestureDetector.kt */
        public static final class Move extends ZoomEvent {
            private final float incrementalScaleFactor;

            public final float getIncrementalScaleFactor() {
                return this.incrementalScaleFactor;
            }

            public Move(long j, int i, int i2, float f) {
                super(j, i, i2, null);
                this.incrementalScaleFactor = f;
            }
        }

        /* JADX INFO: compiled from: ZoomGestureDetector.kt */
        public static final class End extends ZoomEvent {
            private final float incrementalScaleFactor;

            public End(long j, int i, int i2, float f) {
                super(j, i, i2, null);
                this.incrementalScaleFactor = f;
            }
        }
    }

    public final boolean onTouchEvent(MotionEvent event) {
        boolean z;
        float f;
        float f2;
        Intrinsics.checkNotNullParameter(event, "event");
        this.eventTime = event.getEventTime();
        int actionMasked = event.getActionMasked();
        if (this.isQuickZoomEnabled) {
            this.gestureDetector.onTouchEvent(event);
        }
        int pointerCount = event.getPointerCount();
        boolean z2 = (event.getButtonState() & 32) != 0;
        boolean z3 = this.anchoredZoomMode == 2 && !z2;
        boolean z4 = actionMasked == 1 || actionMasked == 3 || z3;
        float fAbs = 0.0f;
        if (actionMasked == 0 || z4) {
            if (this.isInProgress) {
                z = true;
                this.listener.onZoomEvent(new ZoomEvent.End(this.eventTime, this.focusX, this.focusY, getIncrementalScaleFactor()));
                this.isInProgress = false;
                this.initialSpan = 0.0f;
                this.anchoredZoomMode = 0;
            } else {
                z = true;
                if (inAnchoredZoomMode() && z4) {
                    this.isInProgress = false;
                    this.initialSpan = 0.0f;
                    this.anchoredZoomMode = 0;
                }
            }
            if (z4) {
                return z;
            }
        } else {
            z = true;
        }
        if (!this.isInProgress && this.isStylusZoomEnabled && !inAnchoredZoomMode() && !z4 && z2) {
            this.anchoredZoomStartX = event.getX();
            this.anchoredZoomStartY = event.getY();
            this.anchoredZoomMode = 2;
            this.initialSpan = 0.0f;
        }
        boolean z5 = (actionMasked == 0 || actionMasked == 6 || actionMasked == 5 || z3) ? z : false;
        boolean z6 = actionMasked == 6 ? z : false;
        int actionIndex = z6 ? event.getActionIndex() : -1;
        int i = z6 ? pointerCount - 1 : pointerCount;
        if (inAnchoredZoomMode()) {
            f2 = this.anchoredZoomStartX;
            f = this.anchoredZoomStartY;
            this.eventBeforeOrAboveStartingGestureEvent = event.getY() < f ? z : false;
        } else {
            float x = 0.0f;
            float y = 0.0f;
            for (int i2 = 0; i2 < pointerCount; i2++) {
                if (actionIndex != i2) {
                    x += event.getX(i2);
                    y += event.getY(i2);
                }
            }
            float f3 = i;
            float f4 = x / f3;
            f = y / f3;
            f2 = f4;
        }
        float fAbs2 = 0.0f;
        for (int i3 = 0; i3 < pointerCount; i3++) {
            if (actionIndex != i3) {
                fAbs += Math.abs(event.getX(i3) - f2);
                fAbs2 += Math.abs(event.getY(i3) - f);
            }
        }
        float f5 = i;
        float f6 = fAbs / f5;
        float f7 = fAbs2 / f5;
        float f8 = 2;
        float f9 = f6 * f8;
        float f10 = f7 * f8;
        float fHypot = inAnchoredZoomMode() ? f10 : (float) Math.hypot(f9, f10);
        boolean z7 = this.isInProgress;
        this.focusX = MathKt.roundToInt(f2);
        this.focusY = MathKt.roundToInt(f);
        if (!inAnchoredZoomMode() && this.isInProgress && (fHypot < this.minSpan || z5)) {
            this.listener.onZoomEvent(new ZoomEvent.End(this.eventTime, this.focusX, this.focusY, getIncrementalScaleFactor()));
            this.isInProgress = false;
            this.initialSpan = fHypot;
        }
        if (z5) {
            this.currentSpanX = f9;
            this.previousSpanX = f9;
            this.currentSpanY = f10;
            this.previousSpanY = f10;
            this.currentSpan = fHypot;
            this.previousSpan = fHypot;
            this.initialSpan = fHypot;
        }
        int i4 = inAnchoredZoomMode() ? this.spanSlop : this.minSpan;
        if (!this.isInProgress && fHypot >= i4 && (z7 || Math.abs(fHypot - this.initialSpan) > this.spanSlop)) {
            this.currentSpanX = f9;
            this.previousSpanX = f9;
            this.currentSpanY = f10;
            this.previousSpanY = f10;
            this.currentSpan = fHypot;
            this.previousSpan = fHypot;
            long j = this.eventTime;
            this.prevTime = j;
            this.isInProgress = this.listener.onZoomEvent(new ZoomEvent.Begin(j, this.focusX, this.focusY));
        }
        if (actionMasked == 2) {
            this.currentSpanX = f9;
            this.currentSpanY = f10;
            this.currentSpan = fHypot;
            if (this.isInProgress ? this.listener.onZoomEvent(new ZoomEvent.Move(this.eventTime, this.focusX, this.focusY, getIncrementalScaleFactor())) : z) {
                this.previousSpanX = this.currentSpanX;
                this.previousSpanY = this.currentSpanY;
                this.previousSpan = this.currentSpan;
                this.prevTime = this.eventTime;
            }
        }
        return z;
    }

    private final boolean inAnchoredZoomMode() {
        return this.anchoredZoomMode != 0;
    }

    private final float getIncrementalScaleFactor() {
        if (inAnchoredZoomMode()) {
            boolean z = this.eventBeforeOrAboveStartingGestureEvent;
            boolean z2 = (z && this.currentSpan < this.previousSpan) || (!z && this.currentSpan > this.previousSpan);
            float fAbs = Math.abs(1 - (this.currentSpan / this.previousSpan)) * 0.5f;
            if (this.previousSpan <= this.spanSlop) {
                return 1.0f;
            }
            return z2 ? fAbs + 1.0f : 1.0f - fAbs;
        }
        float f = this.previousSpan;
        if (f > 0.0f) {
            return this.currentSpan / f;
        }
        return 1.0f;
    }

    /* JADX INFO: compiled from: ZoomGestureDetector.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }
    }
}
