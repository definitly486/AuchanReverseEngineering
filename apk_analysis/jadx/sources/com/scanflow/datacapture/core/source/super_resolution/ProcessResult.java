package com.scanflow.datacapture.core.source.super_resolution;

import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class ProcessResult {
    private final String[] classes;
    private final long inferenceTime;
    private final List<EnhancementResult> results;
    private final long totalTime;

    public ProcessResult(List<EnhancementResult> list, String[] strArr, long j, long j2) {
        this.results = list;
        this.classes = strArr;
        this.inferenceTime = j;
        this.totalTime = j2;
    }

    public String[] getClasses() {
        return this.classes;
    }

    public long getInferenceTime() {
        return this.inferenceTime;
    }

    public List<EnhancementResult> getResults() {
        return this.results;
    }

    public long getTotalTime() {
        return this.totalTime;
    }
}
