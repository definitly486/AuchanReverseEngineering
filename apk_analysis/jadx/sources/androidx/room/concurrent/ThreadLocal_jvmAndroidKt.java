package androidx.room.concurrent;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.ThreadContextElementKt;
import kotlin.coroutines.CoroutineContext;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ThreadLocal.jvmAndroid.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ThreadLocal_jvmAndroidKt {
    public static final CoroutineContext.Element asContextElement(ThreadLocal threadLocal, Object obj) {
        Intrinsics.checkNotNullParameter(threadLocal, "<this>");
        return ThreadContextElementKt.asContextElement(threadLocal, obj);
    }

    public static final long currentThreadId() {
        return Thread.currentThread().getId();
    }
}
