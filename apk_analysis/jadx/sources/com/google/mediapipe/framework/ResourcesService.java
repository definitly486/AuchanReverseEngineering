package com.google.mediapipe.framework;

import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public class ResourcesService implements GraphService<ResourcesWithMapping> {
    public native void nativeInstallServiceObject(long j, Map<String, String> map);

    @Override // com.google.mediapipe.framework.GraphService
    public void installServiceObject(long j, ResourcesWithMapping resourcesWithMapping) {
        nativeInstallServiceObject(j, resourcesWithMapping.getResourcesMapping());
    }
}
