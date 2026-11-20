package com.scanflow.ui.ar;

import android.graphics.Canvas;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public abstract class a {
    private ArOverlayView host;

    public final ArOverlayView getHost() {
        return this.host;
    }

    public void onAttached(ArOverlayView view) {
        Intrinsics.checkNotNullParameter(view, "view");
        this.host = view;
    }

    public abstract void onDraw(Canvas canvas);

    public final void setHost(ArOverlayView arOverlayView) {
        this.host = arOverlayView;
    }
}
