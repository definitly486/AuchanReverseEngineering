package androidx.lifecycle.viewmodel.internal;

import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.InlineMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SynchronizedObject.jvm.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SynchronizedObject_jvmKt {
    public static final <T> T synchronizedImpl(SynchronizedObject lock, Function0<? extends T> action) {
        T tInvoke;
        Intrinsics.checkNotNullParameter(lock, "lock");
        Intrinsics.checkNotNullParameter(action, "action");
        synchronized (lock) {
            try {
                tInvoke = action.invoke();
                InlineMarker.finallyStart(1);
            } finally {
                InlineMarker.finallyStart(1);
                InlineMarker.finallyEnd(1);
            }
        }
        return tInvoke;
    }
}
