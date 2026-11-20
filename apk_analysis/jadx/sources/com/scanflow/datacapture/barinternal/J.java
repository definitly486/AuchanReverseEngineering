package com.scanflow.datacapture.barinternal;

import android.view.View;
import com.scanflow.ui.ar.BoundingBoxArOverlay;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class J implements View.OnLayoutChangeListener {
    public final /* synthetic */ M a;
    public final /* synthetic */ BoundingBoxArOverlay b;

    public J(M m, BoundingBoxArOverlay boundingBoxArOverlay) {
        this.a = m;
        this.b = boundingBoxArOverlay;
    }

    @Override // android.view.View.OnLayoutChangeListener
    public final void onLayoutChange(View view, int i, int i2, int i3, int i4, int i5, int i6, int i7, int i8) {
        Intrinsics.checkNotNullParameter(view, "view");
        view.removeOnLayoutChangeListener(this);
        this.a.G.pipe(new x(view.getWidth(), view.getHeight())).pipe(new w()).addTrackingListener(this.b);
    }
}
