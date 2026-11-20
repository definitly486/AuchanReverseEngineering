package com.google.mediapipe.framework;

import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class ResourcesWithMapping {
    private final Map<String, String> resourcesMapping;

    public ResourcesWithMapping() {
        this(null);
    }

    public ResourcesWithMapping(Map<String, String> map) {
        this.resourcesMapping = map;
    }

    public Map<String, String> getResourcesMapping() {
        return this.resourcesMapping;
    }
}
