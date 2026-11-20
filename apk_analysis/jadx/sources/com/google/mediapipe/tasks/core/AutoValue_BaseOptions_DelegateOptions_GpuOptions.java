package com.google.mediapipe.tasks.core;

import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_BaseOptions_DelegateOptions_GpuOptions extends BaseOptions.DelegateOptions.GpuOptions {
    private final Optional<String> cachedKernelPath;
    private final Optional<String> modelToken;
    private final Optional<String> serializedModelDir;

    private AutoValue_BaseOptions_DelegateOptions_GpuOptions(Optional<String> optional, Optional<String> optional2, Optional<String> optional3) {
        this.cachedKernelPath = optional;
        this.serializedModelDir = optional2;
        this.modelToken = optional3;
    }

    @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.GpuOptions
    Optional<String> cachedKernelPath() {
        return this.cachedKernelPath;
    }

    @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.GpuOptions
    Optional<String> serializedModelDir() {
        return this.serializedModelDir;
    }

    @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.GpuOptions
    Optional<String> modelToken() {
        return this.modelToken;
    }

    public String toString() {
        return "GpuOptions{cachedKernelPath=" + this.cachedKernelPath + ", serializedModelDir=" + this.serializedModelDir + ", modelToken=" + this.modelToken + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof BaseOptions.DelegateOptions.GpuOptions) {
            BaseOptions.DelegateOptions.GpuOptions gpuOptions = (BaseOptions.DelegateOptions.GpuOptions) obj;
            if (this.cachedKernelPath.equals(gpuOptions.cachedKernelPath()) && this.serializedModelDir.equals(gpuOptions.serializedModelDir()) && this.modelToken.equals(gpuOptions.modelToken())) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((((this.cachedKernelPath.hashCode() ^ 1000003) * 1000003) ^ this.serializedModelDir.hashCode()) * 1000003) ^ this.modelToken.hashCode();
    }

    static final class Builder extends BaseOptions.DelegateOptions.GpuOptions.Builder {
        private Optional<String> cachedKernelPath = Optional.empty();
        private Optional<String> serializedModelDir = Optional.empty();
        private Optional<String> modelToken = Optional.empty();

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.GpuOptions.Builder
        public BaseOptions.DelegateOptions.GpuOptions.Builder setCachedKernelPath(String str) {
            this.cachedKernelPath = Optional.of(str);
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.GpuOptions.Builder
        public BaseOptions.DelegateOptions.GpuOptions.Builder setSerializedModelDir(String str) {
            this.serializedModelDir = Optional.of(str);
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.GpuOptions.Builder
        public BaseOptions.DelegateOptions.GpuOptions.Builder setModelToken(String str) {
            this.modelToken = Optional.of(str);
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.GpuOptions.Builder
        public BaseOptions.DelegateOptions.GpuOptions build() {
            return new AutoValue_BaseOptions_DelegateOptions_GpuOptions(this.cachedKernelPath, this.serializedModelDir, this.modelToken);
        }
    }
}
