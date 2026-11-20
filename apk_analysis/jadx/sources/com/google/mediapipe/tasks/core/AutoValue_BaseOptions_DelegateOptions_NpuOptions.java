package com.google.mediapipe.tasks.core;

/* JADX INFO: loaded from: classes3.dex */
final class AutoValue_BaseOptions_DelegateOptions_NpuOptions extends BaseOptions.DelegateOptions.NpuOptions {
    private final String dispatchLibraryDirectory;

    private AutoValue_BaseOptions_DelegateOptions_NpuOptions(String str) {
        this.dispatchLibraryDirectory = str;
    }

    @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.NpuOptions
    String dispatchLibraryDirectory() {
        return this.dispatchLibraryDirectory;
    }

    public String toString() {
        return "NpuOptions{dispatchLibraryDirectory=" + this.dispatchLibraryDirectory + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof BaseOptions.DelegateOptions.NpuOptions) {
            return this.dispatchLibraryDirectory.equals(((BaseOptions.DelegateOptions.NpuOptions) obj).dispatchLibraryDirectory());
        }
        return false;
    }

    public int hashCode() {
        return this.dispatchLibraryDirectory.hashCode() ^ 1000003;
    }

    static final class Builder extends BaseOptions.DelegateOptions.NpuOptions.Builder {
        private String dispatchLibraryDirectory;

        Builder() {
        }

        @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.NpuOptions.Builder
        public BaseOptions.DelegateOptions.NpuOptions.Builder setDispatchLibraryDirectory(String str) {
            if (str == null) {
                throw new NullPointerException("Null dispatchLibraryDirectory");
            }
            this.dispatchLibraryDirectory = str;
            return this;
        }

        @Override // com.google.mediapipe.tasks.core.BaseOptions.DelegateOptions.NpuOptions.Builder
        public BaseOptions.DelegateOptions.NpuOptions build() {
            String str = "";
            if (this.dispatchLibraryDirectory == null) {
                str = " dispatchLibraryDirectory";
            }
            if (!str.isEmpty()) {
                throw new IllegalStateException("Missing required properties:" + str);
            }
            return new AutoValue_BaseOptions_DelegateOptions_NpuOptions(this.dispatchLibraryDirectory);
        }
    }
}
