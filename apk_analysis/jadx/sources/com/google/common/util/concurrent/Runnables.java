package com.google.common.util.concurrent;

import com.google.common.annotations.GwtCompatible;

/* JADX INFO: loaded from: classes2.dex */
@GwtCompatible
public final class Runnables {
    private static final Runnable EMPTY_RUNNABLE = new Runnable() { // from class: com.google.common.util.concurrent.Runnables$$ExternalSyntheticLambda0
        @Override // java.lang.Runnable
        public final void run() {
            Runnables.$r8$lambda$KIerTsn50uK6kuVUrrdRhSQqxYU();
        }
    };

    public static /* synthetic */ void $r8$lambda$KIerTsn50uK6kuVUrrdRhSQqxYU() {
    }

    public static Runnable doNothing() {
        return EMPTY_RUNNABLE;
    }

    private Runnables() {
    }
}
