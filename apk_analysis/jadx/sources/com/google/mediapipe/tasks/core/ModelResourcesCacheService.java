package com.google.mediapipe.tasks.core;

import com.google.mediapipe.framework.GraphService;

/* JADX INFO: loaded from: classes3.dex */
class ModelResourcesCacheService implements GraphService<ModelResourcesCache> {
    public native void nativeInstallServiceObject(long j, long j2);

    @Override // com.google.mediapipe.framework.GraphService
    public void installServiceObject(long j, ModelResourcesCache modelResourcesCache) {
        nativeInstallServiceObject(j, modelResourcesCache.getNativeHandle());
    }
}
