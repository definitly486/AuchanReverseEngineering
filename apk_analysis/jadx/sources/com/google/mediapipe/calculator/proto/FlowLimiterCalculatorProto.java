package com.google.mediapipe.calculator.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import com.google.protobuf.WireFormat;
import java.io.InputStream;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public final class FlowLimiterCalculatorProto {

    public interface FlowLimiterCalculatorOptionsOrBuilder extends MessageLiteOrBuilder {
        long getInFlightTimeout();

        int getMaxInFlight();

        int getMaxInQueue();

        boolean hasInFlightTimeout();

        boolean hasMaxInFlight();

        boolean hasMaxInQueue();
    }

    private FlowLimiterCalculatorProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) FlowLimiterCalculatorOptions.ext);
    }

    public static final class FlowLimiterCalculatorOptions extends GeneratedMessageLite<FlowLimiterCalculatorOptions, Builder> implements FlowLimiterCalculatorOptionsOrBuilder {
        private static final FlowLimiterCalculatorOptions DEFAULT_INSTANCE;
        public static final int EXT_FIELD_NUMBER = 326963320;
        public static final int IN_FLIGHT_TIMEOUT_FIELD_NUMBER = 3;
        public static final int MAX_IN_FLIGHT_FIELD_NUMBER = 1;
        public static final int MAX_IN_QUEUE_FIELD_NUMBER = 2;
        private static volatile Parser<FlowLimiterCalculatorOptions> PARSER;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, FlowLimiterCalculatorOptions> ext;
        private int bitField0_;
        private long inFlightTimeout_;
        private int maxInFlight_ = 1;
        private int maxInQueue_;

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

        private FlowLimiterCalculatorOptions() {
        }

        @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
        public boolean hasMaxInFlight() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
        public int getMaxInFlight() {
            return this.maxInFlight_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMaxInFlight(int i) {
            this.bitField0_ |= 1;
            this.maxInFlight_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMaxInFlight() {
            this.bitField0_ &= -2;
            this.maxInFlight_ = 1;
        }

        @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
        public boolean hasMaxInQueue() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
        public int getMaxInQueue() {
            return this.maxInQueue_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMaxInQueue(int i) {
            this.bitField0_ |= 2;
            this.maxInQueue_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMaxInQueue() {
            this.bitField0_ &= -3;
            this.maxInQueue_ = 0;
        }

        @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
        public boolean hasInFlightTimeout() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
        public long getInFlightTimeout() {
            return this.inFlightTimeout_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInFlightTimeout(long j) {
            this.bitField0_ |= 4;
            this.inFlightTimeout_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInFlightTimeout() {
            this.bitField0_ &= -5;
            this.inFlightTimeout_ = 0L;
        }

        public static FlowLimiterCalculatorOptions parseFrom(ByteBuffer byteBuffer) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static FlowLimiterCalculatorOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static FlowLimiterCalculatorOptions parseFrom(ByteString byteString) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static FlowLimiterCalculatorOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static FlowLimiterCalculatorOptions parseFrom(byte[] bArr) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static FlowLimiterCalculatorOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static FlowLimiterCalculatorOptions parseFrom(InputStream inputStream) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FlowLimiterCalculatorOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FlowLimiterCalculatorOptions parseDelimitedFrom(InputStream inputStream) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FlowLimiterCalculatorOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FlowLimiterCalculatorOptions parseFrom(CodedInputStream codedInputStream) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static FlowLimiterCalculatorOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FlowLimiterCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(FlowLimiterCalculatorOptions flowLimiterCalculatorOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(flowLimiterCalculatorOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<FlowLimiterCalculatorOptions, Builder> implements FlowLimiterCalculatorOptionsOrBuilder {
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
            /* JADX INFO: renamed from: clone, reason: collision with other method in class */
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
                super(FlowLimiterCalculatorOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
            public boolean hasMaxInFlight() {
                return ((FlowLimiterCalculatorOptions) this.instance).hasMaxInFlight();
            }

            @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
            public int getMaxInFlight() {
                return ((FlowLimiterCalculatorOptions) this.instance).getMaxInFlight();
            }

            public Builder setMaxInFlight(int i) {
                copyOnWrite();
                ((FlowLimiterCalculatorOptions) this.instance).setMaxInFlight(i);
                return this;
            }

            public Builder clearMaxInFlight() {
                copyOnWrite();
                ((FlowLimiterCalculatorOptions) this.instance).clearMaxInFlight();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
            public boolean hasMaxInQueue() {
                return ((FlowLimiterCalculatorOptions) this.instance).hasMaxInQueue();
            }

            @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
            public int getMaxInQueue() {
                return ((FlowLimiterCalculatorOptions) this.instance).getMaxInQueue();
            }

            public Builder setMaxInQueue(int i) {
                copyOnWrite();
                ((FlowLimiterCalculatorOptions) this.instance).setMaxInQueue(i);
                return this;
            }

            public Builder clearMaxInQueue() {
                copyOnWrite();
                ((FlowLimiterCalculatorOptions) this.instance).clearMaxInQueue();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
            public boolean hasInFlightTimeout() {
                return ((FlowLimiterCalculatorOptions) this.instance).hasInFlightTimeout();
            }

            @Override // com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto.FlowLimiterCalculatorOptionsOrBuilder
            public long getInFlightTimeout() {
                return ((FlowLimiterCalculatorOptions) this.instance).getInFlightTimeout();
            }

            public Builder setInFlightTimeout(long j) {
                copyOnWrite();
                ((FlowLimiterCalculatorOptions) this.instance).setInFlightTimeout(j);
                return this;
            }

            public Builder clearInFlightTimeout() {
                copyOnWrite();
                ((FlowLimiterCalculatorOptions) this.instance).clearInFlightTimeout();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new FlowLimiterCalculatorOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001င\u0000\u0002င\u0001\u0003ဂ\u0002", new Object[]{"bitField0_", "maxInFlight_", "maxInQueue_", "inFlightTimeout_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<FlowLimiterCalculatorOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (FlowLimiterCalculatorOptions.class) {
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
            FlowLimiterCalculatorOptions flowLimiterCalculatorOptions = new FlowLimiterCalculatorOptions();
            DEFAULT_INSTANCE = flowLimiterCalculatorOptions;
            GeneratedMessageLite.registerDefaultInstance(FlowLimiterCalculatorOptions.class, flowLimiterCalculatorOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, FlowLimiterCalculatorOptions.class);
        }

        public static FlowLimiterCalculatorOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<FlowLimiterCalculatorOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.calculator.proto.FlowLimiterCalculatorProto$1, reason: invalid class name */
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
