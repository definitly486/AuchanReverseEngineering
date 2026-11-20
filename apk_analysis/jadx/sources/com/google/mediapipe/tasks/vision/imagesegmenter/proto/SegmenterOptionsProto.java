package com.google.mediapipe.tasks.vision.imagesegmenter.proto;

import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.Internal;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import java.io.InputStream;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public final class SegmenterOptionsProto {

    public interface SegmenterOptionsOrBuilder extends MessageLiteOrBuilder {
        SegmenterOptions.Activation getActivation();

        @Deprecated
        SegmenterOptions.OutputType getOutputType();

        boolean hasActivation();

        @Deprecated
        boolean hasOutputType();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private SegmenterOptionsProto() {
    }

    public static final class SegmenterOptions extends GeneratedMessageLite<SegmenterOptions, Builder> implements SegmenterOptionsOrBuilder {
        public static final int ACTIVATION_FIELD_NUMBER = 2;
        private static final SegmenterOptions DEFAULT_INSTANCE;
        public static final int OUTPUT_TYPE_FIELD_NUMBER = 1;
        private static volatile Parser<SegmenterOptions> PARSER;
        private int activation_;
        private int bitField0_;
        private int outputType_;

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

        private SegmenterOptions() {
        }

        public enum OutputType implements Internal.EnumLite {
            UNSPECIFIED(0),
            CATEGORY_MASK(1),
            CONFIDENCE_MASK(2);

            public static final int CATEGORY_MASK_VALUE = 1;
            public static final int CONFIDENCE_MASK_VALUE = 2;
            public static final int UNSPECIFIED_VALUE = 0;
            private static final Internal.EnumLiteMap<OutputType> internalValueMap = new Internal.EnumLiteMap<OutputType>() { // from class: com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptions.OutputType.1
                @Override // com.google.protobuf.Internal.EnumLiteMap
                public OutputType findValueByNumber(int i) {
                    return OutputType.forNumber(i);
                }
            };
            private final int value;

            @Override // com.google.protobuf.Internal.EnumLite
            public final int getNumber() {
                return this.value;
            }

            @Deprecated
            public static OutputType valueOf(int i) {
                return forNumber(i);
            }

            public static OutputType forNumber(int i) {
                if (i == 0) {
                    return UNSPECIFIED;
                }
                if (i == 1) {
                    return CATEGORY_MASK;
                }
                if (i != 2) {
                    return null;
                }
                return CONFIDENCE_MASK;
            }

            public static Internal.EnumLiteMap<OutputType> internalGetValueMap() {
                return internalValueMap;
            }

            public static Internal.EnumVerifier internalGetVerifier() {
                return OutputTypeVerifier.INSTANCE;
            }

            private static final class OutputTypeVerifier implements Internal.EnumVerifier {
                static final Internal.EnumVerifier INSTANCE = new OutputTypeVerifier();

                private OutputTypeVerifier() {
                }

                @Override // com.google.protobuf.Internal.EnumVerifier
                public boolean isInRange(int i) {
                    return OutputType.forNumber(i) != null;
                }
            }

            OutputType(int i) {
                this.value = i;
            }
        }

        public enum Activation implements Internal.EnumLite {
            NONE(0),
            SIGMOID(1),
            SOFTMAX(2);

            public static final int NONE_VALUE = 0;
            public static final int SIGMOID_VALUE = 1;
            public static final int SOFTMAX_VALUE = 2;
            private static final Internal.EnumLiteMap<Activation> internalValueMap = new Internal.EnumLiteMap<Activation>() { // from class: com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptions.Activation.1
                @Override // com.google.protobuf.Internal.EnumLiteMap
                public Activation findValueByNumber(int i) {
                    return Activation.forNumber(i);
                }
            };
            private final int value;

            @Override // com.google.protobuf.Internal.EnumLite
            public final int getNumber() {
                return this.value;
            }

            @Deprecated
            public static Activation valueOf(int i) {
                return forNumber(i);
            }

            public static Activation forNumber(int i) {
                if (i == 0) {
                    return NONE;
                }
                if (i == 1) {
                    return SIGMOID;
                }
                if (i != 2) {
                    return null;
                }
                return SOFTMAX;
            }

            public static Internal.EnumLiteMap<Activation> internalGetValueMap() {
                return internalValueMap;
            }

            public static Internal.EnumVerifier internalGetVerifier() {
                return ActivationVerifier.INSTANCE;
            }

            private static final class ActivationVerifier implements Internal.EnumVerifier {
                static final Internal.EnumVerifier INSTANCE = new ActivationVerifier();

                private ActivationVerifier() {
                }

                @Override // com.google.protobuf.Internal.EnumVerifier
                public boolean isInRange(int i) {
                    return Activation.forNumber(i) != null;
                }
            }

            Activation(int i) {
                this.value = i;
            }
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
        @Deprecated
        public boolean hasOutputType() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
        @Deprecated
        public OutputType getOutputType() {
            OutputType outputTypeForNumber = OutputType.forNumber(this.outputType_);
            return outputTypeForNumber == null ? OutputType.UNSPECIFIED : outputTypeForNumber;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputType(OutputType outputType) {
            this.outputType_ = outputType.getNumber();
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOutputType() {
            this.bitField0_ &= -2;
            this.outputType_ = 0;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
        public boolean hasActivation() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
        public Activation getActivation() {
            Activation activationForNumber = Activation.forNumber(this.activation_);
            return activationForNumber == null ? Activation.NONE : activationForNumber;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setActivation(Activation activation) {
            this.activation_ = activation.getNumber();
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearActivation() {
            this.bitField0_ &= -3;
            this.activation_ = 0;
        }

        public static SegmenterOptions parseFrom(ByteBuffer byteBuffer) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static SegmenterOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static SegmenterOptions parseFrom(ByteString byteString) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static SegmenterOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static SegmenterOptions parseFrom(byte[] bArr) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static SegmenterOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static SegmenterOptions parseFrom(InputStream inputStream) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static SegmenterOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static SegmenterOptions parseDelimitedFrom(InputStream inputStream) {
            return (SegmenterOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static SegmenterOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (SegmenterOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static SegmenterOptions parseFrom(CodedInputStream codedInputStream) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static SegmenterOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (SegmenterOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(SegmenterOptions segmenterOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(segmenterOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<SegmenterOptions, Builder> implements SegmenterOptionsOrBuilder {
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
                super(SegmenterOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
            @Deprecated
            public boolean hasOutputType() {
                return ((SegmenterOptions) this.instance).hasOutputType();
            }

            @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
            @Deprecated
            public OutputType getOutputType() {
                return ((SegmenterOptions) this.instance).getOutputType();
            }

            @Deprecated
            public Builder setOutputType(OutputType outputType) {
                copyOnWrite();
                ((SegmenterOptions) this.instance).setOutputType(outputType);
                return this;
            }

            @Deprecated
            public Builder clearOutputType() {
                copyOnWrite();
                ((SegmenterOptions) this.instance).clearOutputType();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
            public boolean hasActivation() {
                return ((SegmenterOptions) this.instance).hasActivation();
            }

            @Override // com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto.SegmenterOptionsOrBuilder
            public Activation getActivation() {
                return ((SegmenterOptions) this.instance).getActivation();
            }

            public Builder setActivation(Activation activation) {
                copyOnWrite();
                ((SegmenterOptions) this.instance).setActivation(activation);
                return this;
            }

            public Builder clearActivation() {
                copyOnWrite();
                ((SegmenterOptions) this.instance).clearActivation();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new SegmenterOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001᠌\u0000\u0002᠌\u0001", new Object[]{"bitField0_", "outputType_", OutputType.internalGetVerifier(), "activation_", Activation.internalGetVerifier()});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<SegmenterOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (SegmenterOptions.class) {
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
            SegmenterOptions segmenterOptions = new SegmenterOptions();
            DEFAULT_INSTANCE = segmenterOptions;
            GeneratedMessageLite.registerDefaultInstance(SegmenterOptions.class, segmenterOptions);
        }

        public static SegmenterOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<SegmenterOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto$1, reason: invalid class name */
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
