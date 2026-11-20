package com.google.mediapipe.tasks.components.containers;

import com.google.auto.value.AutoValue;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class Connection {
    public abstract int end();

    public abstract int start();

    public static Connection create(int i, int i2) {
        return new AutoValue_Connection(i, i2);
    }
}
