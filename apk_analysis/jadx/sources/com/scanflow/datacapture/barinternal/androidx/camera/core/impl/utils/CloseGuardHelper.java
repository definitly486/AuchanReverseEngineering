package com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils;

import android.os.Build;
import android.util.CloseGuard;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;

/* JADX INFO: loaded from: classes.dex */
public final class CloseGuardHelper {
    private final CloseGuardImpl mImpl;

    private interface CloseGuardImpl {
        void close();

        void open(String str);

        void warnIfOpen();
    }

    private CloseGuardHelper(CloseGuardImpl closeGuardImpl) {
        this.mImpl = closeGuardImpl;
    }

    public static CloseGuardHelper create() {
        if (Build.VERSION.SDK_INT >= 30) {
            return new CloseGuardHelper(new CloseGuardApi30Impl());
        }
        return new CloseGuardHelper(new CloseGuardNoOpImpl());
    }

    public void open(String str) {
        this.mImpl.open(str);
    }

    public void close() {
        this.mImpl.close();
    }

    public void warnIfOpen() {
        this.mImpl.warnIfOpen();
    }

    static final class CloseGuardApi30Impl implements CloseGuardImpl {
        private final CloseGuard mPlatformImpl = new CloseGuard();

        CloseGuardApi30Impl() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.CloseGuardHelper.CloseGuardImpl
        public void open(String str) {
            this.mPlatformImpl.open(str);
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.CloseGuardHelper.CloseGuardImpl
        public void close() {
            this.mPlatformImpl.close();
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.CloseGuardHelper.CloseGuardImpl
        public void warnIfOpen() {
            this.mPlatformImpl.warnIfOpen();
        }
    }

    static final class CloseGuardNoOpImpl implements CloseGuardImpl {
        CloseGuardNoOpImpl() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.CloseGuardHelper.CloseGuardImpl
        public void open(String str) {
            Preconditions.checkNotNull(str, "CloseMethodName must not be null.");
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.CloseGuardHelper.CloseGuardImpl
        public void close() {
        }

        @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.impl.utils.CloseGuardHelper.CloseGuardImpl
        public void warnIfOpen() {
        }
    }
}
