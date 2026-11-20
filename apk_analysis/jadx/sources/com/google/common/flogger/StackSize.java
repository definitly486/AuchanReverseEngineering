package com.google.common.flogger;

/* JADX INFO: loaded from: classes2.dex */
public enum StackSize {
    SMALL(10),
    MEDIUM(20),
    LARGE(50),
    FULL(-1),
    NONE(0);

    private final int maxDepth;

    StackSize(int i) {
        this.maxDepth = i;
    }

    int getMaxDepth() {
        return this.maxDepth;
    }
}
