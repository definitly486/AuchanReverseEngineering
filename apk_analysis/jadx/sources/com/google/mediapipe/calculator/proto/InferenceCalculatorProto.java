package com.google.mediapipe.calculator.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.Internal;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import com.google.protobuf.WireFormat;
import java.io.InputStream;
import java.nio.ByteBuffer;
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class InferenceCalculatorProto {

    public interface InferenceCalculatorOptionsOrBuilder extends MessageLiteOrBuilder {
        int getCpuNumThread();

        InferenceCalculatorOptions.Delegate getDelegate();

        InferenceCalculatorOptions.InputOutputConfig getInputOutputConfig();

        String getModelPath();

        ByteString getModelPathBytes();

        boolean getTryMmapModel();

        @Deprecated
        boolean getUseGpu();

        @Deprecated
        boolean getUseNnapi();

        boolean hasCpuNumThread();

        boolean hasDelegate();

        boolean hasInputOutputConfig();

        boolean hasModelPath();

        boolean hasTryMmapModel();

        @Deprecated
        boolean hasUseGpu();

        @Deprecated
        boolean hasUseNnapi();
    }

    private InferenceCalculatorProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) InferenceCalculatorOptions.ext);
    }

    public static final class InferenceCalculatorOptions extends GeneratedMessageLite<InferenceCalculatorOptions, Builder> implements InferenceCalculatorOptionsOrBuilder {
        public static final int CPU_NUM_THREAD_FIELD_NUMBER = 4;
        private static final InferenceCalculatorOptions DEFAULT_INSTANCE;
        public static final int DELEGATE_FIELD_NUMBER = 5;
        public static final int EXT_FIELD_NUMBER = 336783863;
        public static final int INPUT_OUTPUT_CONFIG_FIELD_NUMBER = 8;
        public static final int MODEL_PATH_FIELD_NUMBER = 1;
        private static volatile Parser<InferenceCalculatorOptions> PARSER = null;
        public static final int TRY_MMAP_MODEL_FIELD_NUMBER = 7;
        public static final int USE_GPU_FIELD_NUMBER = 2;
        public static final int USE_NNAPI_FIELD_NUMBER = 3;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, InferenceCalculatorOptions> ext;
        private int bitField0_;
        private Delegate delegate_;
        private InputOutputConfig inputOutputConfig_;
        private boolean tryMmapModel_;
        private boolean useGpu_;
        private boolean useNnapi_;
        private String modelPath_ = "";
        private int cpuNumThread_ = -1;

        public interface DelegateOrBuilder extends MessageLiteOrBuilder {
            Delegate.DelegateCase getDelegateCase();

            Delegate.Gpu getGpu();

            Delegate.Nnapi getNnapi();

            Delegate.TfLite getTflite();

            Delegate.Xnnpack getXnnpack();

            boolean hasGpu();

            boolean hasNnapi();

            boolean hasTflite();

            boolean hasXnnpack();
        }

        public interface InputOutputConfigOrBuilder extends MessageLiteOrBuilder {
            InputOutputConfig.FeedbackTensorLink getFeedbackTensorLinks(int i);

            int getFeedbackTensorLinksCount();

            List<InputOutputConfig.FeedbackTensorLink> getFeedbackTensorLinksList();

            InputOutputConfig.TensorIndicesMap getInputTensorIndicesMap();

            InputOutputConfig.InputTensorMapCase getInputTensorMapCase();

            InputOutputConfig.TensorNamesMap getInputTensorNamesMap();

            InputOutputConfig.TensorIndicesMap getOutputTensorIndicesMap();

            InputOutputConfig.OutputTensorMapCase getOutputTensorMapCase();

            InputOutputConfig.TensorNamesMap getOutputTensorNamesMap();

            boolean hasInputTensorIndicesMap();

            boolean hasInputTensorNamesMap();

            boolean hasOutputTensorIndicesMap();

            boolean hasOutputTensorNamesMap();
        }

        @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
        public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
            return super.getDefaultInstanceForType();
        }

        @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
        public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
            return super.newBuilderForType();
        }

        @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
        public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
            return super.toBuilder();
        }

        private InferenceCalculatorOptions() {
        }

        public static final class Delegate extends GeneratedMessageLite<Delegate, Builder> implements DelegateOrBuilder {
            private static final Delegate DEFAULT_INSTANCE;
            public static final int GPU_FIELD_NUMBER = 2;
            public static final int NNAPI_FIELD_NUMBER = 3;
            private static volatile Parser<Delegate> PARSER = null;
            public static final int TFLITE_FIELD_NUMBER = 1;
            public static final int XNNPACK_FIELD_NUMBER = 4;
            private int delegateCase_ = 0;
            private Object delegate_;

            public interface GpuOrBuilder extends MessageLiteOrBuilder {
                boolean getAllowPrecisionLoss();

                Gpu.Api getApi();

                Gpu.CacheWritingBehavior getCacheWritingBehavior();

                String getCachedKernelPath();

                ByteString getCachedKernelPathBytes();

                String getModelToken();

                ByteString getModelTokenBytes();

                String getSerializedModelDir();

                ByteString getSerializedModelDirBytes();

                Gpu.InferenceUsage getUsage();

                boolean getUseAdvancedGpuApi();

                boolean hasAllowPrecisionLoss();

                boolean hasApi();

                boolean hasCacheWritingBehavior();

                boolean hasCachedKernelPath();

                boolean hasModelToken();

                boolean hasSerializedModelDir();

                boolean hasUsage();

                boolean hasUseAdvancedGpuApi();
            }

            public interface NnapiOrBuilder extends MessageLiteOrBuilder {
                String getAcceleratorName();

                ByteString getAcceleratorNameBytes();

                String getCacheDir();

                ByteString getCacheDirBytes();

                String getModelToken();

                ByteString getModelTokenBytes();

                boolean hasAcceleratorName();

                boolean hasCacheDir();

                boolean hasModelToken();
            }

            public interface TfLiteOrBuilder extends MessageLiteOrBuilder {
            }

            public interface XnnpackOrBuilder extends MessageLiteOrBuilder {
                boolean getEnableZeroCopyTensorIo();

                int getNumThreads();

                boolean getSlowConsistentArithmetic();

                boolean hasEnableZeroCopyTensorIo();

                boolean hasNumThreads();

                boolean hasSlowConsistentArithmetic();
            }

            @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
            public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                return super.getDefaultInstanceForType();
            }

            @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
            public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                return super.newBuilderForType();
            }

            @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
            public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                return super.toBuilder();
            }

            private Delegate() {
            }

            public static final class TfLite extends GeneratedMessageLite<TfLite, Builder> implements TfLiteOrBuilder {
                private static final TfLite DEFAULT_INSTANCE;
                private static volatile Parser<TfLite> PARSER;

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                    return super.newBuilderForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                    return super.toBuilder();
                }

                private TfLite() {
                }

                public static TfLite parseFrom(ByteBuffer byteBuffer) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
                }

                public static TfLite parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
                }

                public static TfLite parseFrom(ByteString byteString) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
                }

                public static TfLite parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
                }

                public static TfLite parseFrom(byte[] bArr) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
                }

                public static TfLite parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
                }

                public static TfLite parseFrom(InputStream inputStream) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static TfLite parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static TfLite parseDelimitedFrom(InputStream inputStream) {
                    return (TfLite) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static TfLite parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TfLite) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static TfLite parseFrom(CodedInputStream codedInputStream) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
                }

                public static TfLite parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TfLite) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
                }

                public static Builder newBuilder() {
                    return (Builder) DEFAULT_INSTANCE.createBuilder();
                }

                public static Builder newBuilder(TfLite tfLite) {
                    return (Builder) DEFAULT_INSTANCE.createBuilder(tfLite);
                }

                public static final class Builder extends GeneratedMessageLite.Builder<TfLite, Builder> implements TfLiteOrBuilder {
                    /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                        this();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite build() {
                        return super.build();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                        return super.buildPartial();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                        return super.clear();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ Object mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                    public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                        return super.getDefaultInstanceForType();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                        return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                        return super.mergeFrom(byteString);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(byteString, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                        return super.mergeFrom(codedInputStream);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                        return super.mergeFrom(messageLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                        return super.mergeFrom(inputStream);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(inputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                        return super.mergeFrom(bArr);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, extensionRegistryLite);
                    }

                    private Builder() {
                        super(TfLite.DEFAULT_INSTANCE);
                    }
                }

                @Override // com.google.protobuf.GeneratedMessageLite
                protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                    Parser defaultInstanceBasedParser;
                    AnonymousClass1 anonymousClass1 = null;
                    switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                        case 1:
                            return new TfLite();
                        case 2:
                            return new Builder(anonymousClass1);
                        case 3:
                            return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0000", null);
                        case 4:
                            return DEFAULT_INSTANCE;
                        case 5:
                            Parser<TfLite> parser = PARSER;
                            if (parser != null) {
                                return parser;
                            }
                            synchronized (TfLite.class) {
                                try {
                                    defaultInstanceBasedParser = PARSER;
                                    if (defaultInstanceBasedParser == null) {
                                        defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                        PARSER = defaultInstanceBasedParser;
                                    }
                                } catch (Throwable th) {
                                    throw th;
                                }
                                break;
                            }
                            return defaultInstanceBasedParser;
                        case 6:
                            return (byte) 1;
                        case 7:
                            return null;
                        default:
                            throw new UnsupportedOperationException();
                    }
                }

                static {
                    TfLite tfLite = new TfLite();
                    DEFAULT_INSTANCE = tfLite;
                    GeneratedMessageLite.registerDefaultInstance(TfLite.class, tfLite);
                }

                public static TfLite getDefaultInstance() {
                    return DEFAULT_INSTANCE;
                }

                public static Parser<TfLite> parser() {
                    return DEFAULT_INSTANCE.getParserForType();
                }
            }

            public static final class Gpu extends GeneratedMessageLite<Gpu, Builder> implements GpuOrBuilder {
                public static final int ALLOW_PRECISION_LOSS_FIELD_NUMBER = 3;
                public static final int API_FIELD_NUMBER = 4;
                public static final int CACHED_KERNEL_PATH_FIELD_NUMBER = 2;
                public static final int CACHE_WRITING_BEHAVIOR_FIELD_NUMBER = 10;
                private static final Gpu DEFAULT_INSTANCE;
                public static final int MODEL_TOKEN_FIELD_NUMBER = 8;
                private static volatile Parser<Gpu> PARSER = null;
                public static final int SERIALIZED_MODEL_DIR_FIELD_NUMBER = 7;
                public static final int USAGE_FIELD_NUMBER = 5;
                public static final int USE_ADVANCED_GPU_API_FIELD_NUMBER = 1;
                private int api_;
                private int bitField0_;
                private boolean useAdvancedGpuApi_;
                private boolean allowPrecisionLoss_ = true;
                private String cachedKernelPath_ = "";
                private String serializedModelDir_ = "";
                private int cacheWritingBehavior_ = 2;
                private String modelToken_ = "";
                private int usage_ = 2;

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                    return super.newBuilderForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                    return super.toBuilder();
                }

                private Gpu() {
                }

                public enum Api implements Internal.EnumLite {
                    ANY(0),
                    OPENGL(1),
                    OPENCL(2);

                    public static final int ANY_VALUE = 0;
                    public static final int OPENCL_VALUE = 2;
                    public static final int OPENGL_VALUE = 1;
                    private static final Internal.EnumLiteMap<Api> internalValueMap = new Internal.EnumLiteMap<Api>() { // from class: com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.Gpu.Api.1
                        @Override // com.google.protobuf.Internal.EnumLiteMap
                        public Api findValueByNumber(int i) {
                            return Api.forNumber(i);
                        }
                    };
                    private final int value;

                    @Override // com.google.protobuf.Internal.EnumLite
                    public final int getNumber() {
                        return this.value;
                    }

                    @Deprecated
                    public static Api valueOf(int i) {
                        return forNumber(i);
                    }

                    public static Api forNumber(int i) {
                        if (i == 0) {
                            return ANY;
                        }
                        if (i == 1) {
                            return OPENGL;
                        }
                        if (i != 2) {
                            return null;
                        }
                        return OPENCL;
                    }

                    public static Internal.EnumLiteMap<Api> internalGetValueMap() {
                        return internalValueMap;
                    }

                    public static Internal.EnumVerifier internalGetVerifier() {
                        return ApiVerifier.INSTANCE;
                    }

                    private static final class ApiVerifier implements Internal.EnumVerifier {
                        static final Internal.EnumVerifier INSTANCE = new ApiVerifier();

                        private ApiVerifier() {
                        }

                        @Override // com.google.protobuf.Internal.EnumVerifier
                        public boolean isInRange(int i) {
                            return Api.forNumber(i) != null;
                        }
                    }

                    Api(int i) {
                        this.value = i;
                    }
                }

                public enum CacheWritingBehavior implements Internal.EnumLite {
                    NO_WRITE(0),
                    TRY_WRITE(1),
                    WRITE_OR_ERROR(2);

                    public static final int NO_WRITE_VALUE = 0;
                    public static final int TRY_WRITE_VALUE = 1;
                    public static final int WRITE_OR_ERROR_VALUE = 2;
                    private static final Internal.EnumLiteMap<CacheWritingBehavior> internalValueMap = new Internal.EnumLiteMap<CacheWritingBehavior>() { // from class: com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.Gpu.CacheWritingBehavior.1
                        @Override // com.google.protobuf.Internal.EnumLiteMap
                        public CacheWritingBehavior findValueByNumber(int i) {
                            return CacheWritingBehavior.forNumber(i);
                        }
                    };
                    private final int value;

                    @Override // com.google.protobuf.Internal.EnumLite
                    public final int getNumber() {
                        return this.value;
                    }

                    @Deprecated
                    public static CacheWritingBehavior valueOf(int i) {
                        return forNumber(i);
                    }

                    public static CacheWritingBehavior forNumber(int i) {
                        if (i == 0) {
                            return NO_WRITE;
                        }
                        if (i == 1) {
                            return TRY_WRITE;
                        }
                        if (i != 2) {
                            return null;
                        }
                        return WRITE_OR_ERROR;
                    }

                    public static Internal.EnumLiteMap<CacheWritingBehavior> internalGetValueMap() {
                        return internalValueMap;
                    }

                    public static Internal.EnumVerifier internalGetVerifier() {
                        return CacheWritingBehaviorVerifier.INSTANCE;
                    }

                    private static final class CacheWritingBehaviorVerifier implements Internal.EnumVerifier {
                        static final Internal.EnumVerifier INSTANCE = new CacheWritingBehaviorVerifier();

                        private CacheWritingBehaviorVerifier() {
                        }

                        @Override // com.google.protobuf.Internal.EnumVerifier
                        public boolean isInRange(int i) {
                            return CacheWritingBehavior.forNumber(i) != null;
                        }
                    }

                    CacheWritingBehavior(int i) {
                        this.value = i;
                    }
                }

                public enum InferenceUsage implements Internal.EnumLite {
                    UNSPECIFIED(0),
                    FAST_SINGLE_ANSWER(1),
                    SUSTAINED_SPEED(2);

                    public static final int FAST_SINGLE_ANSWER_VALUE = 1;
                    public static final int SUSTAINED_SPEED_VALUE = 2;
                    public static final int UNSPECIFIED_VALUE = 0;
                    private static final Internal.EnumLiteMap<InferenceUsage> internalValueMap = new Internal.EnumLiteMap<InferenceUsage>() { // from class: com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.Gpu.InferenceUsage.1
                        @Override // com.google.protobuf.Internal.EnumLiteMap
                        public InferenceUsage findValueByNumber(int i) {
                            return InferenceUsage.forNumber(i);
                        }
                    };
                    private final int value;

                    @Override // com.google.protobuf.Internal.EnumLite
                    public final int getNumber() {
                        return this.value;
                    }

                    @Deprecated
                    public static InferenceUsage valueOf(int i) {
                        return forNumber(i);
                    }

                    public static InferenceUsage forNumber(int i) {
                        if (i == 0) {
                            return UNSPECIFIED;
                        }
                        if (i == 1) {
                            return FAST_SINGLE_ANSWER;
                        }
                        if (i != 2) {
                            return null;
                        }
                        return SUSTAINED_SPEED;
                    }

                    public static Internal.EnumLiteMap<InferenceUsage> internalGetValueMap() {
                        return internalValueMap;
                    }

                    public static Internal.EnumVerifier internalGetVerifier() {
                        return InferenceUsageVerifier.INSTANCE;
                    }

                    private static final class InferenceUsageVerifier implements Internal.EnumVerifier {
                        static final Internal.EnumVerifier INSTANCE = new InferenceUsageVerifier();

                        private InferenceUsageVerifier() {
                        }

                        @Override // com.google.protobuf.Internal.EnumVerifier
                        public boolean isInRange(int i) {
                            return InferenceUsage.forNumber(i) != null;
                        }
                    }

                    InferenceUsage(int i) {
                        this.value = i;
                    }
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasUseAdvancedGpuApi() {
                    return (this.bitField0_ & 1) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean getUseAdvancedGpuApi() {
                    return this.useAdvancedGpuApi_;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setUseAdvancedGpuApi(boolean z) {
                    this.bitField0_ |= 1;
                    this.useAdvancedGpuApi_ = z;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearUseAdvancedGpuApi() {
                    this.bitField0_ &= -2;
                    this.useAdvancedGpuApi_ = false;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasApi() {
                    return (this.bitField0_ & 2) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public Api getApi() {
                    Api apiForNumber = Api.forNumber(this.api_);
                    return apiForNumber == null ? Api.ANY : apiForNumber;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setApi(Api api) {
                    this.api_ = api.getNumber();
                    this.bitField0_ |= 2;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearApi() {
                    this.bitField0_ &= -3;
                    this.api_ = 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasAllowPrecisionLoss() {
                    return (this.bitField0_ & 4) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean getAllowPrecisionLoss() {
                    return this.allowPrecisionLoss_;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setAllowPrecisionLoss(boolean z) {
                    this.bitField0_ |= 4;
                    this.allowPrecisionLoss_ = z;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearAllowPrecisionLoss() {
                    this.bitField0_ &= -5;
                    this.allowPrecisionLoss_ = true;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasCachedKernelPath() {
                    return (this.bitField0_ & 8) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public String getCachedKernelPath() {
                    return this.cachedKernelPath_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public ByteString getCachedKernelPathBytes() {
                    return ByteString.copyFromUtf8(this.cachedKernelPath_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setCachedKernelPath(String str) {
                    str.getClass();
                    this.bitField0_ |= 8;
                    this.cachedKernelPath_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearCachedKernelPath() {
                    this.bitField0_ &= -9;
                    this.cachedKernelPath_ = getDefaultInstance().getCachedKernelPath();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setCachedKernelPathBytes(ByteString byteString) {
                    this.cachedKernelPath_ = byteString.toStringUtf8();
                    this.bitField0_ |= 8;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasSerializedModelDir() {
                    return (this.bitField0_ & 16) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public String getSerializedModelDir() {
                    return this.serializedModelDir_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public ByteString getSerializedModelDirBytes() {
                    return ByteString.copyFromUtf8(this.serializedModelDir_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setSerializedModelDir(String str) {
                    str.getClass();
                    this.bitField0_ |= 16;
                    this.serializedModelDir_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearSerializedModelDir() {
                    this.bitField0_ &= -17;
                    this.serializedModelDir_ = getDefaultInstance().getSerializedModelDir();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setSerializedModelDirBytes(ByteString byteString) {
                    this.serializedModelDir_ = byteString.toStringUtf8();
                    this.bitField0_ |= 16;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasCacheWritingBehavior() {
                    return (this.bitField0_ & 32) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public CacheWritingBehavior getCacheWritingBehavior() {
                    CacheWritingBehavior cacheWritingBehaviorForNumber = CacheWritingBehavior.forNumber(this.cacheWritingBehavior_);
                    return cacheWritingBehaviorForNumber == null ? CacheWritingBehavior.WRITE_OR_ERROR : cacheWritingBehaviorForNumber;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setCacheWritingBehavior(CacheWritingBehavior cacheWritingBehavior) {
                    this.cacheWritingBehavior_ = cacheWritingBehavior.getNumber();
                    this.bitField0_ |= 32;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearCacheWritingBehavior() {
                    this.bitField0_ &= -33;
                    this.cacheWritingBehavior_ = 2;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasModelToken() {
                    return (this.bitField0_ & 64) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public String getModelToken() {
                    return this.modelToken_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public ByteString getModelTokenBytes() {
                    return ByteString.copyFromUtf8(this.modelToken_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setModelToken(String str) {
                    str.getClass();
                    this.bitField0_ |= 64;
                    this.modelToken_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearModelToken() {
                    this.bitField0_ &= -65;
                    this.modelToken_ = getDefaultInstance().getModelToken();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setModelTokenBytes(ByteString byteString) {
                    this.modelToken_ = byteString.toStringUtf8();
                    this.bitField0_ |= 64;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public boolean hasUsage() {
                    return (this.bitField0_ & 128) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                public InferenceUsage getUsage() {
                    InferenceUsage inferenceUsageForNumber = InferenceUsage.forNumber(this.usage_);
                    return inferenceUsageForNumber == null ? InferenceUsage.SUSTAINED_SPEED : inferenceUsageForNumber;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setUsage(InferenceUsage inferenceUsage) {
                    this.usage_ = inferenceUsage.getNumber();
                    this.bitField0_ |= 128;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearUsage() {
                    this.bitField0_ &= -129;
                    this.usage_ = 2;
                }

                public static Gpu parseFrom(ByteBuffer byteBuffer) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
                }

                public static Gpu parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
                }

                public static Gpu parseFrom(ByteString byteString) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
                }

                public static Gpu parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
                }

                public static Gpu parseFrom(byte[] bArr) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
                }

                public static Gpu parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
                }

                public static Gpu parseFrom(InputStream inputStream) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static Gpu parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static Gpu parseDelimitedFrom(InputStream inputStream) {
                    return (Gpu) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static Gpu parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Gpu) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static Gpu parseFrom(CodedInputStream codedInputStream) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
                }

                public static Gpu parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Gpu) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
                }

                public static Builder newBuilder() {
                    return (Builder) DEFAULT_INSTANCE.createBuilder();
                }

                public static Builder newBuilder(Gpu gpu) {
                    return (Builder) DEFAULT_INSTANCE.createBuilder(gpu);
                }

                public static final class Builder extends GeneratedMessageLite.Builder<Gpu, Builder> implements GpuOrBuilder {
                    /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                        this();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite build() {
                        return super.build();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                        return super.buildPartial();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                        return super.clear();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ Object mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                    public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                        return super.getDefaultInstanceForType();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                        return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                        return super.mergeFrom(byteString);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(byteString, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                        return super.mergeFrom(codedInputStream);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                        return super.mergeFrom(messageLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                        return super.mergeFrom(inputStream);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(inputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                        return super.mergeFrom(bArr);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, extensionRegistryLite);
                    }

                    private Builder() {
                        super(Gpu.DEFAULT_INSTANCE);
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasUseAdvancedGpuApi() {
                        return ((Gpu) this.instance).hasUseAdvancedGpuApi();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean getUseAdvancedGpuApi() {
                        return ((Gpu) this.instance).getUseAdvancedGpuApi();
                    }

                    public Builder setUseAdvancedGpuApi(boolean z) {
                        copyOnWrite();
                        ((Gpu) this.instance).setUseAdvancedGpuApi(z);
                        return this;
                    }

                    public Builder clearUseAdvancedGpuApi() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearUseAdvancedGpuApi();
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasApi() {
                        return ((Gpu) this.instance).hasApi();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public Api getApi() {
                        return ((Gpu) this.instance).getApi();
                    }

                    public Builder setApi(Api api) {
                        copyOnWrite();
                        ((Gpu) this.instance).setApi(api);
                        return this;
                    }

                    public Builder clearApi() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearApi();
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasAllowPrecisionLoss() {
                        return ((Gpu) this.instance).hasAllowPrecisionLoss();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean getAllowPrecisionLoss() {
                        return ((Gpu) this.instance).getAllowPrecisionLoss();
                    }

                    public Builder setAllowPrecisionLoss(boolean z) {
                        copyOnWrite();
                        ((Gpu) this.instance).setAllowPrecisionLoss(z);
                        return this;
                    }

                    public Builder clearAllowPrecisionLoss() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearAllowPrecisionLoss();
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasCachedKernelPath() {
                        return ((Gpu) this.instance).hasCachedKernelPath();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public String getCachedKernelPath() {
                        return ((Gpu) this.instance).getCachedKernelPath();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public ByteString getCachedKernelPathBytes() {
                        return ((Gpu) this.instance).getCachedKernelPathBytes();
                    }

                    public Builder setCachedKernelPath(String str) {
                        copyOnWrite();
                        ((Gpu) this.instance).setCachedKernelPath(str);
                        return this;
                    }

                    public Builder clearCachedKernelPath() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearCachedKernelPath();
                        return this;
                    }

                    public Builder setCachedKernelPathBytes(ByteString byteString) {
                        copyOnWrite();
                        ((Gpu) this.instance).setCachedKernelPathBytes(byteString);
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasSerializedModelDir() {
                        return ((Gpu) this.instance).hasSerializedModelDir();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public String getSerializedModelDir() {
                        return ((Gpu) this.instance).getSerializedModelDir();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public ByteString getSerializedModelDirBytes() {
                        return ((Gpu) this.instance).getSerializedModelDirBytes();
                    }

                    public Builder setSerializedModelDir(String str) {
                        copyOnWrite();
                        ((Gpu) this.instance).setSerializedModelDir(str);
                        return this;
                    }

                    public Builder clearSerializedModelDir() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearSerializedModelDir();
                        return this;
                    }

                    public Builder setSerializedModelDirBytes(ByteString byteString) {
                        copyOnWrite();
                        ((Gpu) this.instance).setSerializedModelDirBytes(byteString);
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasCacheWritingBehavior() {
                        return ((Gpu) this.instance).hasCacheWritingBehavior();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public CacheWritingBehavior getCacheWritingBehavior() {
                        return ((Gpu) this.instance).getCacheWritingBehavior();
                    }

                    public Builder setCacheWritingBehavior(CacheWritingBehavior cacheWritingBehavior) {
                        copyOnWrite();
                        ((Gpu) this.instance).setCacheWritingBehavior(cacheWritingBehavior);
                        return this;
                    }

                    public Builder clearCacheWritingBehavior() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearCacheWritingBehavior();
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasModelToken() {
                        return ((Gpu) this.instance).hasModelToken();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public String getModelToken() {
                        return ((Gpu) this.instance).getModelToken();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public ByteString getModelTokenBytes() {
                        return ((Gpu) this.instance).getModelTokenBytes();
                    }

                    public Builder setModelToken(String str) {
                        copyOnWrite();
                        ((Gpu) this.instance).setModelToken(str);
                        return this;
                    }

                    public Builder clearModelToken() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearModelToken();
                        return this;
                    }

                    public Builder setModelTokenBytes(ByteString byteString) {
                        copyOnWrite();
                        ((Gpu) this.instance).setModelTokenBytes(byteString);
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public boolean hasUsage() {
                        return ((Gpu) this.instance).hasUsage();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.GpuOrBuilder
                    public InferenceUsage getUsage() {
                        return ((Gpu) this.instance).getUsage();
                    }

                    public Builder setUsage(InferenceUsage inferenceUsage) {
                        copyOnWrite();
                        ((Gpu) this.instance).setUsage(inferenceUsage);
                        return this;
                    }

                    public Builder clearUsage() {
                        copyOnWrite();
                        ((Gpu) this.instance).clearUsage();
                        return this;
                    }
                }

                @Override // com.google.protobuf.GeneratedMessageLite
                protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                    Parser defaultInstanceBasedParser;
                    AnonymousClass1 anonymousClass1 = null;
                    switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                        case 1:
                            return new Gpu();
                        case 2:
                            return new Builder(anonymousClass1);
                        case 3:
                            return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\b\u0000\u0001\u0001\n\b\u0000\u0000\u0000\u0001ဇ\u0000\u0002ဈ\u0003\u0003ဇ\u0002\u0004᠌\u0001\u0005᠌\u0007\u0007ဈ\u0004\bဈ\u0006\n᠌\u0005", new Object[]{"bitField0_", "useAdvancedGpuApi_", "cachedKernelPath_", "allowPrecisionLoss_", "api_", Api.internalGetVerifier(), "usage_", InferenceUsage.internalGetVerifier(), "serializedModelDir_", "modelToken_", "cacheWritingBehavior_", CacheWritingBehavior.internalGetVerifier()});
                        case 4:
                            return DEFAULT_INSTANCE;
                        case 5:
                            Parser<Gpu> parser = PARSER;
                            if (parser != null) {
                                return parser;
                            }
                            synchronized (Gpu.class) {
                                try {
                                    defaultInstanceBasedParser = PARSER;
                                    if (defaultInstanceBasedParser == null) {
                                        defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                        PARSER = defaultInstanceBasedParser;
                                    }
                                } catch (Throwable th) {
                                    throw th;
                                }
                                break;
                            }
                            return defaultInstanceBasedParser;
                        case 6:
                            return (byte) 1;
                        case 7:
                            return null;
                        default:
                            throw new UnsupportedOperationException();
                    }
                }

                static {
                    Gpu gpu = new Gpu();
                    DEFAULT_INSTANCE = gpu;
                    GeneratedMessageLite.registerDefaultInstance(Gpu.class, gpu);
                }

                public static Gpu getDefaultInstance() {
                    return DEFAULT_INSTANCE;
                }

                public static Parser<Gpu> parser() {
                    return DEFAULT_INSTANCE.getParserForType();
                }
            }

            public static final class Nnapi extends GeneratedMessageLite<Nnapi, Builder> implements NnapiOrBuilder {
                public static final int ACCELERATOR_NAME_FIELD_NUMBER = 3;
                public static final int CACHE_DIR_FIELD_NUMBER = 1;
                private static final Nnapi DEFAULT_INSTANCE;
                public static final int MODEL_TOKEN_FIELD_NUMBER = 2;
                private static volatile Parser<Nnapi> PARSER;
                private int bitField0_;
                private String cacheDir_ = "";
                private String modelToken_ = "";
                private String acceleratorName_ = "";

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                    return super.newBuilderForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                    return super.toBuilder();
                }

                private Nnapi() {
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public boolean hasCacheDir() {
                    return (this.bitField0_ & 1) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public String getCacheDir() {
                    return this.cacheDir_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public ByteString getCacheDirBytes() {
                    return ByteString.copyFromUtf8(this.cacheDir_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setCacheDir(String str) {
                    str.getClass();
                    this.bitField0_ |= 1;
                    this.cacheDir_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearCacheDir() {
                    this.bitField0_ &= -2;
                    this.cacheDir_ = getDefaultInstance().getCacheDir();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setCacheDirBytes(ByteString byteString) {
                    this.cacheDir_ = byteString.toStringUtf8();
                    this.bitField0_ |= 1;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public boolean hasModelToken() {
                    return (this.bitField0_ & 2) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public String getModelToken() {
                    return this.modelToken_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public ByteString getModelTokenBytes() {
                    return ByteString.copyFromUtf8(this.modelToken_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setModelToken(String str) {
                    str.getClass();
                    this.bitField0_ |= 2;
                    this.modelToken_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearModelToken() {
                    this.bitField0_ &= -3;
                    this.modelToken_ = getDefaultInstance().getModelToken();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setModelTokenBytes(ByteString byteString) {
                    this.modelToken_ = byteString.toStringUtf8();
                    this.bitField0_ |= 2;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public boolean hasAcceleratorName() {
                    return (this.bitField0_ & 4) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public String getAcceleratorName() {
                    return this.acceleratorName_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                public ByteString getAcceleratorNameBytes() {
                    return ByteString.copyFromUtf8(this.acceleratorName_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setAcceleratorName(String str) {
                    str.getClass();
                    this.bitField0_ |= 4;
                    this.acceleratorName_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearAcceleratorName() {
                    this.bitField0_ &= -5;
                    this.acceleratorName_ = getDefaultInstance().getAcceleratorName();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setAcceleratorNameBytes(ByteString byteString) {
                    this.acceleratorName_ = byteString.toStringUtf8();
                    this.bitField0_ |= 4;
                }

                public static Nnapi parseFrom(ByteBuffer byteBuffer) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
                }

                public static Nnapi parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
                }

                public static Nnapi parseFrom(ByteString byteString) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
                }

                public static Nnapi parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
                }

                public static Nnapi parseFrom(byte[] bArr) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
                }

                public static Nnapi parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
                }

                public static Nnapi parseFrom(InputStream inputStream) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static Nnapi parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static Nnapi parseDelimitedFrom(InputStream inputStream) {
                    return (Nnapi) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static Nnapi parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Nnapi) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static Nnapi parseFrom(CodedInputStream codedInputStream) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
                }

                public static Nnapi parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Nnapi) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
                }

                public static Builder newBuilder() {
                    return (Builder) DEFAULT_INSTANCE.createBuilder();
                }

                public static Builder newBuilder(Nnapi nnapi) {
                    return (Builder) DEFAULT_INSTANCE.createBuilder(nnapi);
                }

                public static final class Builder extends GeneratedMessageLite.Builder<Nnapi, Builder> implements NnapiOrBuilder {
                    /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                        this();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite build() {
                        return super.build();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                        return super.buildPartial();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                        return super.clear();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ Object mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                    public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                        return super.getDefaultInstanceForType();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                        return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                        return super.mergeFrom(byteString);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(byteString, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                        return super.mergeFrom(codedInputStream);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                        return super.mergeFrom(messageLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                        return super.mergeFrom(inputStream);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(inputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                        return super.mergeFrom(bArr);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, extensionRegistryLite);
                    }

                    private Builder() {
                        super(Nnapi.DEFAULT_INSTANCE);
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public boolean hasCacheDir() {
                        return ((Nnapi) this.instance).hasCacheDir();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public String getCacheDir() {
                        return ((Nnapi) this.instance).getCacheDir();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public ByteString getCacheDirBytes() {
                        return ((Nnapi) this.instance).getCacheDirBytes();
                    }

                    public Builder setCacheDir(String str) {
                        copyOnWrite();
                        ((Nnapi) this.instance).setCacheDir(str);
                        return this;
                    }

                    public Builder clearCacheDir() {
                        copyOnWrite();
                        ((Nnapi) this.instance).clearCacheDir();
                        return this;
                    }

                    public Builder setCacheDirBytes(ByteString byteString) {
                        copyOnWrite();
                        ((Nnapi) this.instance).setCacheDirBytes(byteString);
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public boolean hasModelToken() {
                        return ((Nnapi) this.instance).hasModelToken();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public String getModelToken() {
                        return ((Nnapi) this.instance).getModelToken();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public ByteString getModelTokenBytes() {
                        return ((Nnapi) this.instance).getModelTokenBytes();
                    }

                    public Builder setModelToken(String str) {
                        copyOnWrite();
                        ((Nnapi) this.instance).setModelToken(str);
                        return this;
                    }

                    public Builder clearModelToken() {
                        copyOnWrite();
                        ((Nnapi) this.instance).clearModelToken();
                        return this;
                    }

                    public Builder setModelTokenBytes(ByteString byteString) {
                        copyOnWrite();
                        ((Nnapi) this.instance).setModelTokenBytes(byteString);
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public boolean hasAcceleratorName() {
                        return ((Nnapi) this.instance).hasAcceleratorName();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public String getAcceleratorName() {
                        return ((Nnapi) this.instance).getAcceleratorName();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.NnapiOrBuilder
                    public ByteString getAcceleratorNameBytes() {
                        return ((Nnapi) this.instance).getAcceleratorNameBytes();
                    }

                    public Builder setAcceleratorName(String str) {
                        copyOnWrite();
                        ((Nnapi) this.instance).setAcceleratorName(str);
                        return this;
                    }

                    public Builder clearAcceleratorName() {
                        copyOnWrite();
                        ((Nnapi) this.instance).clearAcceleratorName();
                        return this;
                    }

                    public Builder setAcceleratorNameBytes(ByteString byteString) {
                        copyOnWrite();
                        ((Nnapi) this.instance).setAcceleratorNameBytes(byteString);
                        return this;
                    }
                }

                @Override // com.google.protobuf.GeneratedMessageLite
                protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                    Parser defaultInstanceBasedParser;
                    AnonymousClass1 anonymousClass1 = null;
                    switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                        case 1:
                            return new Nnapi();
                        case 2:
                            return new Builder(anonymousClass1);
                        case 3:
                            return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001ဈ\u0000\u0002ဈ\u0001\u0003ဈ\u0002", new Object[]{"bitField0_", "cacheDir_", "modelToken_", "acceleratorName_"});
                        case 4:
                            return DEFAULT_INSTANCE;
                        case 5:
                            Parser<Nnapi> parser = PARSER;
                            if (parser != null) {
                                return parser;
                            }
                            synchronized (Nnapi.class) {
                                try {
                                    defaultInstanceBasedParser = PARSER;
                                    if (defaultInstanceBasedParser == null) {
                                        defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                        PARSER = defaultInstanceBasedParser;
                                    }
                                } catch (Throwable th) {
                                    throw th;
                                }
                                break;
                            }
                            return defaultInstanceBasedParser;
                        case 6:
                            return (byte) 1;
                        case 7:
                            return null;
                        default:
                            throw new UnsupportedOperationException();
                    }
                }

                static {
                    Nnapi nnapi = new Nnapi();
                    DEFAULT_INSTANCE = nnapi;
                    GeneratedMessageLite.registerDefaultInstance(Nnapi.class, nnapi);
                }

                public static Nnapi getDefaultInstance() {
                    return DEFAULT_INSTANCE;
                }

                public static Parser<Nnapi> parser() {
                    return DEFAULT_INSTANCE.getParserForType();
                }
            }

            public static final class Xnnpack extends GeneratedMessageLite<Xnnpack, Builder> implements XnnpackOrBuilder {
                private static final Xnnpack DEFAULT_INSTANCE;
                public static final int ENABLE_ZERO_COPY_TENSOR_IO_FIELD_NUMBER = 7;
                public static final int NUM_THREADS_FIELD_NUMBER = 1;
                private static volatile Parser<Xnnpack> PARSER = null;
                public static final int SLOW_CONSISTENT_ARITHMETIC_FIELD_NUMBER = 8;
                private int bitField0_;
                private boolean enableZeroCopyTensorIo_;
                private int numThreads_ = -1;
                private boolean slowConsistentArithmetic_;

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                    return super.newBuilderForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                    return super.toBuilder();
                }

                private Xnnpack() {
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                public boolean hasNumThreads() {
                    return (this.bitField0_ & 1) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                public int getNumThreads() {
                    return this.numThreads_;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setNumThreads(int i) {
                    this.bitField0_ |= 1;
                    this.numThreads_ = i;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearNumThreads() {
                    this.bitField0_ &= -2;
                    this.numThreads_ = -1;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                public boolean hasEnableZeroCopyTensorIo() {
                    return (this.bitField0_ & 2) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                public boolean getEnableZeroCopyTensorIo() {
                    return this.enableZeroCopyTensorIo_;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setEnableZeroCopyTensorIo(boolean z) {
                    this.bitField0_ |= 2;
                    this.enableZeroCopyTensorIo_ = z;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearEnableZeroCopyTensorIo() {
                    this.bitField0_ &= -3;
                    this.enableZeroCopyTensorIo_ = false;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                public boolean hasSlowConsistentArithmetic() {
                    return (this.bitField0_ & 4) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                public boolean getSlowConsistentArithmetic() {
                    return this.slowConsistentArithmetic_;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setSlowConsistentArithmetic(boolean z) {
                    this.bitField0_ |= 4;
                    this.slowConsistentArithmetic_ = z;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearSlowConsistentArithmetic() {
                    this.bitField0_ &= -5;
                    this.slowConsistentArithmetic_ = false;
                }

                public static Xnnpack parseFrom(ByteBuffer byteBuffer) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
                }

                public static Xnnpack parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
                }

                public static Xnnpack parseFrom(ByteString byteString) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
                }

                public static Xnnpack parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
                }

                public static Xnnpack parseFrom(byte[] bArr) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
                }

                public static Xnnpack parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
                }

                public static Xnnpack parseFrom(InputStream inputStream) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static Xnnpack parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static Xnnpack parseDelimitedFrom(InputStream inputStream) {
                    return (Xnnpack) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static Xnnpack parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Xnnpack) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static Xnnpack parseFrom(CodedInputStream codedInputStream) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
                }

                public static Xnnpack parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (Xnnpack) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
                }

                public static Builder newBuilder() {
                    return (Builder) DEFAULT_INSTANCE.createBuilder();
                }

                public static Builder newBuilder(Xnnpack xnnpack) {
                    return (Builder) DEFAULT_INSTANCE.createBuilder(xnnpack);
                }

                public static final class Builder extends GeneratedMessageLite.Builder<Xnnpack, Builder> implements XnnpackOrBuilder {
                    /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                        this();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite build() {
                        return super.build();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                        return super.buildPartial();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                        return super.clear();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ Object mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                    public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                        return super.getDefaultInstanceForType();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                        return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                        return super.mergeFrom(byteString);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(byteString, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                        return super.mergeFrom(codedInputStream);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                        return super.mergeFrom(messageLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                        return super.mergeFrom(inputStream);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(inputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                        return super.mergeFrom(bArr);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, extensionRegistryLite);
                    }

                    private Builder() {
                        super(Xnnpack.DEFAULT_INSTANCE);
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                    public boolean hasNumThreads() {
                        return ((Xnnpack) this.instance).hasNumThreads();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                    public int getNumThreads() {
                        return ((Xnnpack) this.instance).getNumThreads();
                    }

                    public Builder setNumThreads(int i) {
                        copyOnWrite();
                        ((Xnnpack) this.instance).setNumThreads(i);
                        return this;
                    }

                    public Builder clearNumThreads() {
                        copyOnWrite();
                        ((Xnnpack) this.instance).clearNumThreads();
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                    public boolean hasEnableZeroCopyTensorIo() {
                        return ((Xnnpack) this.instance).hasEnableZeroCopyTensorIo();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                    public boolean getEnableZeroCopyTensorIo() {
                        return ((Xnnpack) this.instance).getEnableZeroCopyTensorIo();
                    }

                    public Builder setEnableZeroCopyTensorIo(boolean z) {
                        copyOnWrite();
                        ((Xnnpack) this.instance).setEnableZeroCopyTensorIo(z);
                        return this;
                    }

                    public Builder clearEnableZeroCopyTensorIo() {
                        copyOnWrite();
                        ((Xnnpack) this.instance).clearEnableZeroCopyTensorIo();
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                    public boolean hasSlowConsistentArithmetic() {
                        return ((Xnnpack) this.instance).hasSlowConsistentArithmetic();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.XnnpackOrBuilder
                    public boolean getSlowConsistentArithmetic() {
                        return ((Xnnpack) this.instance).getSlowConsistentArithmetic();
                    }

                    public Builder setSlowConsistentArithmetic(boolean z) {
                        copyOnWrite();
                        ((Xnnpack) this.instance).setSlowConsistentArithmetic(z);
                        return this;
                    }

                    public Builder clearSlowConsistentArithmetic() {
                        copyOnWrite();
                        ((Xnnpack) this.instance).clearSlowConsistentArithmetic();
                        return this;
                    }
                }

                @Override // com.google.protobuf.GeneratedMessageLite
                protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                    Parser defaultInstanceBasedParser;
                    AnonymousClass1 anonymousClass1 = null;
                    switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                        case 1:
                            return new Xnnpack();
                        case 2:
                            return new Builder(anonymousClass1);
                        case 3:
                            return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\b\u0003\u0000\u0000\u0000\u0001င\u0000\u0007ဇ\u0001\bဇ\u0002", new Object[]{"bitField0_", "numThreads_", "enableZeroCopyTensorIo_", "slowConsistentArithmetic_"});
                        case 4:
                            return DEFAULT_INSTANCE;
                        case 5:
                            Parser<Xnnpack> parser = PARSER;
                            if (parser != null) {
                                return parser;
                            }
                            synchronized (Xnnpack.class) {
                                try {
                                    defaultInstanceBasedParser = PARSER;
                                    if (defaultInstanceBasedParser == null) {
                                        defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                        PARSER = defaultInstanceBasedParser;
                                    }
                                } catch (Throwable th) {
                                    throw th;
                                }
                                break;
                            }
                            return defaultInstanceBasedParser;
                        case 6:
                            return (byte) 1;
                        case 7:
                            return null;
                        default:
                            throw new UnsupportedOperationException();
                    }
                }

                static {
                    Xnnpack xnnpack = new Xnnpack();
                    DEFAULT_INSTANCE = xnnpack;
                    GeneratedMessageLite.registerDefaultInstance(Xnnpack.class, xnnpack);
                }

                public static Xnnpack getDefaultInstance() {
                    return DEFAULT_INSTANCE;
                }

                public static Parser<Xnnpack> parser() {
                    return DEFAULT_INSTANCE.getParserForType();
                }
            }

            public enum DelegateCase {
                TFLITE(1),
                GPU(2),
                NNAPI(3),
                XNNPACK(4),
                DELEGATE_NOT_SET(0);

                private final int value;

                DelegateCase(int i) {
                    this.value = i;
                }

                @Deprecated
                public static DelegateCase valueOf(int i) {
                    return forNumber(i);
                }

                public static DelegateCase forNumber(int i) {
                    if (i == 0) {
                        return DELEGATE_NOT_SET;
                    }
                    if (i == 1) {
                        return TFLITE;
                    }
                    if (i == 2) {
                        return GPU;
                    }
                    if (i == 3) {
                        return NNAPI;
                    }
                    if (i != 4) {
                        return null;
                    }
                    return XNNPACK;
                }

                public int getNumber() {
                    return this.value;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public DelegateCase getDelegateCase() {
                return DelegateCase.forNumber(this.delegateCase_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearDelegate() {
                this.delegateCase_ = 0;
                this.delegate_ = null;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public boolean hasTflite() {
                return this.delegateCase_ == 1;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public TfLite getTflite() {
                if (this.delegateCase_ == 1) {
                    return (TfLite) this.delegate_;
                }
                return TfLite.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setTflite(TfLite tfLite) {
                tfLite.getClass();
                this.delegate_ = tfLite;
                this.delegateCase_ = 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeTflite(TfLite tfLite) {
                tfLite.getClass();
                if (this.delegateCase_ == 1 && this.delegate_ != TfLite.getDefaultInstance()) {
                    this.delegate_ = TfLite.newBuilder((TfLite) this.delegate_).mergeFrom(tfLite).buildPartial();
                } else {
                    this.delegate_ = tfLite;
                }
                this.delegateCase_ = 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearTflite() {
                if (this.delegateCase_ == 1) {
                    this.delegateCase_ = 0;
                    this.delegate_ = null;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public boolean hasGpu() {
                return this.delegateCase_ == 2;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public Gpu getGpu() {
                if (this.delegateCase_ == 2) {
                    return (Gpu) this.delegate_;
                }
                return Gpu.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setGpu(Gpu gpu) {
                gpu.getClass();
                this.delegate_ = gpu;
                this.delegateCase_ = 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeGpu(Gpu gpu) {
                gpu.getClass();
                if (this.delegateCase_ == 2 && this.delegate_ != Gpu.getDefaultInstance()) {
                    this.delegate_ = Gpu.newBuilder((Gpu) this.delegate_).mergeFrom(gpu).buildPartial();
                } else {
                    this.delegate_ = gpu;
                }
                this.delegateCase_ = 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearGpu() {
                if (this.delegateCase_ == 2) {
                    this.delegateCase_ = 0;
                    this.delegate_ = null;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public boolean hasNnapi() {
                return this.delegateCase_ == 3;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public Nnapi getNnapi() {
                if (this.delegateCase_ == 3) {
                    return (Nnapi) this.delegate_;
                }
                return Nnapi.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNnapi(Nnapi nnapi) {
                nnapi.getClass();
                this.delegate_ = nnapi;
                this.delegateCase_ = 3;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeNnapi(Nnapi nnapi) {
                nnapi.getClass();
                if (this.delegateCase_ == 3 && this.delegate_ != Nnapi.getDefaultInstance()) {
                    this.delegate_ = Nnapi.newBuilder((Nnapi) this.delegate_).mergeFrom(nnapi).buildPartial();
                } else {
                    this.delegate_ = nnapi;
                }
                this.delegateCase_ = 3;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNnapi() {
                if (this.delegateCase_ == 3) {
                    this.delegateCase_ = 0;
                    this.delegate_ = null;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public boolean hasXnnpack() {
                return this.delegateCase_ == 4;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
            public Xnnpack getXnnpack() {
                if (this.delegateCase_ == 4) {
                    return (Xnnpack) this.delegate_;
                }
                return Xnnpack.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXnnpack(Xnnpack xnnpack) {
                xnnpack.getClass();
                this.delegate_ = xnnpack;
                this.delegateCase_ = 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeXnnpack(Xnnpack xnnpack) {
                xnnpack.getClass();
                if (this.delegateCase_ == 4 && this.delegate_ != Xnnpack.getDefaultInstance()) {
                    this.delegate_ = Xnnpack.newBuilder((Xnnpack) this.delegate_).mergeFrom(xnnpack).buildPartial();
                } else {
                    this.delegate_ = xnnpack;
                }
                this.delegateCase_ = 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXnnpack() {
                if (this.delegateCase_ == 4) {
                    this.delegateCase_ = 0;
                    this.delegate_ = null;
                }
            }

            public static Delegate parseFrom(ByteBuffer byteBuffer) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Delegate parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Delegate parseFrom(ByteString byteString) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Delegate parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Delegate parseFrom(byte[] bArr) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Delegate parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Delegate parseFrom(InputStream inputStream) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Delegate parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Delegate parseDelimitedFrom(InputStream inputStream) {
                return (Delegate) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Delegate parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Delegate) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Delegate parseFrom(CodedInputStream codedInputStream) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Delegate parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Delegate) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Delegate delegate) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(delegate);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Delegate, Builder> implements DelegateOrBuilder {
                /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                    this();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite build() {
                    return super.build();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                    return super.buildPartial();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                    return super.clear();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                /* JADX INFO: renamed from: clone */
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                    return super.mo436clone();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                /* JADX INFO: renamed from: clone */
                public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                    return super.mo436clone();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                /* JADX INFO: renamed from: clone */
                public /* bridge */ /* synthetic */ Object mo436clone() {
                    return super.mo436clone();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                    return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(codedInputStream, extensionRegistryLite);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                    return super.mergeFrom(bArr, i, i2);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                    return super.mergeFrom(byteString);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(byteString, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                    return super.mergeFrom(codedInputStream);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(codedInputStream, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                    return super.mergeFrom(messageLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                    return super.mergeFrom(inputStream);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(inputStream, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                    return super.mergeFrom(bArr);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                    return super.mergeFrom(bArr, i, i2);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(bArr, extensionRegistryLite);
                }

                private Builder() {
                    super(Delegate.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public DelegateCase getDelegateCase() {
                    return ((Delegate) this.instance).getDelegateCase();
                }

                public Builder clearDelegate() {
                    copyOnWrite();
                    ((Delegate) this.instance).clearDelegate();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public boolean hasTflite() {
                    return ((Delegate) this.instance).hasTflite();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public TfLite getTflite() {
                    return ((Delegate) this.instance).getTflite();
                }

                public Builder setTflite(TfLite tfLite) {
                    copyOnWrite();
                    ((Delegate) this.instance).setTflite(tfLite);
                    return this;
                }

                public Builder setTflite(TfLite.Builder builder) {
                    copyOnWrite();
                    ((Delegate) this.instance).setTflite(builder.build());
                    return this;
                }

                public Builder mergeTflite(TfLite tfLite) {
                    copyOnWrite();
                    ((Delegate) this.instance).mergeTflite(tfLite);
                    return this;
                }

                public Builder clearTflite() {
                    copyOnWrite();
                    ((Delegate) this.instance).clearTflite();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public boolean hasGpu() {
                    return ((Delegate) this.instance).hasGpu();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public Gpu getGpu() {
                    return ((Delegate) this.instance).getGpu();
                }

                public Builder setGpu(Gpu gpu) {
                    copyOnWrite();
                    ((Delegate) this.instance).setGpu(gpu);
                    return this;
                }

                public Builder setGpu(Gpu.Builder builder) {
                    copyOnWrite();
                    ((Delegate) this.instance).setGpu(builder.build());
                    return this;
                }

                public Builder mergeGpu(Gpu gpu) {
                    copyOnWrite();
                    ((Delegate) this.instance).mergeGpu(gpu);
                    return this;
                }

                public Builder clearGpu() {
                    copyOnWrite();
                    ((Delegate) this.instance).clearGpu();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public boolean hasNnapi() {
                    return ((Delegate) this.instance).hasNnapi();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public Nnapi getNnapi() {
                    return ((Delegate) this.instance).getNnapi();
                }

                public Builder setNnapi(Nnapi nnapi) {
                    copyOnWrite();
                    ((Delegate) this.instance).setNnapi(nnapi);
                    return this;
                }

                public Builder setNnapi(Nnapi.Builder builder) {
                    copyOnWrite();
                    ((Delegate) this.instance).setNnapi(builder.build());
                    return this;
                }

                public Builder mergeNnapi(Nnapi nnapi) {
                    copyOnWrite();
                    ((Delegate) this.instance).mergeNnapi(nnapi);
                    return this;
                }

                public Builder clearNnapi() {
                    copyOnWrite();
                    ((Delegate) this.instance).clearNnapi();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public boolean hasXnnpack() {
                    return ((Delegate) this.instance).hasXnnpack();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.DelegateOrBuilder
                public Xnnpack getXnnpack() {
                    return ((Delegate) this.instance).getXnnpack();
                }

                public Builder setXnnpack(Xnnpack xnnpack) {
                    copyOnWrite();
                    ((Delegate) this.instance).setXnnpack(xnnpack);
                    return this;
                }

                public Builder setXnnpack(Xnnpack.Builder builder) {
                    copyOnWrite();
                    ((Delegate) this.instance).setXnnpack(builder.build());
                    return this;
                }

                public Builder mergeXnnpack(Xnnpack xnnpack) {
                    copyOnWrite();
                    ((Delegate) this.instance).mergeXnnpack(xnnpack);
                    return this;
                }

                public Builder clearXnnpack() {
                    copyOnWrite();
                    ((Delegate) this.instance).clearXnnpack();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Delegate();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0001\u0000\u0001\u0004\u0004\u0000\u0000\u0000\u0001<\u0000\u0002<\u0000\u0003<\u0000\u0004<\u0000", new Object[]{"delegate_", "delegateCase_", TfLite.class, Gpu.class, Nnapi.class, Xnnpack.class});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Delegate> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Delegate.class) {
                            try {
                                defaultInstanceBasedParser = PARSER;
                                if (defaultInstanceBasedParser == null) {
                                    defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                    PARSER = defaultInstanceBasedParser;
                                }
                            } catch (Throwable th) {
                                throw th;
                            }
                            break;
                        }
                        return defaultInstanceBasedParser;
                    case 6:
                        return (byte) 1;
                    case 7:
                        return null;
                    default:
                        throw new UnsupportedOperationException();
                }
            }

            static {
                Delegate delegate = new Delegate();
                DEFAULT_INSTANCE = delegate;
                GeneratedMessageLite.registerDefaultInstance(Delegate.class, delegate);
            }

            public static Delegate getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Delegate> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class InputOutputConfig extends GeneratedMessageLite<InputOutputConfig, Builder> implements InputOutputConfigOrBuilder {
            private static final InputOutputConfig DEFAULT_INSTANCE;
            public static final int FEEDBACK_TENSOR_LINKS_FIELD_NUMBER = 5;
            public static final int INPUT_TENSOR_INDICES_MAP_FIELD_NUMBER = 1;
            public static final int INPUT_TENSOR_NAMES_MAP_FIELD_NUMBER = 3;
            public static final int OUTPUT_TENSOR_INDICES_MAP_FIELD_NUMBER = 2;
            public static final int OUTPUT_TENSOR_NAMES_MAP_FIELD_NUMBER = 4;
            private static volatile Parser<InputOutputConfig> PARSER;
            private Object inputTensorMap_;
            private Object outputTensorMap_;
            private int inputTensorMapCase_ = 0;
            private int outputTensorMapCase_ = 0;
            private Internal.ProtobufList<FeedbackTensorLink> feedbackTensorLinks_ = GeneratedMessageLite.emptyProtobufList();

            public interface FeedbackTensorLinkOrBuilder extends MessageLiteOrBuilder {
                String getFromOutputTensorName();

                ByteString getFromOutputTensorNameBytes();

                String getToInputTensorName();

                ByteString getToInputTensorNameBytes();

                boolean hasFromOutputTensorName();

                boolean hasToInputTensorName();
            }

            public interface TensorIndicesMapOrBuilder extends MessageLiteOrBuilder {
                int getModelTensorIndices(int i);

                int getModelTensorIndicesCount();

                List<Integer> getModelTensorIndicesList();
            }

            public interface TensorNamesMapOrBuilder extends MessageLiteOrBuilder {
                String getTensorNames(int i);

                ByteString getTensorNamesBytes(int i);

                int getTensorNamesCount();

                List<String> getTensorNamesList();
            }

            @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
            public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                return super.getDefaultInstanceForType();
            }

            @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
            public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                return super.newBuilderForType();
            }

            @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
            public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                return super.toBuilder();
            }

            private InputOutputConfig() {
            }

            public static final class TensorIndicesMap extends GeneratedMessageLite<TensorIndicesMap, Builder> implements TensorIndicesMapOrBuilder {
                private static final TensorIndicesMap DEFAULT_INSTANCE;
                public static final int MODEL_TENSOR_INDICES_FIELD_NUMBER = 1;
                private static volatile Parser<TensorIndicesMap> PARSER;
                private int modelTensorIndicesMemoizedSerializedSize = -1;
                private Internal.IntList modelTensorIndices_ = GeneratedMessageLite.emptyIntList();

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                    return super.newBuilderForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                    return super.toBuilder();
                }

                private TensorIndicesMap() {
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorIndicesMapOrBuilder
                public List<Integer> getModelTensorIndicesList() {
                    return this.modelTensorIndices_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorIndicesMapOrBuilder
                public int getModelTensorIndicesCount() {
                    return this.modelTensorIndices_.size();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorIndicesMapOrBuilder
                public int getModelTensorIndices(int i) {
                    return this.modelTensorIndices_.getInt(i);
                }

                private void ensureModelTensorIndicesIsMutable() {
                    Internal.IntList intList = this.modelTensorIndices_;
                    if (intList.isModifiable()) {
                        return;
                    }
                    this.modelTensorIndices_ = GeneratedMessageLite.mutableCopy(intList);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setModelTensorIndices(int i, int i2) {
                    ensureModelTensorIndicesIsMutable();
                    this.modelTensorIndices_.setInt(i, i2);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void addModelTensorIndices(int i) {
                    ensureModelTensorIndicesIsMutable();
                    this.modelTensorIndices_.addInt(i);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void addAllModelTensorIndices(Iterable<? extends Integer> iterable) {
                    ensureModelTensorIndicesIsMutable();
                    AbstractMessageLite.addAll(iterable, this.modelTensorIndices_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearModelTensorIndices() {
                    this.modelTensorIndices_ = GeneratedMessageLite.emptyIntList();
                }

                public static TensorIndicesMap parseFrom(ByteBuffer byteBuffer) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
                }

                public static TensorIndicesMap parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
                }

                public static TensorIndicesMap parseFrom(ByteString byteString) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
                }

                public static TensorIndicesMap parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
                }

                public static TensorIndicesMap parseFrom(byte[] bArr) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
                }

                public static TensorIndicesMap parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
                }

                public static TensorIndicesMap parseFrom(InputStream inputStream) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static TensorIndicesMap parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static TensorIndicesMap parseDelimitedFrom(InputStream inputStream) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static TensorIndicesMap parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static TensorIndicesMap parseFrom(CodedInputStream codedInputStream) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
                }

                public static TensorIndicesMap parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorIndicesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
                }

                public static Builder newBuilder() {
                    return (Builder) DEFAULT_INSTANCE.createBuilder();
                }

                public static Builder newBuilder(TensorIndicesMap tensorIndicesMap) {
                    return (Builder) DEFAULT_INSTANCE.createBuilder(tensorIndicesMap);
                }

                public static final class Builder extends GeneratedMessageLite.Builder<TensorIndicesMap, Builder> implements TensorIndicesMapOrBuilder {
                    /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                        this();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite build() {
                        return super.build();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                        return super.buildPartial();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                        return super.clear();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ Object mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                    public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                        return super.getDefaultInstanceForType();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                        return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                        return super.mergeFrom(byteString);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(byteString, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                        return super.mergeFrom(codedInputStream);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                        return super.mergeFrom(messageLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                        return super.mergeFrom(inputStream);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(inputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                        return super.mergeFrom(bArr);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, extensionRegistryLite);
                    }

                    private Builder() {
                        super(TensorIndicesMap.DEFAULT_INSTANCE);
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorIndicesMapOrBuilder
                    public List<Integer> getModelTensorIndicesList() {
                        return Collections.unmodifiableList(((TensorIndicesMap) this.instance).getModelTensorIndicesList());
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorIndicesMapOrBuilder
                    public int getModelTensorIndicesCount() {
                        return ((TensorIndicesMap) this.instance).getModelTensorIndicesCount();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorIndicesMapOrBuilder
                    public int getModelTensorIndices(int i) {
                        return ((TensorIndicesMap) this.instance).getModelTensorIndices(i);
                    }

                    public Builder setModelTensorIndices(int i, int i2) {
                        copyOnWrite();
                        ((TensorIndicesMap) this.instance).setModelTensorIndices(i, i2);
                        return this;
                    }

                    public Builder addModelTensorIndices(int i) {
                        copyOnWrite();
                        ((TensorIndicesMap) this.instance).addModelTensorIndices(i);
                        return this;
                    }

                    public Builder addAllModelTensorIndices(Iterable<? extends Integer> iterable) {
                        copyOnWrite();
                        ((TensorIndicesMap) this.instance).addAllModelTensorIndices(iterable);
                        return this;
                    }

                    public Builder clearModelTensorIndices() {
                        copyOnWrite();
                        ((TensorIndicesMap) this.instance).clearModelTensorIndices();
                        return this;
                    }
                }

                @Override // com.google.protobuf.GeneratedMessageLite
                protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                    Parser defaultInstanceBasedParser;
                    AnonymousClass1 anonymousClass1 = null;
                    switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                        case 1:
                            return new TensorIndicesMap();
                        case 2:
                            return new Builder(anonymousClass1);
                        case 3:
                            return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001'", new Object[]{"modelTensorIndices_"});
                        case 4:
                            return DEFAULT_INSTANCE;
                        case 5:
                            Parser<TensorIndicesMap> parser = PARSER;
                            if (parser != null) {
                                return parser;
                            }
                            synchronized (TensorIndicesMap.class) {
                                try {
                                    defaultInstanceBasedParser = PARSER;
                                    if (defaultInstanceBasedParser == null) {
                                        defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                        PARSER = defaultInstanceBasedParser;
                                    }
                                } catch (Throwable th) {
                                    throw th;
                                }
                                break;
                            }
                            return defaultInstanceBasedParser;
                        case 6:
                            return (byte) 1;
                        case 7:
                            return null;
                        default:
                            throw new UnsupportedOperationException();
                    }
                }

                static {
                    TensorIndicesMap tensorIndicesMap = new TensorIndicesMap();
                    DEFAULT_INSTANCE = tensorIndicesMap;
                    GeneratedMessageLite.registerDefaultInstance(TensorIndicesMap.class, tensorIndicesMap);
                }

                public static TensorIndicesMap getDefaultInstance() {
                    return DEFAULT_INSTANCE;
                }

                public static Parser<TensorIndicesMap> parser() {
                    return DEFAULT_INSTANCE.getParserForType();
                }
            }

            public static final class TensorNamesMap extends GeneratedMessageLite<TensorNamesMap, Builder> implements TensorNamesMapOrBuilder {
                private static final TensorNamesMap DEFAULT_INSTANCE;
                private static volatile Parser<TensorNamesMap> PARSER = null;
                public static final int TENSOR_NAMES_FIELD_NUMBER = 1;
                private Internal.ProtobufList<String> tensorNames_ = GeneratedMessageLite.emptyProtobufList();

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                    return super.newBuilderForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                    return super.toBuilder();
                }

                private TensorNamesMap() {
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                public List<String> getTensorNamesList() {
                    return this.tensorNames_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                public int getTensorNamesCount() {
                    return this.tensorNames_.size();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                public String getTensorNames(int i) {
                    return this.tensorNames_.get(i);
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                public ByteString getTensorNamesBytes(int i) {
                    return ByteString.copyFromUtf8(this.tensorNames_.get(i));
                }

                private void ensureTensorNamesIsMutable() {
                    Internal.ProtobufList<String> protobufList = this.tensorNames_;
                    if (protobufList.isModifiable()) {
                        return;
                    }
                    this.tensorNames_ = GeneratedMessageLite.mutableCopy(protobufList);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setTensorNames(int i, String str) {
                    str.getClass();
                    ensureTensorNamesIsMutable();
                    this.tensorNames_.set(i, str);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void addTensorNames(String str) {
                    str.getClass();
                    ensureTensorNamesIsMutable();
                    this.tensorNames_.add(str);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void addAllTensorNames(Iterable<String> iterable) {
                    ensureTensorNamesIsMutable();
                    AbstractMessageLite.addAll(iterable, this.tensorNames_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearTensorNames() {
                    this.tensorNames_ = GeneratedMessageLite.emptyProtobufList();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void addTensorNamesBytes(ByteString byteString) {
                    ensureTensorNamesIsMutable();
                    this.tensorNames_.add(byteString.toStringUtf8());
                }

                public static TensorNamesMap parseFrom(ByteBuffer byteBuffer) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
                }

                public static TensorNamesMap parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
                }

                public static TensorNamesMap parseFrom(ByteString byteString) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
                }

                public static TensorNamesMap parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
                }

                public static TensorNamesMap parseFrom(byte[] bArr) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
                }

                public static TensorNamesMap parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
                }

                public static TensorNamesMap parseFrom(InputStream inputStream) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static TensorNamesMap parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static TensorNamesMap parseDelimitedFrom(InputStream inputStream) {
                    return (TensorNamesMap) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static TensorNamesMap parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorNamesMap) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static TensorNamesMap parseFrom(CodedInputStream codedInputStream) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
                }

                public static TensorNamesMap parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (TensorNamesMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
                }

                public static Builder newBuilder() {
                    return (Builder) DEFAULT_INSTANCE.createBuilder();
                }

                public static Builder newBuilder(TensorNamesMap tensorNamesMap) {
                    return (Builder) DEFAULT_INSTANCE.createBuilder(tensorNamesMap);
                }

                public static final class Builder extends GeneratedMessageLite.Builder<TensorNamesMap, Builder> implements TensorNamesMapOrBuilder {
                    /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                        this();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite build() {
                        return super.build();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                        return super.buildPartial();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                        return super.clear();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ Object mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                    public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                        return super.getDefaultInstanceForType();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                        return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                        return super.mergeFrom(byteString);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(byteString, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                        return super.mergeFrom(codedInputStream);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                        return super.mergeFrom(messageLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                        return super.mergeFrom(inputStream);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(inputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                        return super.mergeFrom(bArr);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, extensionRegistryLite);
                    }

                    private Builder() {
                        super(TensorNamesMap.DEFAULT_INSTANCE);
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                    public List<String> getTensorNamesList() {
                        return Collections.unmodifiableList(((TensorNamesMap) this.instance).getTensorNamesList());
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                    public int getTensorNamesCount() {
                        return ((TensorNamesMap) this.instance).getTensorNamesCount();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                    public String getTensorNames(int i) {
                        return ((TensorNamesMap) this.instance).getTensorNames(i);
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.TensorNamesMapOrBuilder
                    public ByteString getTensorNamesBytes(int i) {
                        return ((TensorNamesMap) this.instance).getTensorNamesBytes(i);
                    }

                    public Builder setTensorNames(int i, String str) {
                        copyOnWrite();
                        ((TensorNamesMap) this.instance).setTensorNames(i, str);
                        return this;
                    }

                    public Builder addTensorNames(String str) {
                        copyOnWrite();
                        ((TensorNamesMap) this.instance).addTensorNames(str);
                        return this;
                    }

                    public Builder addAllTensorNames(Iterable<String> iterable) {
                        copyOnWrite();
                        ((TensorNamesMap) this.instance).addAllTensorNames(iterable);
                        return this;
                    }

                    public Builder clearTensorNames() {
                        copyOnWrite();
                        ((TensorNamesMap) this.instance).clearTensorNames();
                        return this;
                    }

                    public Builder addTensorNamesBytes(ByteString byteString) {
                        copyOnWrite();
                        ((TensorNamesMap) this.instance).addTensorNamesBytes(byteString);
                        return this;
                    }
                }

                @Override // com.google.protobuf.GeneratedMessageLite
                protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                    Parser defaultInstanceBasedParser;
                    AnonymousClass1 anonymousClass1 = null;
                    switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                        case 1:
                            return new TensorNamesMap();
                        case 2:
                            return new Builder(anonymousClass1);
                        case 3:
                            return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001a", new Object[]{"tensorNames_"});
                        case 4:
                            return DEFAULT_INSTANCE;
                        case 5:
                            Parser<TensorNamesMap> parser = PARSER;
                            if (parser != null) {
                                return parser;
                            }
                            synchronized (TensorNamesMap.class) {
                                try {
                                    defaultInstanceBasedParser = PARSER;
                                    if (defaultInstanceBasedParser == null) {
                                        defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                        PARSER = defaultInstanceBasedParser;
                                    }
                                } catch (Throwable th) {
                                    throw th;
                                }
                                break;
                            }
                            return defaultInstanceBasedParser;
                        case 6:
                            return (byte) 1;
                        case 7:
                            return null;
                        default:
                            throw new UnsupportedOperationException();
                    }
                }

                static {
                    TensorNamesMap tensorNamesMap = new TensorNamesMap();
                    DEFAULT_INSTANCE = tensorNamesMap;
                    GeneratedMessageLite.registerDefaultInstance(TensorNamesMap.class, tensorNamesMap);
                }

                public static TensorNamesMap getDefaultInstance() {
                    return DEFAULT_INSTANCE;
                }

                public static Parser<TensorNamesMap> parser() {
                    return DEFAULT_INSTANCE.getParserForType();
                }
            }

            public static final class FeedbackTensorLink extends GeneratedMessageLite<FeedbackTensorLink, Builder> implements FeedbackTensorLinkOrBuilder {
                private static final FeedbackTensorLink DEFAULT_INSTANCE;
                public static final int FROM_OUTPUT_TENSOR_NAME_FIELD_NUMBER = 1;
                private static volatile Parser<FeedbackTensorLink> PARSER = null;
                public static final int TO_INPUT_TENSOR_NAME_FIELD_NUMBER = 2;
                private int bitField0_;
                private String fromOutputTensorName_ = "";
                private String toInputTensorName_ = "";

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
                    return super.newBuilderForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
                public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
                    return super.toBuilder();
                }

                private FeedbackTensorLink() {
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                public boolean hasFromOutputTensorName() {
                    return (this.bitField0_ & 1) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                public String getFromOutputTensorName() {
                    return this.fromOutputTensorName_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                public ByteString getFromOutputTensorNameBytes() {
                    return ByteString.copyFromUtf8(this.fromOutputTensorName_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setFromOutputTensorName(String str) {
                    str.getClass();
                    this.bitField0_ |= 1;
                    this.fromOutputTensorName_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearFromOutputTensorName() {
                    this.bitField0_ &= -2;
                    this.fromOutputTensorName_ = getDefaultInstance().getFromOutputTensorName();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setFromOutputTensorNameBytes(ByteString byteString) {
                    this.fromOutputTensorName_ = byteString.toStringUtf8();
                    this.bitField0_ |= 1;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                public boolean hasToInputTensorName() {
                    return (this.bitField0_ & 2) != 0;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                public String getToInputTensorName() {
                    return this.toInputTensorName_;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                public ByteString getToInputTensorNameBytes() {
                    return ByteString.copyFromUtf8(this.toInputTensorName_);
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setToInputTensorName(String str) {
                    str.getClass();
                    this.bitField0_ |= 2;
                    this.toInputTensorName_ = str;
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void clearToInputTensorName() {
                    this.bitField0_ &= -3;
                    this.toInputTensorName_ = getDefaultInstance().getToInputTensorName();
                }

                /* JADX INFO: Access modifiers changed from: private */
                public void setToInputTensorNameBytes(ByteString byteString) {
                    this.toInputTensorName_ = byteString.toStringUtf8();
                    this.bitField0_ |= 2;
                }

                public static FeedbackTensorLink parseFrom(ByteBuffer byteBuffer) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
                }

                public static FeedbackTensorLink parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
                }

                public static FeedbackTensorLink parseFrom(ByteString byteString) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
                }

                public static FeedbackTensorLink parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
                }

                public static FeedbackTensorLink parseFrom(byte[] bArr) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
                }

                public static FeedbackTensorLink parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
                }

                public static FeedbackTensorLink parseFrom(InputStream inputStream) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static FeedbackTensorLink parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static FeedbackTensorLink parseDelimitedFrom(InputStream inputStream) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
                }

                public static FeedbackTensorLink parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
                }

                public static FeedbackTensorLink parseFrom(CodedInputStream codedInputStream) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
                }

                public static FeedbackTensorLink parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return (FeedbackTensorLink) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
                }

                public static Builder newBuilder() {
                    return (Builder) DEFAULT_INSTANCE.createBuilder();
                }

                public static Builder newBuilder(FeedbackTensorLink feedbackTensorLink) {
                    return (Builder) DEFAULT_INSTANCE.createBuilder(feedbackTensorLink);
                }

                public static final class Builder extends GeneratedMessageLite.Builder<FeedbackTensorLink, Builder> implements FeedbackTensorLinkOrBuilder {
                    /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                        this();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite build() {
                        return super.build();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                        return super.buildPartial();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                        return super.clear();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    /* JADX INFO: renamed from: clone */
                    public /* bridge */ /* synthetic */ Object mo436clone() {
                        return super.mo436clone();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                    public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                        return super.getDefaultInstanceForType();
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                    protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                        return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                        return super.mergeFrom(byteString);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(byteString, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                        return super.mergeFrom(codedInputStream);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(codedInputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                        return super.mergeFrom(messageLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                        return super.mergeFrom(inputStream);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(inputStream, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                        return super.mergeFrom(bArr);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                        return super.mergeFrom(bArr, i, i2);
                    }

                    @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                    }

                    @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                    public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                        return super.mergeFrom(bArr, extensionRegistryLite);
                    }

                    private Builder() {
                        super(FeedbackTensorLink.DEFAULT_INSTANCE);
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                    public boolean hasFromOutputTensorName() {
                        return ((FeedbackTensorLink) this.instance).hasFromOutputTensorName();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                    public String getFromOutputTensorName() {
                        return ((FeedbackTensorLink) this.instance).getFromOutputTensorName();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                    public ByteString getFromOutputTensorNameBytes() {
                        return ((FeedbackTensorLink) this.instance).getFromOutputTensorNameBytes();
                    }

                    public Builder setFromOutputTensorName(String str) {
                        copyOnWrite();
                        ((FeedbackTensorLink) this.instance).setFromOutputTensorName(str);
                        return this;
                    }

                    public Builder clearFromOutputTensorName() {
                        copyOnWrite();
                        ((FeedbackTensorLink) this.instance).clearFromOutputTensorName();
                        return this;
                    }

                    public Builder setFromOutputTensorNameBytes(ByteString byteString) {
                        copyOnWrite();
                        ((FeedbackTensorLink) this.instance).setFromOutputTensorNameBytes(byteString);
                        return this;
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                    public boolean hasToInputTensorName() {
                        return ((FeedbackTensorLink) this.instance).hasToInputTensorName();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                    public String getToInputTensorName() {
                        return ((FeedbackTensorLink) this.instance).getToInputTensorName();
                    }

                    @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfig.FeedbackTensorLinkOrBuilder
                    public ByteString getToInputTensorNameBytes() {
                        return ((FeedbackTensorLink) this.instance).getToInputTensorNameBytes();
                    }

                    public Builder setToInputTensorName(String str) {
                        copyOnWrite();
                        ((FeedbackTensorLink) this.instance).setToInputTensorName(str);
                        return this;
                    }

                    public Builder clearToInputTensorName() {
                        copyOnWrite();
                        ((FeedbackTensorLink) this.instance).clearToInputTensorName();
                        return this;
                    }

                    public Builder setToInputTensorNameBytes(ByteString byteString) {
                        copyOnWrite();
                        ((FeedbackTensorLink) this.instance).setToInputTensorNameBytes(byteString);
                        return this;
                    }
                }

                @Override // com.google.protobuf.GeneratedMessageLite
                protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                    Parser defaultInstanceBasedParser;
                    AnonymousClass1 anonymousClass1 = null;
                    switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                        case 1:
                            return new FeedbackTensorLink();
                        case 2:
                            return new Builder(anonymousClass1);
                        case 3:
                            return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001ဈ\u0000\u0002ဈ\u0001", new Object[]{"bitField0_", "fromOutputTensorName_", "toInputTensorName_"});
                        case 4:
                            return DEFAULT_INSTANCE;
                        case 5:
                            Parser<FeedbackTensorLink> parser = PARSER;
                            if (parser != null) {
                                return parser;
                            }
                            synchronized (FeedbackTensorLink.class) {
                                try {
                                    defaultInstanceBasedParser = PARSER;
                                    if (defaultInstanceBasedParser == null) {
                                        defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                        PARSER = defaultInstanceBasedParser;
                                    }
                                } catch (Throwable th) {
                                    throw th;
                                }
                                break;
                            }
                            return defaultInstanceBasedParser;
                        case 6:
                            return (byte) 1;
                        case 7:
                            return null;
                        default:
                            throw new UnsupportedOperationException();
                    }
                }

                static {
                    FeedbackTensorLink feedbackTensorLink = new FeedbackTensorLink();
                    DEFAULT_INSTANCE = feedbackTensorLink;
                    GeneratedMessageLite.registerDefaultInstance(FeedbackTensorLink.class, feedbackTensorLink);
                }

                public static FeedbackTensorLink getDefaultInstance() {
                    return DEFAULT_INSTANCE;
                }

                public static Parser<FeedbackTensorLink> parser() {
                    return DEFAULT_INSTANCE.getParserForType();
                }
            }

            public enum InputTensorMapCase {
                INPUT_TENSOR_INDICES_MAP(1),
                INPUT_TENSOR_NAMES_MAP(3),
                INPUTTENSORMAP_NOT_SET(0);

                private final int value;

                InputTensorMapCase(int i) {
                    this.value = i;
                }

                @Deprecated
                public static InputTensorMapCase valueOf(int i) {
                    return forNumber(i);
                }

                public static InputTensorMapCase forNumber(int i) {
                    if (i == 0) {
                        return INPUTTENSORMAP_NOT_SET;
                    }
                    if (i == 1) {
                        return INPUT_TENSOR_INDICES_MAP;
                    }
                    if (i != 3) {
                        return null;
                    }
                    return INPUT_TENSOR_NAMES_MAP;
                }

                public int getNumber() {
                    return this.value;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public InputTensorMapCase getInputTensorMapCase() {
                return InputTensorMapCase.forNumber(this.inputTensorMapCase_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearInputTensorMap() {
                this.inputTensorMapCase_ = 0;
                this.inputTensorMap_ = null;
            }

            public enum OutputTensorMapCase {
                OUTPUT_TENSOR_INDICES_MAP(2),
                OUTPUT_TENSOR_NAMES_MAP(4),
                OUTPUTTENSORMAP_NOT_SET(0);

                private final int value;

                OutputTensorMapCase(int i) {
                    this.value = i;
                }

                @Deprecated
                public static OutputTensorMapCase valueOf(int i) {
                    return forNumber(i);
                }

                public static OutputTensorMapCase forNumber(int i) {
                    if (i == 0) {
                        return OUTPUTTENSORMAP_NOT_SET;
                    }
                    if (i == 2) {
                        return OUTPUT_TENSOR_INDICES_MAP;
                    }
                    if (i != 4) {
                        return null;
                    }
                    return OUTPUT_TENSOR_NAMES_MAP;
                }

                public int getNumber() {
                    return this.value;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public OutputTensorMapCase getOutputTensorMapCase() {
                return OutputTensorMapCase.forNumber(this.outputTensorMapCase_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutputTensorMap() {
                this.outputTensorMapCase_ = 0;
                this.outputTensorMap_ = null;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public boolean hasInputTensorIndicesMap() {
                return this.inputTensorMapCase_ == 1;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public TensorIndicesMap getInputTensorIndicesMap() {
                if (this.inputTensorMapCase_ == 1) {
                    return (TensorIndicesMap) this.inputTensorMap_;
                }
                return TensorIndicesMap.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setInputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                tensorIndicesMap.getClass();
                this.inputTensorMap_ = tensorIndicesMap;
                this.inputTensorMapCase_ = 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeInputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                tensorIndicesMap.getClass();
                if (this.inputTensorMapCase_ == 1 && this.inputTensorMap_ != TensorIndicesMap.getDefaultInstance()) {
                    this.inputTensorMap_ = TensorIndicesMap.newBuilder((TensorIndicesMap) this.inputTensorMap_).mergeFrom(tensorIndicesMap).buildPartial();
                } else {
                    this.inputTensorMap_ = tensorIndicesMap;
                }
                this.inputTensorMapCase_ = 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearInputTensorIndicesMap() {
                if (this.inputTensorMapCase_ == 1) {
                    this.inputTensorMapCase_ = 0;
                    this.inputTensorMap_ = null;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public boolean hasInputTensorNamesMap() {
                return this.inputTensorMapCase_ == 3;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public TensorNamesMap getInputTensorNamesMap() {
                if (this.inputTensorMapCase_ == 3) {
                    return (TensorNamesMap) this.inputTensorMap_;
                }
                return TensorNamesMap.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setInputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                tensorNamesMap.getClass();
                this.inputTensorMap_ = tensorNamesMap;
                this.inputTensorMapCase_ = 3;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeInputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                tensorNamesMap.getClass();
                if (this.inputTensorMapCase_ == 3 && this.inputTensorMap_ != TensorNamesMap.getDefaultInstance()) {
                    this.inputTensorMap_ = TensorNamesMap.newBuilder((TensorNamesMap) this.inputTensorMap_).mergeFrom(tensorNamesMap).buildPartial();
                } else {
                    this.inputTensorMap_ = tensorNamesMap;
                }
                this.inputTensorMapCase_ = 3;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearInputTensorNamesMap() {
                if (this.inputTensorMapCase_ == 3) {
                    this.inputTensorMapCase_ = 0;
                    this.inputTensorMap_ = null;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public boolean hasOutputTensorIndicesMap() {
                return this.outputTensorMapCase_ == 2;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public TensorIndicesMap getOutputTensorIndicesMap() {
                if (this.outputTensorMapCase_ == 2) {
                    return (TensorIndicesMap) this.outputTensorMap_;
                }
                return TensorIndicesMap.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOutputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                tensorIndicesMap.getClass();
                this.outputTensorMap_ = tensorIndicesMap;
                this.outputTensorMapCase_ = 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeOutputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                tensorIndicesMap.getClass();
                if (this.outputTensorMapCase_ == 2 && this.outputTensorMap_ != TensorIndicesMap.getDefaultInstance()) {
                    this.outputTensorMap_ = TensorIndicesMap.newBuilder((TensorIndicesMap) this.outputTensorMap_).mergeFrom(tensorIndicesMap).buildPartial();
                } else {
                    this.outputTensorMap_ = tensorIndicesMap;
                }
                this.outputTensorMapCase_ = 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutputTensorIndicesMap() {
                if (this.outputTensorMapCase_ == 2) {
                    this.outputTensorMapCase_ = 0;
                    this.outputTensorMap_ = null;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public boolean hasOutputTensorNamesMap() {
                return this.outputTensorMapCase_ == 4;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public TensorNamesMap getOutputTensorNamesMap() {
                if (this.outputTensorMapCase_ == 4) {
                    return (TensorNamesMap) this.outputTensorMap_;
                }
                return TensorNamesMap.getDefaultInstance();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOutputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                tensorNamesMap.getClass();
                this.outputTensorMap_ = tensorNamesMap;
                this.outputTensorMapCase_ = 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeOutputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                tensorNamesMap.getClass();
                if (this.outputTensorMapCase_ == 4 && this.outputTensorMap_ != TensorNamesMap.getDefaultInstance()) {
                    this.outputTensorMap_ = TensorNamesMap.newBuilder((TensorNamesMap) this.outputTensorMap_).mergeFrom(tensorNamesMap).buildPartial();
                } else {
                    this.outputTensorMap_ = tensorNamesMap;
                }
                this.outputTensorMapCase_ = 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutputTensorNamesMap() {
                if (this.outputTensorMapCase_ == 4) {
                    this.outputTensorMapCase_ = 0;
                    this.outputTensorMap_ = null;
                }
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public List<FeedbackTensorLink> getFeedbackTensorLinksList() {
                return this.feedbackTensorLinks_;
            }

            public List<? extends FeedbackTensorLinkOrBuilder> getFeedbackTensorLinksOrBuilderList() {
                return this.feedbackTensorLinks_;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public int getFeedbackTensorLinksCount() {
                return this.feedbackTensorLinks_.size();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
            public FeedbackTensorLink getFeedbackTensorLinks(int i) {
                return this.feedbackTensorLinks_.get(i);
            }

            public FeedbackTensorLinkOrBuilder getFeedbackTensorLinksOrBuilder(int i) {
                return this.feedbackTensorLinks_.get(i);
            }

            private void ensureFeedbackTensorLinksIsMutable() {
                Internal.ProtobufList<FeedbackTensorLink> protobufList = this.feedbackTensorLinks_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.feedbackTensorLinks_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setFeedbackTensorLinks(int i, FeedbackTensorLink feedbackTensorLink) {
                feedbackTensorLink.getClass();
                ensureFeedbackTensorLinksIsMutable();
                this.feedbackTensorLinks_.set(i, feedbackTensorLink);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addFeedbackTensorLinks(FeedbackTensorLink feedbackTensorLink) {
                feedbackTensorLink.getClass();
                ensureFeedbackTensorLinksIsMutable();
                this.feedbackTensorLinks_.add(feedbackTensorLink);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addFeedbackTensorLinks(int i, FeedbackTensorLink feedbackTensorLink) {
                feedbackTensorLink.getClass();
                ensureFeedbackTensorLinksIsMutable();
                this.feedbackTensorLinks_.add(i, feedbackTensorLink);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllFeedbackTensorLinks(Iterable<? extends FeedbackTensorLink> iterable) {
                ensureFeedbackTensorLinksIsMutable();
                AbstractMessageLite.addAll(iterable, this.feedbackTensorLinks_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearFeedbackTensorLinks() {
                this.feedbackTensorLinks_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void removeFeedbackTensorLinks(int i) {
                ensureFeedbackTensorLinksIsMutable();
                this.feedbackTensorLinks_.remove(i);
            }

            public static InputOutputConfig parseFrom(ByteBuffer byteBuffer) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static InputOutputConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static InputOutputConfig parseFrom(ByteString byteString) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static InputOutputConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static InputOutputConfig parseFrom(byte[] bArr) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static InputOutputConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static InputOutputConfig parseFrom(InputStream inputStream) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static InputOutputConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static InputOutputConfig parseDelimitedFrom(InputStream inputStream) {
                return (InputOutputConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static InputOutputConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (InputOutputConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static InputOutputConfig parseFrom(CodedInputStream codedInputStream) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static InputOutputConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (InputOutputConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(InputOutputConfig inputOutputConfig) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(inputOutputConfig);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<InputOutputConfig, Builder> implements InputOutputConfigOrBuilder {
                /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                    this();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite build() {
                    return super.build();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                    return super.buildPartial();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                    return super.clear();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                /* JADX INFO: renamed from: clone */
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                    return super.mo436clone();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                /* JADX INFO: renamed from: clone */
                public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                    return super.mo436clone();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                /* JADX INFO: renamed from: clone */
                public /* bridge */ /* synthetic */ Object mo436clone() {
                    return super.mo436clone();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
                public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                    return super.getDefaultInstanceForType();
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
                protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                    return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(codedInputStream, extensionRegistryLite);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                    return super.mergeFrom(bArr, i, i2);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                    return super.mergeFrom(byteString);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(byteString, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                    return super.mergeFrom(codedInputStream);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(codedInputStream, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                    return super.mergeFrom(messageLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                    return super.mergeFrom(inputStream);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(inputStream, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                    return super.mergeFrom(bArr);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                    return super.mergeFrom(bArr, i, i2);
                }

                @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
                }

                @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
                public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                    return super.mergeFrom(bArr, extensionRegistryLite);
                }

                private Builder() {
                    super(InputOutputConfig.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public InputTensorMapCase getInputTensorMapCase() {
                    return ((InputOutputConfig) this.instance).getInputTensorMapCase();
                }

                public Builder clearInputTensorMap() {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).clearInputTensorMap();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public OutputTensorMapCase getOutputTensorMapCase() {
                    return ((InputOutputConfig) this.instance).getOutputTensorMapCase();
                }

                public Builder clearOutputTensorMap() {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).clearOutputTensorMap();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public boolean hasInputTensorIndicesMap() {
                    return ((InputOutputConfig) this.instance).hasInputTensorIndicesMap();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public TensorIndicesMap getInputTensorIndicesMap() {
                    return ((InputOutputConfig) this.instance).getInputTensorIndicesMap();
                }

                public Builder setInputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setInputTensorIndicesMap(tensorIndicesMap);
                    return this;
                }

                public Builder setInputTensorIndicesMap(TensorIndicesMap.Builder builder) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setInputTensorIndicesMap(builder.build());
                    return this;
                }

                public Builder mergeInputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).mergeInputTensorIndicesMap(tensorIndicesMap);
                    return this;
                }

                public Builder clearInputTensorIndicesMap() {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).clearInputTensorIndicesMap();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public boolean hasInputTensorNamesMap() {
                    return ((InputOutputConfig) this.instance).hasInputTensorNamesMap();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public TensorNamesMap getInputTensorNamesMap() {
                    return ((InputOutputConfig) this.instance).getInputTensorNamesMap();
                }

                public Builder setInputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setInputTensorNamesMap(tensorNamesMap);
                    return this;
                }

                public Builder setInputTensorNamesMap(TensorNamesMap.Builder builder) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setInputTensorNamesMap(builder.build());
                    return this;
                }

                public Builder mergeInputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).mergeInputTensorNamesMap(tensorNamesMap);
                    return this;
                }

                public Builder clearInputTensorNamesMap() {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).clearInputTensorNamesMap();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public boolean hasOutputTensorIndicesMap() {
                    return ((InputOutputConfig) this.instance).hasOutputTensorIndicesMap();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public TensorIndicesMap getOutputTensorIndicesMap() {
                    return ((InputOutputConfig) this.instance).getOutputTensorIndicesMap();
                }

                public Builder setOutputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setOutputTensorIndicesMap(tensorIndicesMap);
                    return this;
                }

                public Builder setOutputTensorIndicesMap(TensorIndicesMap.Builder builder) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setOutputTensorIndicesMap(builder.build());
                    return this;
                }

                public Builder mergeOutputTensorIndicesMap(TensorIndicesMap tensorIndicesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).mergeOutputTensorIndicesMap(tensorIndicesMap);
                    return this;
                }

                public Builder clearOutputTensorIndicesMap() {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).clearOutputTensorIndicesMap();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public boolean hasOutputTensorNamesMap() {
                    return ((InputOutputConfig) this.instance).hasOutputTensorNamesMap();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public TensorNamesMap getOutputTensorNamesMap() {
                    return ((InputOutputConfig) this.instance).getOutputTensorNamesMap();
                }

                public Builder setOutputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setOutputTensorNamesMap(tensorNamesMap);
                    return this;
                }

                public Builder setOutputTensorNamesMap(TensorNamesMap.Builder builder) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setOutputTensorNamesMap(builder.build());
                    return this;
                }

                public Builder mergeOutputTensorNamesMap(TensorNamesMap tensorNamesMap) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).mergeOutputTensorNamesMap(tensorNamesMap);
                    return this;
                }

                public Builder clearOutputTensorNamesMap() {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).clearOutputTensorNamesMap();
                    return this;
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public List<FeedbackTensorLink> getFeedbackTensorLinksList() {
                    return Collections.unmodifiableList(((InputOutputConfig) this.instance).getFeedbackTensorLinksList());
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public int getFeedbackTensorLinksCount() {
                    return ((InputOutputConfig) this.instance).getFeedbackTensorLinksCount();
                }

                @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptions.InputOutputConfigOrBuilder
                public FeedbackTensorLink getFeedbackTensorLinks(int i) {
                    return ((InputOutputConfig) this.instance).getFeedbackTensorLinks(i);
                }

                public Builder setFeedbackTensorLinks(int i, FeedbackTensorLink feedbackTensorLink) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setFeedbackTensorLinks(i, feedbackTensorLink);
                    return this;
                }

                public Builder setFeedbackTensorLinks(int i, FeedbackTensorLink.Builder builder) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).setFeedbackTensorLinks(i, builder.build());
                    return this;
                }

                public Builder addFeedbackTensorLinks(FeedbackTensorLink feedbackTensorLink) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).addFeedbackTensorLinks(feedbackTensorLink);
                    return this;
                }

                public Builder addFeedbackTensorLinks(int i, FeedbackTensorLink feedbackTensorLink) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).addFeedbackTensorLinks(i, feedbackTensorLink);
                    return this;
                }

                public Builder addFeedbackTensorLinks(FeedbackTensorLink.Builder builder) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).addFeedbackTensorLinks(builder.build());
                    return this;
                }

                public Builder addFeedbackTensorLinks(int i, FeedbackTensorLink.Builder builder) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).addFeedbackTensorLinks(i, builder.build());
                    return this;
                }

                public Builder addAllFeedbackTensorLinks(Iterable<? extends FeedbackTensorLink> iterable) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).addAllFeedbackTensorLinks(iterable);
                    return this;
                }

                public Builder clearFeedbackTensorLinks() {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).clearFeedbackTensorLinks();
                    return this;
                }

                public Builder removeFeedbackTensorLinks(int i) {
                    copyOnWrite();
                    ((InputOutputConfig) this.instance).removeFeedbackTensorLinks(i);
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new InputOutputConfig();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0005\u0002\u0000\u0001\u0005\u0005\u0000\u0001\u0000\u0001<\u0000\u0002<\u0001\u0003<\u0000\u0004<\u0001\u0005\u001b", new Object[]{"inputTensorMap_", "inputTensorMapCase_", "outputTensorMap_", "outputTensorMapCase_", TensorIndicesMap.class, TensorIndicesMap.class, TensorNamesMap.class, TensorNamesMap.class, "feedbackTensorLinks_", FeedbackTensorLink.class});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<InputOutputConfig> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (InputOutputConfig.class) {
                            try {
                                defaultInstanceBasedParser = PARSER;
                                if (defaultInstanceBasedParser == null) {
                                    defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                    PARSER = defaultInstanceBasedParser;
                                }
                            } catch (Throwable th) {
                                throw th;
                            }
                            break;
                        }
                        return defaultInstanceBasedParser;
                    case 6:
                        return (byte) 1;
                    case 7:
                        return null;
                    default:
                        throw new UnsupportedOperationException();
                }
            }

            static {
                InputOutputConfig inputOutputConfig = new InputOutputConfig();
                DEFAULT_INSTANCE = inputOutputConfig;
                GeneratedMessageLite.registerDefaultInstance(InputOutputConfig.class, inputOutputConfig);
            }

            public static InputOutputConfig getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<InputOutputConfig> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public boolean hasModelPath() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public String getModelPath() {
            return this.modelPath_;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public ByteString getModelPathBytes() {
            return ByteString.copyFromUtf8(this.modelPath_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setModelPath(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.modelPath_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearModelPath() {
            this.bitField0_ &= -2;
            this.modelPath_ = getDefaultInstance().getModelPath();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setModelPathBytes(ByteString byteString) {
            this.modelPath_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public boolean hasTryMmapModel() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public boolean getTryMmapModel() {
            return this.tryMmapModel_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTryMmapModel(boolean z) {
            this.bitField0_ |= 2;
            this.tryMmapModel_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTryMmapModel() {
            this.bitField0_ &= -3;
            this.tryMmapModel_ = false;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        @Deprecated
        public boolean hasUseGpu() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        @Deprecated
        public boolean getUseGpu() {
            return this.useGpu_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setUseGpu(boolean z) {
            this.bitField0_ |= 4;
            this.useGpu_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearUseGpu() {
            this.bitField0_ &= -5;
            this.useGpu_ = false;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        @Deprecated
        public boolean hasUseNnapi() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        @Deprecated
        public boolean getUseNnapi() {
            return this.useNnapi_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setUseNnapi(boolean z) {
            this.bitField0_ |= 8;
            this.useNnapi_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearUseNnapi() {
            this.bitField0_ &= -9;
            this.useNnapi_ = false;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public boolean hasCpuNumThread() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public int getCpuNumThread() {
            return this.cpuNumThread_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCpuNumThread(int i) {
            this.bitField0_ |= 16;
            this.cpuNumThread_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCpuNumThread() {
            this.bitField0_ &= -17;
            this.cpuNumThread_ = -1;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public boolean hasDelegate() {
            return (this.bitField0_ & 32) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public Delegate getDelegate() {
            Delegate delegate = this.delegate_;
            return delegate == null ? Delegate.getDefaultInstance() : delegate;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDelegate(Delegate delegate) {
            delegate.getClass();
            this.delegate_ = delegate;
            this.bitField0_ |= 32;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeDelegate(Delegate delegate) {
            delegate.getClass();
            Delegate delegate2 = this.delegate_;
            if (delegate2 != null && delegate2 != Delegate.getDefaultInstance()) {
                this.delegate_ = Delegate.newBuilder(this.delegate_).mergeFrom(delegate).buildPartial();
            } else {
                this.delegate_ = delegate;
            }
            this.bitField0_ |= 32;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDelegate() {
            this.delegate_ = null;
            this.bitField0_ &= -33;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public boolean hasInputOutputConfig() {
            return (this.bitField0_ & 64) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
        public InputOutputConfig getInputOutputConfig() {
            InputOutputConfig inputOutputConfig = this.inputOutputConfig_;
            return inputOutputConfig == null ? InputOutputConfig.getDefaultInstance() : inputOutputConfig;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInputOutputConfig(InputOutputConfig inputOutputConfig) {
            inputOutputConfig.getClass();
            this.inputOutputConfig_ = inputOutputConfig;
            this.bitField0_ |= 64;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeInputOutputConfig(InputOutputConfig inputOutputConfig) {
            inputOutputConfig.getClass();
            InputOutputConfig inputOutputConfig2 = this.inputOutputConfig_;
            if (inputOutputConfig2 != null && inputOutputConfig2 != InputOutputConfig.getDefaultInstance()) {
                this.inputOutputConfig_ = InputOutputConfig.newBuilder(this.inputOutputConfig_).mergeFrom(inputOutputConfig).buildPartial();
            } else {
                this.inputOutputConfig_ = inputOutputConfig;
            }
            this.bitField0_ |= 64;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInputOutputConfig() {
            this.inputOutputConfig_ = null;
            this.bitField0_ &= -65;
        }

        public static InferenceCalculatorOptions parseFrom(ByteBuffer byteBuffer) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static InferenceCalculatorOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static InferenceCalculatorOptions parseFrom(ByteString byteString) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static InferenceCalculatorOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static InferenceCalculatorOptions parseFrom(byte[] bArr) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static InferenceCalculatorOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static InferenceCalculatorOptions parseFrom(InputStream inputStream) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InferenceCalculatorOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InferenceCalculatorOptions parseDelimitedFrom(InputStream inputStream) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InferenceCalculatorOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InferenceCalculatorOptions parseFrom(CodedInputStream codedInputStream) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static InferenceCalculatorOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InferenceCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(InferenceCalculatorOptions inferenceCalculatorOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(inferenceCalculatorOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<InferenceCalculatorOptions, Builder> implements InferenceCalculatorOptionsOrBuilder {
            /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                this();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite build() {
                return super.build();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                return super.buildPartial();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                return super.clear();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            /* JADX INFO: renamed from: clone */
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                return super.mo436clone();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            /* JADX INFO: renamed from: clone */
            public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                return super.mo436clone();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
            /* JADX INFO: renamed from: clone */
            public /* bridge */ /* synthetic */ Object mo436clone() {
                return super.mo436clone();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
            public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                return super.getDefaultInstanceForType();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
            protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(codedInputStream, extensionRegistryLite);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                return super.mergeFrom(bArr, i, i2);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                return super.mergeFrom(byteString);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(byteString, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                return super.mergeFrom(codedInputStream);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(codedInputStream, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                return super.mergeFrom(messageLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                return super.mergeFrom(inputStream);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(inputStream, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                return super.mergeFrom(bArr);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                return super.mergeFrom(bArr, i, i2);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(bArr, extensionRegistryLite);
            }

            private Builder() {
                super(InferenceCalculatorOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public boolean hasModelPath() {
                return ((InferenceCalculatorOptions) this.instance).hasModelPath();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public String getModelPath() {
                return ((InferenceCalculatorOptions) this.instance).getModelPath();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public ByteString getModelPathBytes() {
                return ((InferenceCalculatorOptions) this.instance).getModelPathBytes();
            }

            public Builder setModelPath(String str) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setModelPath(str);
                return this;
            }

            public Builder clearModelPath() {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).clearModelPath();
                return this;
            }

            public Builder setModelPathBytes(ByteString byteString) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setModelPathBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public boolean hasTryMmapModel() {
                return ((InferenceCalculatorOptions) this.instance).hasTryMmapModel();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public boolean getTryMmapModel() {
                return ((InferenceCalculatorOptions) this.instance).getTryMmapModel();
            }

            public Builder setTryMmapModel(boolean z) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setTryMmapModel(z);
                return this;
            }

            public Builder clearTryMmapModel() {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).clearTryMmapModel();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            @Deprecated
            public boolean hasUseGpu() {
                return ((InferenceCalculatorOptions) this.instance).hasUseGpu();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            @Deprecated
            public boolean getUseGpu() {
                return ((InferenceCalculatorOptions) this.instance).getUseGpu();
            }

            @Deprecated
            public Builder setUseGpu(boolean z) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setUseGpu(z);
                return this;
            }

            @Deprecated
            public Builder clearUseGpu() {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).clearUseGpu();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            @Deprecated
            public boolean hasUseNnapi() {
                return ((InferenceCalculatorOptions) this.instance).hasUseNnapi();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            @Deprecated
            public boolean getUseNnapi() {
                return ((InferenceCalculatorOptions) this.instance).getUseNnapi();
            }

            @Deprecated
            public Builder setUseNnapi(boolean z) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setUseNnapi(z);
                return this;
            }

            @Deprecated
            public Builder clearUseNnapi() {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).clearUseNnapi();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public boolean hasCpuNumThread() {
                return ((InferenceCalculatorOptions) this.instance).hasCpuNumThread();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public int getCpuNumThread() {
                return ((InferenceCalculatorOptions) this.instance).getCpuNumThread();
            }

            public Builder setCpuNumThread(int i) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setCpuNumThread(i);
                return this;
            }

            public Builder clearCpuNumThread() {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).clearCpuNumThread();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public boolean hasDelegate() {
                return ((InferenceCalculatorOptions) this.instance).hasDelegate();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public Delegate getDelegate() {
                return ((InferenceCalculatorOptions) this.instance).getDelegate();
            }

            public Builder setDelegate(Delegate delegate) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setDelegate(delegate);
                return this;
            }

            public Builder setDelegate(Delegate.Builder builder) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setDelegate(builder.build());
                return this;
            }

            public Builder mergeDelegate(Delegate delegate) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).mergeDelegate(delegate);
                return this;
            }

            public Builder clearDelegate() {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).clearDelegate();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public boolean hasInputOutputConfig() {
                return ((InferenceCalculatorOptions) this.instance).hasInputOutputConfig();
            }

            @Override // com.google.mediapipe.calculator.proto.InferenceCalculatorProto.InferenceCalculatorOptionsOrBuilder
            public InputOutputConfig getInputOutputConfig() {
                return ((InferenceCalculatorOptions) this.instance).getInputOutputConfig();
            }

            public Builder setInputOutputConfig(InputOutputConfig inputOutputConfig) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setInputOutputConfig(inputOutputConfig);
                return this;
            }

            public Builder setInputOutputConfig(InputOutputConfig.Builder builder) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).setInputOutputConfig(builder.build());
                return this;
            }

            public Builder mergeInputOutputConfig(InputOutputConfig inputOutputConfig) {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).mergeInputOutputConfig(inputOutputConfig);
                return this;
            }

            public Builder clearInputOutputConfig() {
                copyOnWrite();
                ((InferenceCalculatorOptions) this.instance).clearInputOutputConfig();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new InferenceCalculatorOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0007\u0000\u0001\u0001\b\u0007\u0000\u0000\u0000\u0001ဈ\u0000\u0002ဇ\u0002\u0003ဇ\u0003\u0004င\u0004\u0005ဉ\u0005\u0007ဇ\u0001\bဉ\u0006", new Object[]{"bitField0_", "modelPath_", "useGpu_", "useNnapi_", "cpuNumThread_", "delegate_", "tryMmapModel_", "inputOutputConfig_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<InferenceCalculatorOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (InferenceCalculatorOptions.class) {
                        try {
                            defaultInstanceBasedParser = PARSER;
                            if (defaultInstanceBasedParser == null) {
                                defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                PARSER = defaultInstanceBasedParser;
                            }
                        } catch (Throwable th) {
                            throw th;
                        }
                        break;
                    }
                    return defaultInstanceBasedParser;
                case 6:
                    return (byte) 1;
                case 7:
                    return null;
                default:
                    throw new UnsupportedOperationException();
            }
        }

        static {
            InferenceCalculatorOptions inferenceCalculatorOptions = new InferenceCalculatorOptions();
            DEFAULT_INSTANCE = inferenceCalculatorOptions;
            GeneratedMessageLite.registerDefaultInstance(InferenceCalculatorOptions.class, inferenceCalculatorOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, InferenceCalculatorOptions.class);
        }

        public static InferenceCalculatorOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<InferenceCalculatorOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.calculator.proto.InferenceCalculatorProto$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke;

        static {
            int[] iArr = new int[GeneratedMessageLite.MethodToInvoke.values().length];
            $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke = iArr;
            try {
                iArr[GeneratedMessageLite.MethodToInvoke.NEW_MUTABLE_INSTANCE.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.NEW_BUILDER.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.BUILD_MESSAGE_INFO.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.GET_DEFAULT_INSTANCE.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.GET_PARSER.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.GET_MEMOIZED_IS_INITIALIZED.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.SET_MEMOIZED_IS_INITIALIZED.ordinal()] = 7;
            } catch (NoSuchFieldError unused7) {
            }
        }
    }
}
