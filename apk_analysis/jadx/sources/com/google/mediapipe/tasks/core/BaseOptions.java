package com.google.mediapipe.tasks.core;

import com.google.auto.value.AutoValue;
import java.nio.ByteBuffer;
import java.nio.MappedByteBuffer;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class BaseOptions {
    abstract Delegate delegate();

    abstract Optional<DelegateOptions> delegateOptions();

    abstract Optional<ByteBuffer> modelAssetBuffer();

    abstract Optional<Integer> modelAssetFileDescriptor();

    abstract Optional<String> modelAssetPath();

    @AutoValue.Builder
    public static abstract class Builder {
        abstract BaseOptions autoBuild();

        public abstract Builder setDelegate(Delegate delegate);

        public abstract Builder setDelegateOptions(DelegateOptions delegateOptions);

        public abstract Builder setModelAssetBuffer(ByteBuffer byteBuffer);

        public abstract Builder setModelAssetFileDescriptor(Integer num);

        public abstract Builder setModelAssetPath(String str);

        public final BaseOptions build() {
            BaseOptions baseOptionsAutoBuild = autoBuild();
            boolean z = true;
            if ((baseOptionsAutoBuild.modelAssetPath().isPresent() ? 1 : 0) + (baseOptionsAutoBuild.modelAssetFileDescriptor().isPresent() ? 1 : 0) + (baseOptionsAutoBuild.modelAssetBuffer().isPresent() ? 1 : 0) != 1) {
                throw new IllegalArgumentException("Please specify only one of the model asset path, the model asset file descriptor, and the model asset buffer.");
            }
            if (baseOptionsAutoBuild.modelAssetBuffer().isPresent() && !baseOptionsAutoBuild.modelAssetBuffer().get().isDirect() && !(baseOptionsAutoBuild.modelAssetBuffer().get() instanceof MappedByteBuffer)) {
                throw new IllegalArgumentException("The model buffer should be either a direct ByteBuffer or a MappedByteBuffer.");
            }
            if (baseOptionsAutoBuild.delegateOptions().isPresent()) {
                int i = AnonymousClass1.$SwitchMap$com$google$mediapipe$tasks$core$Delegate[baseOptionsAutoBuild.delegate().ordinal()];
                if (i == 1) {
                    z = baseOptionsAutoBuild.delegateOptions().get() instanceof DelegateOptions.CpuOptions;
                } else if (i == 2) {
                    z = baseOptionsAutoBuild.delegateOptions().get() instanceof DelegateOptions.GpuOptions;
                }
                if (!z) {
                    throw new IllegalArgumentException("Specified Delegate type does not match the provided delegate options.");
                }
            }
            return baseOptionsAutoBuild;
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.core.BaseOptions$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$com$google$mediapipe$tasks$core$Delegate;

        static {
            int[] iArr = new int[Delegate.values().length];
            $SwitchMap$com$google$mediapipe$tasks$core$Delegate = iArr;
            try {
                iArr[Delegate.CPU.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$com$google$mediapipe$tasks$core$Delegate[Delegate.GPU.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
        }
    }

    public static abstract class DelegateOptions {

        @AutoValue
        public static abstract class CpuOptions extends DelegateOptions {

            @AutoValue.Builder
            public static abstract class Builder {
                public abstract CpuOptions build();
            }

            public static Builder builder() {
                return new AutoValue_BaseOptions_DelegateOptions_CpuOptions.Builder();
            }
        }

        @AutoValue
        public static abstract class GpuOptions extends DelegateOptions {

            @AutoValue.Builder
            public static abstract class Builder {
                public abstract GpuOptions build();

                public abstract Builder setCachedKernelPath(String str);

                public abstract Builder setModelToken(String str);

                public abstract Builder setSerializedModelDir(String str);
            }

            abstract Optional<String> cachedKernelPath();

            abstract Optional<String> modelToken();

            abstract Optional<String> serializedModelDir();

            public static Builder builder() {
                return new AutoValue_BaseOptions_DelegateOptions_GpuOptions.Builder();
            }
        }

        @AutoValue
        public static abstract class NpuOptions extends DelegateOptions {

            @AutoValue.Builder
            public static abstract class Builder {
                public abstract NpuOptions build();

                public abstract Builder setDispatchLibraryDirectory(String str);
            }

            abstract String dispatchLibraryDirectory();

            public static Builder builder() {
                return new AutoValue_BaseOptions_DelegateOptions_NpuOptions.Builder();
            }
        }
    }

    public static Builder builder() {
        return new AutoValue_BaseOptions.Builder().setDelegate(Delegate.CPU);
    }
}
