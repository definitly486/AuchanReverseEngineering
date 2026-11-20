package com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils;

/* JADX INFO: loaded from: classes.dex */
public interface RingBuffer {

    public interface OnRemoveCallback {
        void onRemove(Object obj);
    }

    Object dequeue();

    void enqueue(Object obj);

    boolean isEmpty();
}
