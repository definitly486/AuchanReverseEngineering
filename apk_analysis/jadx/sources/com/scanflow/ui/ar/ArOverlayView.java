package com.scanflow.ui.ar;

import android.content.Context;
import android.graphics.Canvas;
import android.util.AttributeSet;
import android.widget.FrameLayout;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class ArOverlayView extends FrameLayout {
    private final Object objectLock;
    private final List<a> overlays;

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public ArOverlayView(Context context) {
        this(context, null, 0, 6, null);
        Intrinsics.checkNotNullParameter(context, "context");
    }

    public final void add(a overlay) {
        Intrinsics.checkNotNullParameter(overlay, "overlay");
        remove(overlay);
        this.overlays.add(overlay);
        overlay.onAttached(this);
        invalidate();
    }

    public final void clear() {
        this.overlays.clear();
        invalidate();
    }

    @Override // android.view.View
    public void onDraw(Canvas canvas) {
        Intrinsics.checkNotNullParameter(canvas, "canvas");
        super.onDraw(canvas);
        Iterator<T> it = this.overlays.iterator();
        while (it.hasNext()) {
            ((a) it.next()).onDraw(canvas);
        }
    }

    public final void remove(a overlay) {
        Intrinsics.checkNotNullParameter(overlay, "overlay");
        this.overlays.remove(overlay);
    }

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    public ArOverlayView(Context context, AttributeSet attributeSet) {
        this(context, attributeSet, 0, 4, null);
        Intrinsics.checkNotNullParameter(context, "context");
    }

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public ArOverlayView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        Intrinsics.checkNotNullParameter(context, "context");
        this.overlays = new ArrayList();
        this.objectLock = new Object();
        setWillNotDraw(false);
    }

    public /* synthetic */ ArOverlayView(Context context, AttributeSet attributeSet, int i, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this(context, (i2 & 2) != 0 ? null : attributeSet, (i2 & 4) != 0 ? 0 : i);
    }
}
