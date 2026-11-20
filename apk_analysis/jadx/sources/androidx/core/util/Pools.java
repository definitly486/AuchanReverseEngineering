package androidx.core.util;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Pools.kt */
/* JADX INFO: loaded from: classes.dex */
public final class Pools {

    /* JADX INFO: compiled from: Pools.kt */
    public interface Pool<T> {
        T acquire();

        boolean release(T t);
    }

    private Pools() {
    }

    /* JADX INFO: compiled from: Pools.kt */
    public static class SimplePool implements Pool {
        private final Object[] pool;
        private int poolSize;

        public SimplePool(int i) {
            if (i <= 0) {
                throw new IllegalArgumentException("The max pool size must be > 0");
            }
            this.pool = new Object[i];
        }

        @Override // androidx.core.util.Pools.Pool
        public Object acquire() {
            int i = this.poolSize;
            if (i <= 0) {
                return null;
            }
            int i2 = i - 1;
            Object obj = this.pool[i2];
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type T of androidx.core.util.Pools.SimplePool");
            this.pool[i2] = null;
            this.poolSize--;
            return obj;
        }

        @Override // androidx.core.util.Pools.Pool
        public boolean release(Object instance) {
            Intrinsics.checkNotNullParameter(instance, "instance");
            if (isInPool(instance)) {
                throw new IllegalStateException("Already in the pool!");
            }
            int i = this.poolSize;
            Object[] objArr = this.pool;
            if (i >= objArr.length) {
                return false;
            }
            objArr[i] = instance;
            this.poolSize = i + 1;
            return true;
        }

        private final boolean isInPool(Object obj) {
            int i = this.poolSize;
            for (int i2 = 0; i2 < i; i2++) {
                if (this.pool[i2] == obj) {
                    return true;
                }
            }
            return false;
        }
    }

    /* JADX INFO: compiled from: Pools.kt */
    public static class SynchronizedPool extends SimplePool {
        private final Object lock;

        public SynchronizedPool(int i) {
            super(i);
            this.lock = new Object();
        }

        @Override // androidx.core.util.Pools.SimplePool, androidx.core.util.Pools.Pool
        public Object acquire() {
            Object objAcquire;
            synchronized (this.lock) {
                objAcquire = super.acquire();
            }
            return objAcquire;
        }

        @Override // androidx.core.util.Pools.SimplePool, androidx.core.util.Pools.Pool
        public boolean release(Object instance) {
            boolean zRelease;
            Intrinsics.checkNotNullParameter(instance, "instance");
            synchronized (this.lock) {
                zRelease = super.release(instance);
            }
            return zRelease;
        }
    }
}
