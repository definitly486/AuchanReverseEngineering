package com.scanflow.datacapture.sfcamera;

import android.content.Context;
import android.graphics.Canvas;
import android.util.AttributeSet;
import android.view.View;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class OverlayView extends View {
    private final List<DrawCallback> callbacks;

    public interface DrawCallback {
        void drawCallback(Canvas canvas);
    }

    public OverlayView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        this.callbacks = new LinkedList();
    }

    public void addCallback(DrawCallback drawCallback) {
        this.callbacks.add(drawCallback);
    }

    @Override // android.view.View
    public synchronized void draw(Canvas canvas) {
        super.draw(canvas);
        Iterator<DrawCallback> it = this.callbacks.iterator();
        while (it.hasNext()) {
            it.next().drawCallback(canvas);
        }
    }
}
