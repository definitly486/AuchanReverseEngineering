package com.google.mediapipe.proto;

import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.Any;
import com.google.protobuf.AnyOrBuilder;
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
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class CalculatorProto {

    public interface CalculatorGraphConfigOrBuilder extends MessageLiteOrBuilder {
        ExecutorConfig getExecutor(int i);

        int getExecutorCount();

        List<ExecutorConfig> getExecutorList();

        Any getGraphOptions(int i);

        int getGraphOptionsCount();

        List<Any> getGraphOptionsList();

        String getInputSidePacket(int i);

        ByteString getInputSidePacketBytes(int i);

        int getInputSidePacketCount();

        List<String> getInputSidePacketList();

        String getInputStream(int i);

        ByteString getInputStreamBytes(int i);

        int getInputStreamCount();

        StreamHandlerProto.InputStreamHandlerConfig getInputStreamHandler();

        List<String> getInputStreamList();

        int getMaxQueueSize();

        CalculatorGraphConfig.Node getNode(int i);

        int getNodeCount();

        List<CalculatorGraphConfig.Node> getNodeList();

        int getNumThreads();

        MediaPipeOptionsProto.MediaPipeOptions getOptions();

        String getOutputSidePacket(int i);

        ByteString getOutputSidePacketBytes(int i);

        int getOutputSidePacketCount();

        List<String> getOutputSidePacketList();

        String getOutputStream(int i);

        ByteString getOutputStreamBytes(int i);

        int getOutputStreamCount();

        StreamHandlerProto.OutputStreamHandlerConfig getOutputStreamHandler();

        List<String> getOutputStreamList();

        String getPackage();

        ByteString getPackageBytes();

        PacketFactoryProto.PacketFactoryConfig getPacketFactory(int i);

        int getPacketFactoryCount();

        List<PacketFactoryProto.PacketFactoryConfig> getPacketFactoryList();

        @Deprecated
        PacketGeneratorProto.PacketGeneratorConfig getPacketGenerator(int i);

        @Deprecated
        int getPacketGeneratorCount();

        @Deprecated
        List<PacketGeneratorProto.PacketGeneratorConfig> getPacketGeneratorList();

        ProfilerConfig getProfilerConfig();

        boolean getReportDeadlock();

        GraphRuntimeInfoConfig getRuntimeInfo();

        StatusHandlerProto.StatusHandlerConfig getStatusHandler(int i);

        int getStatusHandlerCount();

        List<StatusHandlerProto.StatusHandlerConfig> getStatusHandlerList();

        String getType();

        ByteString getTypeBytes();

        boolean hasInputStreamHandler();

        boolean hasOptions();

        boolean hasOutputStreamHandler();

        boolean hasProfilerConfig();

        boolean hasRuntimeInfo();
    }

    public interface ExecutorConfigOrBuilder extends MessageLiteOrBuilder {
        String getName();

        ByteString getNameBytes();

        MediaPipeOptionsProto.MediaPipeOptions getOptions();

        String getType();

        ByteString getTypeBytes();

        boolean hasOptions();
    }

    public interface GraphRuntimeInfoConfigOrBuilder extends MessageLiteOrBuilder {
        int getCapturePeriodMsec();

        boolean getEnableGraphRuntimeInfo();
    }

    public interface InputCollectionOrBuilder extends MessageLiteOrBuilder {
        String getExternalInputName(int i);

        ByteString getExternalInputNameBytes(int i);

        int getExternalInputNameCount();

        List<String> getExternalInputNameList();

        String getFileName();

        ByteString getFileNameBytes();

        InputCollection.InputType getInputType();

        int getInputTypeValue();

        String getName();

        ByteString getNameBytes();

        String getSidePacketName(int i);

        ByteString getSidePacketNameBytes(int i);

        int getSidePacketNameCount();

        List<String> getSidePacketNameList();
    }

    public interface InputCollectionSetOrBuilder extends MessageLiteOrBuilder {
        InputCollection getInputCollection(int i);

        int getInputCollectionCount();

        List<InputCollection> getInputCollectionList();
    }

    public interface InputStreamInfoOrBuilder extends MessageLiteOrBuilder {
        boolean getBackEdge();

        String getTagIndex();

        ByteString getTagIndexBytes();
    }

    public interface ProfilerConfigOrBuilder extends MessageLiteOrBuilder {
        String getCalculatorFilter();

        ByteString getCalculatorFilterBytes();

        @Deprecated
        boolean getEnableInputOutputLatency();

        boolean getEnableProfiler();

        boolean getEnableStreamLatency();

        long getHistogramIntervalSizeUsec();

        long getNumHistogramIntervals();

        boolean getTraceEnabled();

        int getTraceEventTypesDisabled(int i);

        int getTraceEventTypesDisabledCount();

        List<Integer> getTraceEventTypesDisabledList();

        long getTraceLogCapacity();

        int getTraceLogCount();

        boolean getTraceLogDisabled();

        @Deprecated
        boolean getTraceLogDurationEvents();

        boolean getTraceLogInstantEvents();

        int getTraceLogIntervalCount();

        long getTraceLogIntervalUsec();

        long getTraceLogMarginUsec();

        String getTraceLogPath();

        ByteString getTraceLogPathBytes();

        boolean getUsePacketTimestampForAddedPacket();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private CalculatorProto() {
    }

    public static final class ExecutorConfig extends GeneratedMessageLite<ExecutorConfig, Builder> implements ExecutorConfigOrBuilder {
        private static final ExecutorConfig DEFAULT_INSTANCE;
        public static final int NAME_FIELD_NUMBER = 1;
        public static final int OPTIONS_FIELD_NUMBER = 3;
        private static volatile Parser<ExecutorConfig> PARSER = null;
        public static final int TYPE_FIELD_NUMBER = 2;
        private int bitField0_;
        private MediaPipeOptionsProto.MediaPipeOptions options_;
        private byte memoizedIsInitialized = 2;
        private String name_ = "";
        private String type_ = "";

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

        private ExecutorConfig() {
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
        public String getName() {
            return this.name_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
        public ByteString getNameBytes() {
            return ByteString.copyFromUtf8(this.name_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setName(String str) {
            str.getClass();
            this.name_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearName() {
            this.name_ = getDefaultInstance().getName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setNameBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.name_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
        public String getType() {
            return this.type_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
        public ByteString getTypeBytes() {
            return ByteString.copyFromUtf8(this.type_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setType(String str) {
            str.getClass();
            this.type_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearType() {
            this.type_ = getDefaultInstance().getType();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTypeBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.type_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
        public boolean hasOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
        public MediaPipeOptionsProto.MediaPipeOptions getOptions() {
            MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions = this.options_;
            return mediaPipeOptions == null ? MediaPipeOptionsProto.MediaPipeOptions.getDefaultInstance() : mediaPipeOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
            mediaPipeOptions.getClass();
            this.options_ = mediaPipeOptions;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        /* JADX WARN: Multi-variable type inference failed */
        public void mergeOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
            mediaPipeOptions.getClass();
            MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions2 = this.options_;
            if (mediaPipeOptions2 != null && mediaPipeOptions2 != MediaPipeOptionsProto.MediaPipeOptions.getDefaultInstance()) {
                this.options_ = ((MediaPipeOptionsProto.MediaPipeOptions.Builder) MediaPipeOptionsProto.MediaPipeOptions.newBuilder(this.options_).mergeFrom(mediaPipeOptions)).buildPartial();
            } else {
                this.options_ = mediaPipeOptions;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOptions() {
            this.options_ = null;
            this.bitField0_ &= -2;
        }

        public static ExecutorConfig parseFrom(ByteBuffer byteBuffer) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ExecutorConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ExecutorConfig parseFrom(ByteString byteString) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ExecutorConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ExecutorConfig parseFrom(byte[] bArr) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ExecutorConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ExecutorConfig parseFrom(InputStream inputStream) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ExecutorConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ExecutorConfig parseDelimitedFrom(InputStream inputStream) {
            return (ExecutorConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ExecutorConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ExecutorConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ExecutorConfig parseFrom(CodedInputStream codedInputStream) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ExecutorConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ExecutorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ExecutorConfig executorConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(executorConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ExecutorConfig, Builder> implements ExecutorConfigOrBuilder {
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
                super(ExecutorConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
            public String getName() {
                return ((ExecutorConfig) this.instance).getName();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
            public ByteString getNameBytes() {
                return ((ExecutorConfig) this.instance).getNameBytes();
            }

            public Builder setName(String str) {
                copyOnWrite();
                ((ExecutorConfig) this.instance).setName(str);
                return this;
            }

            public Builder clearName() {
                copyOnWrite();
                ((ExecutorConfig) this.instance).clearName();
                return this;
            }

            public Builder setNameBytes(ByteString byteString) {
                copyOnWrite();
                ((ExecutorConfig) this.instance).setNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
            public String getType() {
                return ((ExecutorConfig) this.instance).getType();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
            public ByteString getTypeBytes() {
                return ((ExecutorConfig) this.instance).getTypeBytes();
            }

            public Builder setType(String str) {
                copyOnWrite();
                ((ExecutorConfig) this.instance).setType(str);
                return this;
            }

            public Builder clearType() {
                copyOnWrite();
                ((ExecutorConfig) this.instance).clearType();
                return this;
            }

            public Builder setTypeBytes(ByteString byteString) {
                copyOnWrite();
                ((ExecutorConfig) this.instance).setTypeBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
            public boolean hasOptions() {
                return ((ExecutorConfig) this.instance).hasOptions();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ExecutorConfigOrBuilder
            public MediaPipeOptionsProto.MediaPipeOptions getOptions() {
                return ((ExecutorConfig) this.instance).getOptions();
            }

            public Builder setOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
                copyOnWrite();
                ((ExecutorConfig) this.instance).setOptions(mediaPipeOptions);
                return this;
            }

            /* JADX WARN: Multi-variable type inference failed */
            public Builder setOptions(MediaPipeOptionsProto.MediaPipeOptions.Builder builder) {
                copyOnWrite();
                ((ExecutorConfig) this.instance).setOptions((MediaPipeOptionsProto.MediaPipeOptions) builder.build());
                return this;
            }

            public Builder mergeOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
                copyOnWrite();
                ((ExecutorConfig) this.instance).mergeOptions(mediaPipeOptions);
                return this;
            }

            public Builder clearOptions() {
                copyOnWrite();
                ((ExecutorConfig) this.instance).clearOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ExecutorConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0001\u0001Ȉ\u0002Ȉ\u0003ᐉ\u0000", new Object[]{"bitField0_", "name_", "type_", "options_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ExecutorConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ExecutorConfig.class) {
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
                    return Byte.valueOf(this.memoizedIsInitialized);
                case 7:
                    this.memoizedIsInitialized = (byte) (obj == null ? 0 : 1);
                    return null;
                default:
                    throw new UnsupportedOperationException();
            }
        }

        static {
            ExecutorConfig executorConfig = new ExecutorConfig();
            DEFAULT_INSTANCE = executorConfig;
            GeneratedMessageLite.registerDefaultInstance(ExecutorConfig.class, executorConfig);
        }

        public static ExecutorConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ExecutorConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.proto.CalculatorProto$1, reason: invalid class name */
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

    public static final class InputCollection extends GeneratedMessageLite<InputCollection, Builder> implements InputCollectionOrBuilder {
        private static final InputCollection DEFAULT_INSTANCE;
        public static final int EXTERNAL_INPUT_NAME_FIELD_NUMBER = 1002;
        public static final int FILE_NAME_FIELD_NUMBER = 4;
        public static final int INPUT_TYPE_FIELD_NUMBER = 3;
        public static final int NAME_FIELD_NUMBER = 1;
        private static volatile Parser<InputCollection> PARSER = null;
        public static final int SIDE_PACKET_NAME_FIELD_NUMBER = 2;
        private int inputType_;
        private String name_ = "";
        private Internal.ProtobufList<String> sidePacketName_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> externalInputName_ = GeneratedMessageLite.emptyProtobufList();
        private String fileName_ = "";

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

        private InputCollection() {
        }

        public enum InputType implements Internal.EnumLite {
            UNKNOWN(0),
            RECORDIO(1),
            FOREIGN_RECORDIO(2),
            FOREIGN_CSV_TEXT(3),
            INVALID_UPPER_BOUND(4),
            UNRECOGNIZED(-1);

            public static final int FOREIGN_CSV_TEXT_VALUE = 3;
            public static final int FOREIGN_RECORDIO_VALUE = 2;
            public static final int INVALID_UPPER_BOUND_VALUE = 4;
            public static final int RECORDIO_VALUE = 1;
            public static final int UNKNOWN_VALUE = 0;
            private static final Internal.EnumLiteMap<InputType> internalValueMap = new Internal.EnumLiteMap<InputType>() { // from class: com.google.mediapipe.proto.CalculatorProto.InputCollection.InputType.1
                @Override // com.google.protobuf.Internal.EnumLiteMap
                public InputType findValueByNumber(int i) {
                    return InputType.forNumber(i);
                }
            };
            private final int value;

            @Override // com.google.protobuf.Internal.EnumLite
            public final int getNumber() {
                if (this == UNRECOGNIZED) {
                    throw new IllegalArgumentException("Can't get the number of an unknown enum value.");
                }
                return this.value;
            }

            @Deprecated
            public static InputType valueOf(int i) {
                return forNumber(i);
            }

            public static InputType forNumber(int i) {
                if (i == 0) {
                    return UNKNOWN;
                }
                if (i == 1) {
                    return RECORDIO;
                }
                if (i == 2) {
                    return FOREIGN_RECORDIO;
                }
                if (i == 3) {
                    return FOREIGN_CSV_TEXT;
                }
                if (i != 4) {
                    return null;
                }
                return INVALID_UPPER_BOUND;
            }

            public static Internal.EnumLiteMap<InputType> internalGetValueMap() {
                return internalValueMap;
            }

            public static Internal.EnumVerifier internalGetVerifier() {
                return InputTypeVerifier.INSTANCE;
            }

            private static final class InputTypeVerifier implements Internal.EnumVerifier {
                static final Internal.EnumVerifier INSTANCE = new InputTypeVerifier();

                private InputTypeVerifier() {
                }

                @Override // com.google.protobuf.Internal.EnumVerifier
                public boolean isInRange(int i) {
                    return InputType.forNumber(i) != null;
                }
            }

            InputType(int i) {
                this.value = i;
            }
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public String getName() {
            return this.name_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public ByteString getNameBytes() {
            return ByteString.copyFromUtf8(this.name_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setName(String str) {
            str.getClass();
            this.name_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearName() {
            this.name_ = getDefaultInstance().getName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setNameBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.name_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public List<String> getSidePacketNameList() {
            return this.sidePacketName_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public int getSidePacketNameCount() {
            return this.sidePacketName_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public String getSidePacketName(int i) {
            return this.sidePacketName_.get(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public ByteString getSidePacketNameBytes(int i) {
            return ByteString.copyFromUtf8(this.sidePacketName_.get(i));
        }

        private void ensureSidePacketNameIsMutable() {
            Internal.ProtobufList<String> protobufList = this.sidePacketName_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.sidePacketName_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setSidePacketName(int i, String str) {
            str.getClass();
            ensureSidePacketNameIsMutable();
            this.sidePacketName_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addSidePacketName(String str) {
            str.getClass();
            ensureSidePacketNameIsMutable();
            this.sidePacketName_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllSidePacketName(Iterable<String> iterable) {
            ensureSidePacketNameIsMutable();
            AbstractMessageLite.addAll(iterable, this.sidePacketName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearSidePacketName() {
            this.sidePacketName_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addSidePacketNameBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            ensureSidePacketNameIsMutable();
            this.sidePacketName_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public List<String> getExternalInputNameList() {
            return this.externalInputName_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public int getExternalInputNameCount() {
            return this.externalInputName_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public String getExternalInputName(int i) {
            return this.externalInputName_.get(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public ByteString getExternalInputNameBytes(int i) {
            return ByteString.copyFromUtf8(this.externalInputName_.get(i));
        }

        private void ensureExternalInputNameIsMutable() {
            Internal.ProtobufList<String> protobufList = this.externalInputName_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.externalInputName_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setExternalInputName(int i, String str) {
            str.getClass();
            ensureExternalInputNameIsMutable();
            this.externalInputName_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addExternalInputName(String str) {
            str.getClass();
            ensureExternalInputNameIsMutable();
            this.externalInputName_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllExternalInputName(Iterable<String> iterable) {
            ensureExternalInputNameIsMutable();
            AbstractMessageLite.addAll(iterable, this.externalInputName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearExternalInputName() {
            this.externalInputName_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addExternalInputNameBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            ensureExternalInputNameIsMutable();
            this.externalInputName_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public int getInputTypeValue() {
            return this.inputType_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public InputType getInputType() {
            InputType inputTypeForNumber = InputType.forNumber(this.inputType_);
            return inputTypeForNumber == null ? InputType.UNRECOGNIZED : inputTypeForNumber;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInputTypeValue(int i) {
            this.inputType_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInputType(InputType inputType) {
            this.inputType_ = inputType.getNumber();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInputType() {
            this.inputType_ = 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public String getFileName() {
            return this.fileName_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
        public ByteString getFileNameBytes() {
            return ByteString.copyFromUtf8(this.fileName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileName(String str) {
            str.getClass();
            this.fileName_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFileName() {
            this.fileName_ = getDefaultInstance().getFileName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileNameBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.fileName_ = byteString.toStringUtf8();
        }

        public static InputCollection parseFrom(ByteBuffer byteBuffer) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static InputCollection parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static InputCollection parseFrom(ByteString byteString) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static InputCollection parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static InputCollection parseFrom(byte[] bArr) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static InputCollection parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static InputCollection parseFrom(InputStream inputStream) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InputCollection parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InputCollection parseDelimitedFrom(InputStream inputStream) {
            return (InputCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InputCollection parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InputCollection parseFrom(CodedInputStream codedInputStream) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static InputCollection parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(InputCollection inputCollection) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(inputCollection);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<InputCollection, Builder> implements InputCollectionOrBuilder {
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
                super(InputCollection.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public String getName() {
                return ((InputCollection) this.instance).getName();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public ByteString getNameBytes() {
                return ((InputCollection) this.instance).getNameBytes();
            }

            public Builder setName(String str) {
                copyOnWrite();
                ((InputCollection) this.instance).setName(str);
                return this;
            }

            public Builder clearName() {
                copyOnWrite();
                ((InputCollection) this.instance).clearName();
                return this;
            }

            public Builder setNameBytes(ByteString byteString) {
                copyOnWrite();
                ((InputCollection) this.instance).setNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public List<String> getSidePacketNameList() {
                return Collections.unmodifiableList(((InputCollection) this.instance).getSidePacketNameList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public int getSidePacketNameCount() {
                return ((InputCollection) this.instance).getSidePacketNameCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public String getSidePacketName(int i) {
                return ((InputCollection) this.instance).getSidePacketName(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public ByteString getSidePacketNameBytes(int i) {
                return ((InputCollection) this.instance).getSidePacketNameBytes(i);
            }

            public Builder setSidePacketName(int i, String str) {
                copyOnWrite();
                ((InputCollection) this.instance).setSidePacketName(i, str);
                return this;
            }

            public Builder addSidePacketName(String str) {
                copyOnWrite();
                ((InputCollection) this.instance).addSidePacketName(str);
                return this;
            }

            public Builder addAllSidePacketName(Iterable<String> iterable) {
                copyOnWrite();
                ((InputCollection) this.instance).addAllSidePacketName(iterable);
                return this;
            }

            public Builder clearSidePacketName() {
                copyOnWrite();
                ((InputCollection) this.instance).clearSidePacketName();
                return this;
            }

            public Builder addSidePacketNameBytes(ByteString byteString) {
                copyOnWrite();
                ((InputCollection) this.instance).addSidePacketNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public List<String> getExternalInputNameList() {
                return Collections.unmodifiableList(((InputCollection) this.instance).getExternalInputNameList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public int getExternalInputNameCount() {
                return ((InputCollection) this.instance).getExternalInputNameCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public String getExternalInputName(int i) {
                return ((InputCollection) this.instance).getExternalInputName(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public ByteString getExternalInputNameBytes(int i) {
                return ((InputCollection) this.instance).getExternalInputNameBytes(i);
            }

            public Builder setExternalInputName(int i, String str) {
                copyOnWrite();
                ((InputCollection) this.instance).setExternalInputName(i, str);
                return this;
            }

            public Builder addExternalInputName(String str) {
                copyOnWrite();
                ((InputCollection) this.instance).addExternalInputName(str);
                return this;
            }

            public Builder addAllExternalInputName(Iterable<String> iterable) {
                copyOnWrite();
                ((InputCollection) this.instance).addAllExternalInputName(iterable);
                return this;
            }

            public Builder clearExternalInputName() {
                copyOnWrite();
                ((InputCollection) this.instance).clearExternalInputName();
                return this;
            }

            public Builder addExternalInputNameBytes(ByteString byteString) {
                copyOnWrite();
                ((InputCollection) this.instance).addExternalInputNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public int getInputTypeValue() {
                return ((InputCollection) this.instance).getInputTypeValue();
            }

            public Builder setInputTypeValue(int i) {
                copyOnWrite();
                ((InputCollection) this.instance).setInputTypeValue(i);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public InputType getInputType() {
                return ((InputCollection) this.instance).getInputType();
            }

            public Builder setInputType(InputType inputType) {
                copyOnWrite();
                ((InputCollection) this.instance).setInputType(inputType);
                return this;
            }

            public Builder clearInputType() {
                copyOnWrite();
                ((InputCollection) this.instance).clearInputType();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public String getFileName() {
                return ((InputCollection) this.instance).getFileName();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionOrBuilder
            public ByteString getFileNameBytes() {
                return ((InputCollection) this.instance).getFileNameBytes();
            }

            public Builder setFileName(String str) {
                copyOnWrite();
                ((InputCollection) this.instance).setFileName(str);
                return this;
            }

            public Builder clearFileName() {
                copyOnWrite();
                ((InputCollection) this.instance).clearFileName();
                return this;
            }

            public Builder setFileNameBytes(ByteString byteString) {
                copyOnWrite();
                ((InputCollection) this.instance).setFileNameBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new InputCollection();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0005\u0000\u0000\u0001Ϫ\u0005\u0000\u0002\u0000\u0001Ȉ\u0002Ț\u0003\f\u0004ȈϪȚ", new Object[]{"name_", "sidePacketName_", "inputType_", "fileName_", "externalInputName_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<InputCollection> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (InputCollection.class) {
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
            InputCollection inputCollection = new InputCollection();
            DEFAULT_INSTANCE = inputCollection;
            GeneratedMessageLite.registerDefaultInstance(InputCollection.class, inputCollection);
        }

        public static InputCollection getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<InputCollection> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class InputCollectionSet extends GeneratedMessageLite<InputCollectionSet, Builder> implements InputCollectionSetOrBuilder {
        private static final InputCollectionSet DEFAULT_INSTANCE;
        public static final int INPUT_COLLECTION_FIELD_NUMBER = 1;
        private static volatile Parser<InputCollectionSet> PARSER;
        private Internal.ProtobufList<InputCollection> inputCollection_ = GeneratedMessageLite.emptyProtobufList();

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

        private InputCollectionSet() {
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionSetOrBuilder
        public List<InputCollection> getInputCollectionList() {
            return this.inputCollection_;
        }

        public List<? extends InputCollectionOrBuilder> getInputCollectionOrBuilderList() {
            return this.inputCollection_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionSetOrBuilder
        public int getInputCollectionCount() {
            return this.inputCollection_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionSetOrBuilder
        public InputCollection getInputCollection(int i) {
            return this.inputCollection_.get(i);
        }

        public InputCollectionOrBuilder getInputCollectionOrBuilder(int i) {
            return this.inputCollection_.get(i);
        }

        private void ensureInputCollectionIsMutable() {
            Internal.ProtobufList<InputCollection> protobufList = this.inputCollection_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.inputCollection_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInputCollection(int i, InputCollection inputCollection) {
            inputCollection.getClass();
            ensureInputCollectionIsMutable();
            this.inputCollection_.set(i, inputCollection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInputCollection(InputCollection inputCollection) {
            inputCollection.getClass();
            ensureInputCollectionIsMutable();
            this.inputCollection_.add(inputCollection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInputCollection(int i, InputCollection inputCollection) {
            inputCollection.getClass();
            ensureInputCollectionIsMutable();
            this.inputCollection_.add(i, inputCollection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllInputCollection(Iterable<? extends InputCollection> iterable) {
            ensureInputCollectionIsMutable();
            AbstractMessageLite.addAll(iterable, this.inputCollection_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInputCollection() {
            this.inputCollection_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeInputCollection(int i) {
            ensureInputCollectionIsMutable();
            this.inputCollection_.remove(i);
        }

        public static InputCollectionSet parseFrom(ByteBuffer byteBuffer) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static InputCollectionSet parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static InputCollectionSet parseFrom(ByteString byteString) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static InputCollectionSet parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static InputCollectionSet parseFrom(byte[] bArr) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static InputCollectionSet parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static InputCollectionSet parseFrom(InputStream inputStream) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InputCollectionSet parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InputCollectionSet parseDelimitedFrom(InputStream inputStream) {
            return (InputCollectionSet) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InputCollectionSet parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollectionSet) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InputCollectionSet parseFrom(CodedInputStream codedInputStream) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static InputCollectionSet parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputCollectionSet) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(InputCollectionSet inputCollectionSet) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(inputCollectionSet);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<InputCollectionSet, Builder> implements InputCollectionSetOrBuilder {
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
                super(InputCollectionSet.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionSetOrBuilder
            public List<InputCollection> getInputCollectionList() {
                return Collections.unmodifiableList(((InputCollectionSet) this.instance).getInputCollectionList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionSetOrBuilder
            public int getInputCollectionCount() {
                return ((InputCollectionSet) this.instance).getInputCollectionCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputCollectionSetOrBuilder
            public InputCollection getInputCollection(int i) {
                return ((InputCollectionSet) this.instance).getInputCollection(i);
            }

            public Builder setInputCollection(int i, InputCollection inputCollection) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).setInputCollection(i, inputCollection);
                return this;
            }

            public Builder setInputCollection(int i, InputCollection.Builder builder) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).setInputCollection(i, builder.build());
                return this;
            }

            public Builder addInputCollection(InputCollection inputCollection) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).addInputCollection(inputCollection);
                return this;
            }

            public Builder addInputCollection(int i, InputCollection inputCollection) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).addInputCollection(i, inputCollection);
                return this;
            }

            public Builder addInputCollection(InputCollection.Builder builder) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).addInputCollection(builder.build());
                return this;
            }

            public Builder addInputCollection(int i, InputCollection.Builder builder) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).addInputCollection(i, builder.build());
                return this;
            }

            public Builder addAllInputCollection(Iterable<? extends InputCollection> iterable) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).addAllInputCollection(iterable);
                return this;
            }

            public Builder clearInputCollection() {
                copyOnWrite();
                ((InputCollectionSet) this.instance).clearInputCollection();
                return this;
            }

            public Builder removeInputCollection(int i) {
                copyOnWrite();
                ((InputCollectionSet) this.instance).removeInputCollection(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new InputCollectionSet();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"inputCollection_", InputCollection.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<InputCollectionSet> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (InputCollectionSet.class) {
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
            InputCollectionSet inputCollectionSet = new InputCollectionSet();
            DEFAULT_INSTANCE = inputCollectionSet;
            GeneratedMessageLite.registerDefaultInstance(InputCollectionSet.class, inputCollectionSet);
        }

        public static InputCollectionSet getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<InputCollectionSet> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class InputStreamInfo extends GeneratedMessageLite<InputStreamInfo, Builder> implements InputStreamInfoOrBuilder {
        public static final int BACK_EDGE_FIELD_NUMBER = 2;
        private static final InputStreamInfo DEFAULT_INSTANCE;
        private static volatile Parser<InputStreamInfo> PARSER = null;
        public static final int TAG_INDEX_FIELD_NUMBER = 1;
        private boolean backEdge_;
        private String tagIndex_ = "";

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

        private InputStreamInfo() {
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputStreamInfoOrBuilder
        public String getTagIndex() {
            return this.tagIndex_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputStreamInfoOrBuilder
        public ByteString getTagIndexBytes() {
            return ByteString.copyFromUtf8(this.tagIndex_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTagIndex(String str) {
            str.getClass();
            this.tagIndex_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTagIndex() {
            this.tagIndex_ = getDefaultInstance().getTagIndex();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTagIndexBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.tagIndex_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.InputStreamInfoOrBuilder
        public boolean getBackEdge() {
            return this.backEdge_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setBackEdge(boolean z) {
            this.backEdge_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearBackEdge() {
            this.backEdge_ = false;
        }

        public static InputStreamInfo parseFrom(ByteBuffer byteBuffer) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static InputStreamInfo parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static InputStreamInfo parseFrom(ByteString byteString) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static InputStreamInfo parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static InputStreamInfo parseFrom(byte[] bArr) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static InputStreamInfo parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static InputStreamInfo parseFrom(InputStream inputStream) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InputStreamInfo parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InputStreamInfo parseDelimitedFrom(InputStream inputStream) {
            return (InputStreamInfo) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static InputStreamInfo parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputStreamInfo) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static InputStreamInfo parseFrom(CodedInputStream codedInputStream) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static InputStreamInfo parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (InputStreamInfo) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(InputStreamInfo inputStreamInfo) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(inputStreamInfo);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<InputStreamInfo, Builder> implements InputStreamInfoOrBuilder {
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
                super(InputStreamInfo.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputStreamInfoOrBuilder
            public String getTagIndex() {
                return ((InputStreamInfo) this.instance).getTagIndex();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputStreamInfoOrBuilder
            public ByteString getTagIndexBytes() {
                return ((InputStreamInfo) this.instance).getTagIndexBytes();
            }

            public Builder setTagIndex(String str) {
                copyOnWrite();
                ((InputStreamInfo) this.instance).setTagIndex(str);
                return this;
            }

            public Builder clearTagIndex() {
                copyOnWrite();
                ((InputStreamInfo) this.instance).clearTagIndex();
                return this;
            }

            public Builder setTagIndexBytes(ByteString byteString) {
                copyOnWrite();
                ((InputStreamInfo) this.instance).setTagIndexBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.InputStreamInfoOrBuilder
            public boolean getBackEdge() {
                return ((InputStreamInfo) this.instance).getBackEdge();
            }

            public Builder setBackEdge(boolean z) {
                copyOnWrite();
                ((InputStreamInfo) this.instance).setBackEdge(z);
                return this;
            }

            public Builder clearBackEdge() {
                copyOnWrite();
                ((InputStreamInfo) this.instance).clearBackEdge();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new InputStreamInfo();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0002\u0000\u0000\u0001\u0002\u0002\u0000\u0000\u0000\u0001Ȉ\u0002\u0007", new Object[]{"tagIndex_", "backEdge_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<InputStreamInfo> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (InputStreamInfo.class) {
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
            InputStreamInfo inputStreamInfo = new InputStreamInfo();
            DEFAULT_INSTANCE = inputStreamInfo;
            GeneratedMessageLite.registerDefaultInstance(InputStreamInfo.class, inputStreamInfo);
        }

        public static InputStreamInfo getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<InputStreamInfo> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class ProfilerConfig extends GeneratedMessageLite<ProfilerConfig, Builder> implements ProfilerConfigOrBuilder {
        public static final int CALCULATOR_FILTER_FIELD_NUMBER = 18;
        private static final ProfilerConfig DEFAULT_INSTANCE;
        public static final int ENABLE_INPUT_OUTPUT_LATENCY_FIELD_NUMBER = 3;
        public static final int ENABLE_PROFILER_FIELD_NUMBER = 4;
        public static final int ENABLE_STREAM_LATENCY_FIELD_NUMBER = 5;
        public static final int HISTOGRAM_INTERVAL_SIZE_USEC_FIELD_NUMBER = 1;
        public static final int NUM_HISTOGRAM_INTERVALS_FIELD_NUMBER = 2;
        private static volatile Parser<ProfilerConfig> PARSER = null;
        public static final int TRACE_ENABLED_FIELD_NUMBER = 16;
        public static final int TRACE_EVENT_TYPES_DISABLED_FIELD_NUMBER = 8;
        public static final int TRACE_LOG_CAPACITY_FIELD_NUMBER = 7;
        public static final int TRACE_LOG_COUNT_FIELD_NUMBER = 10;
        public static final int TRACE_LOG_DISABLED_FIELD_NUMBER = 15;
        public static final int TRACE_LOG_DURATION_EVENTS_FIELD_NUMBER = 13;
        public static final int TRACE_LOG_INSTANT_EVENTS_FIELD_NUMBER = 17;
        public static final int TRACE_LOG_INTERVAL_COUNT_FIELD_NUMBER = 14;
        public static final int TRACE_LOG_INTERVAL_USEC_FIELD_NUMBER = 11;
        public static final int TRACE_LOG_MARGIN_USEC_FIELD_NUMBER = 12;
        public static final int TRACE_LOG_PATH_FIELD_NUMBER = 9;
        public static final int USE_PACKET_TIMESTAMP_FOR_ADDED_PACKET_FIELD_NUMBER = 6;
        private boolean enableInputOutputLatency_;
        private boolean enableProfiler_;
        private boolean enableStreamLatency_;
        private long histogramIntervalSizeUsec_;
        private long numHistogramIntervals_;
        private boolean traceEnabled_;
        private long traceLogCapacity_;
        private int traceLogCount_;
        private boolean traceLogDisabled_;
        private boolean traceLogDurationEvents_;
        private boolean traceLogInstantEvents_;
        private int traceLogIntervalCount_;
        private long traceLogIntervalUsec_;
        private long traceLogMarginUsec_;
        private boolean usePacketTimestampForAddedPacket_;
        private int traceEventTypesDisabledMemoizedSerializedSize = -1;
        private Internal.IntList traceEventTypesDisabled_ = GeneratedMessageLite.emptyIntList();
        private String traceLogPath_ = "";
        private String calculatorFilter_ = "";

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

        private ProfilerConfig() {
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public long getHistogramIntervalSizeUsec() {
            return this.histogramIntervalSizeUsec_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHistogramIntervalSizeUsec(long j) {
            this.histogramIntervalSizeUsec_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHistogramIntervalSizeUsec() {
            this.histogramIntervalSizeUsec_ = 0L;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public long getNumHistogramIntervals() {
            return this.numHistogramIntervals_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setNumHistogramIntervals(long j) {
            this.numHistogramIntervals_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearNumHistogramIntervals() {
            this.numHistogramIntervals_ = 0L;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        @Deprecated
        public boolean getEnableInputOutputLatency() {
            return this.enableInputOutputLatency_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setEnableInputOutputLatency(boolean z) {
            this.enableInputOutputLatency_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearEnableInputOutputLatency() {
            this.enableInputOutputLatency_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public boolean getEnableProfiler() {
            return this.enableProfiler_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setEnableProfiler(boolean z) {
            this.enableProfiler_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearEnableProfiler() {
            this.enableProfiler_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public boolean getEnableStreamLatency() {
            return this.enableStreamLatency_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setEnableStreamLatency(boolean z) {
            this.enableStreamLatency_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearEnableStreamLatency() {
            this.enableStreamLatency_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public boolean getUsePacketTimestampForAddedPacket() {
            return this.usePacketTimestampForAddedPacket_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setUsePacketTimestampForAddedPacket(boolean z) {
            this.usePacketTimestampForAddedPacket_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearUsePacketTimestampForAddedPacket() {
            this.usePacketTimestampForAddedPacket_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public long getTraceLogCapacity() {
            return this.traceLogCapacity_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogCapacity(long j) {
            this.traceLogCapacity_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogCapacity() {
            this.traceLogCapacity_ = 0L;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public List<Integer> getTraceEventTypesDisabledList() {
            return this.traceEventTypesDisabled_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public int getTraceEventTypesDisabledCount() {
            return this.traceEventTypesDisabled_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public int getTraceEventTypesDisabled(int i) {
            return this.traceEventTypesDisabled_.getInt(i);
        }

        private void ensureTraceEventTypesDisabledIsMutable() {
            Internal.IntList intList = this.traceEventTypesDisabled_;
            if (intList.isModifiable()) {
                return;
            }
            this.traceEventTypesDisabled_ = GeneratedMessageLite.mutableCopy(intList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceEventTypesDisabled(int i, int i2) {
            ensureTraceEventTypesDisabledIsMutable();
            this.traceEventTypesDisabled_.setInt(i, i2);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addTraceEventTypesDisabled(int i) {
            ensureTraceEventTypesDisabledIsMutable();
            this.traceEventTypesDisabled_.addInt(i);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllTraceEventTypesDisabled(Iterable<? extends Integer> iterable) {
            ensureTraceEventTypesDisabledIsMutable();
            AbstractMessageLite.addAll(iterable, this.traceEventTypesDisabled_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceEventTypesDisabled() {
            this.traceEventTypesDisabled_ = GeneratedMessageLite.emptyIntList();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public String getTraceLogPath() {
            return this.traceLogPath_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public ByteString getTraceLogPathBytes() {
            return ByteString.copyFromUtf8(this.traceLogPath_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogPath(String str) {
            str.getClass();
            this.traceLogPath_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogPath() {
            this.traceLogPath_ = getDefaultInstance().getTraceLogPath();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogPathBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.traceLogPath_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public int getTraceLogCount() {
            return this.traceLogCount_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogCount(int i) {
            this.traceLogCount_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogCount() {
            this.traceLogCount_ = 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public long getTraceLogIntervalUsec() {
            return this.traceLogIntervalUsec_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogIntervalUsec(long j) {
            this.traceLogIntervalUsec_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogIntervalUsec() {
            this.traceLogIntervalUsec_ = 0L;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public long getTraceLogMarginUsec() {
            return this.traceLogMarginUsec_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogMarginUsec(long j) {
            this.traceLogMarginUsec_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogMarginUsec() {
            this.traceLogMarginUsec_ = 0L;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        @Deprecated
        public boolean getTraceLogDurationEvents() {
            return this.traceLogDurationEvents_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogDurationEvents(boolean z) {
            this.traceLogDurationEvents_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogDurationEvents() {
            this.traceLogDurationEvents_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public int getTraceLogIntervalCount() {
            return this.traceLogIntervalCount_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogIntervalCount(int i) {
            this.traceLogIntervalCount_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogIntervalCount() {
            this.traceLogIntervalCount_ = 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public boolean getTraceLogDisabled() {
            return this.traceLogDisabled_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogDisabled(boolean z) {
            this.traceLogDisabled_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogDisabled() {
            this.traceLogDisabled_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public boolean getTraceEnabled() {
            return this.traceEnabled_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceEnabled(boolean z) {
            this.traceEnabled_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceEnabled() {
            this.traceEnabled_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public boolean getTraceLogInstantEvents() {
            return this.traceLogInstantEvents_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTraceLogInstantEvents(boolean z) {
            this.traceLogInstantEvents_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTraceLogInstantEvents() {
            this.traceLogInstantEvents_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public String getCalculatorFilter() {
            return this.calculatorFilter_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
        public ByteString getCalculatorFilterBytes() {
            return ByteString.copyFromUtf8(this.calculatorFilter_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCalculatorFilter(String str) {
            str.getClass();
            this.calculatorFilter_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCalculatorFilter() {
            this.calculatorFilter_ = getDefaultInstance().getCalculatorFilter();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCalculatorFilterBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.calculatorFilter_ = byteString.toStringUtf8();
        }

        public static ProfilerConfig parseFrom(ByteBuffer byteBuffer) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ProfilerConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ProfilerConfig parseFrom(ByteString byteString) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ProfilerConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ProfilerConfig parseFrom(byte[] bArr) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ProfilerConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ProfilerConfig parseFrom(InputStream inputStream) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ProfilerConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ProfilerConfig parseDelimitedFrom(InputStream inputStream) {
            return (ProfilerConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ProfilerConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ProfilerConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ProfilerConfig parseFrom(CodedInputStream codedInputStream) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ProfilerConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ProfilerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ProfilerConfig profilerConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(profilerConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ProfilerConfig, Builder> implements ProfilerConfigOrBuilder {
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
                super(ProfilerConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public long getHistogramIntervalSizeUsec() {
                return ((ProfilerConfig) this.instance).getHistogramIntervalSizeUsec();
            }

            public Builder setHistogramIntervalSizeUsec(long j) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setHistogramIntervalSizeUsec(j);
                return this;
            }

            public Builder clearHistogramIntervalSizeUsec() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearHistogramIntervalSizeUsec();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public long getNumHistogramIntervals() {
                return ((ProfilerConfig) this.instance).getNumHistogramIntervals();
            }

            public Builder setNumHistogramIntervals(long j) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setNumHistogramIntervals(j);
                return this;
            }

            public Builder clearNumHistogramIntervals() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearNumHistogramIntervals();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            @Deprecated
            public boolean getEnableInputOutputLatency() {
                return ((ProfilerConfig) this.instance).getEnableInputOutputLatency();
            }

            @Deprecated
            public Builder setEnableInputOutputLatency(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setEnableInputOutputLatency(z);
                return this;
            }

            @Deprecated
            public Builder clearEnableInputOutputLatency() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearEnableInputOutputLatency();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public boolean getEnableProfiler() {
                return ((ProfilerConfig) this.instance).getEnableProfiler();
            }

            public Builder setEnableProfiler(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setEnableProfiler(z);
                return this;
            }

            public Builder clearEnableProfiler() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearEnableProfiler();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public boolean getEnableStreamLatency() {
                return ((ProfilerConfig) this.instance).getEnableStreamLatency();
            }

            public Builder setEnableStreamLatency(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setEnableStreamLatency(z);
                return this;
            }

            public Builder clearEnableStreamLatency() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearEnableStreamLatency();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public boolean getUsePacketTimestampForAddedPacket() {
                return ((ProfilerConfig) this.instance).getUsePacketTimestampForAddedPacket();
            }

            public Builder setUsePacketTimestampForAddedPacket(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setUsePacketTimestampForAddedPacket(z);
                return this;
            }

            public Builder clearUsePacketTimestampForAddedPacket() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearUsePacketTimestampForAddedPacket();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public long getTraceLogCapacity() {
                return ((ProfilerConfig) this.instance).getTraceLogCapacity();
            }

            public Builder setTraceLogCapacity(long j) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogCapacity(j);
                return this;
            }

            public Builder clearTraceLogCapacity() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogCapacity();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public List<Integer> getTraceEventTypesDisabledList() {
                return Collections.unmodifiableList(((ProfilerConfig) this.instance).getTraceEventTypesDisabledList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public int getTraceEventTypesDisabledCount() {
                return ((ProfilerConfig) this.instance).getTraceEventTypesDisabledCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public int getTraceEventTypesDisabled(int i) {
                return ((ProfilerConfig) this.instance).getTraceEventTypesDisabled(i);
            }

            public Builder setTraceEventTypesDisabled(int i, int i2) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceEventTypesDisabled(i, i2);
                return this;
            }

            public Builder addTraceEventTypesDisabled(int i) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).addTraceEventTypesDisabled(i);
                return this;
            }

            public Builder addAllTraceEventTypesDisabled(Iterable<? extends Integer> iterable) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).addAllTraceEventTypesDisabled(iterable);
                return this;
            }

            public Builder clearTraceEventTypesDisabled() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceEventTypesDisabled();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public String getTraceLogPath() {
                return ((ProfilerConfig) this.instance).getTraceLogPath();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public ByteString getTraceLogPathBytes() {
                return ((ProfilerConfig) this.instance).getTraceLogPathBytes();
            }

            public Builder setTraceLogPath(String str) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogPath(str);
                return this;
            }

            public Builder clearTraceLogPath() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogPath();
                return this;
            }

            public Builder setTraceLogPathBytes(ByteString byteString) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogPathBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public int getTraceLogCount() {
                return ((ProfilerConfig) this.instance).getTraceLogCount();
            }

            public Builder setTraceLogCount(int i) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogCount(i);
                return this;
            }

            public Builder clearTraceLogCount() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogCount();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public long getTraceLogIntervalUsec() {
                return ((ProfilerConfig) this.instance).getTraceLogIntervalUsec();
            }

            public Builder setTraceLogIntervalUsec(long j) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogIntervalUsec(j);
                return this;
            }

            public Builder clearTraceLogIntervalUsec() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogIntervalUsec();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public long getTraceLogMarginUsec() {
                return ((ProfilerConfig) this.instance).getTraceLogMarginUsec();
            }

            public Builder setTraceLogMarginUsec(long j) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogMarginUsec(j);
                return this;
            }

            public Builder clearTraceLogMarginUsec() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogMarginUsec();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            @Deprecated
            public boolean getTraceLogDurationEvents() {
                return ((ProfilerConfig) this.instance).getTraceLogDurationEvents();
            }

            @Deprecated
            public Builder setTraceLogDurationEvents(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogDurationEvents(z);
                return this;
            }

            @Deprecated
            public Builder clearTraceLogDurationEvents() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogDurationEvents();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public int getTraceLogIntervalCount() {
                return ((ProfilerConfig) this.instance).getTraceLogIntervalCount();
            }

            public Builder setTraceLogIntervalCount(int i) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogIntervalCount(i);
                return this;
            }

            public Builder clearTraceLogIntervalCount() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogIntervalCount();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public boolean getTraceLogDisabled() {
                return ((ProfilerConfig) this.instance).getTraceLogDisabled();
            }

            public Builder setTraceLogDisabled(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogDisabled(z);
                return this;
            }

            public Builder clearTraceLogDisabled() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogDisabled();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public boolean getTraceEnabled() {
                return ((ProfilerConfig) this.instance).getTraceEnabled();
            }

            public Builder setTraceEnabled(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceEnabled(z);
                return this;
            }

            public Builder clearTraceEnabled() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceEnabled();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public boolean getTraceLogInstantEvents() {
                return ((ProfilerConfig) this.instance).getTraceLogInstantEvents();
            }

            public Builder setTraceLogInstantEvents(boolean z) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setTraceLogInstantEvents(z);
                return this;
            }

            public Builder clearTraceLogInstantEvents() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearTraceLogInstantEvents();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public String getCalculatorFilter() {
                return ((ProfilerConfig) this.instance).getCalculatorFilter();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.ProfilerConfigOrBuilder
            public ByteString getCalculatorFilterBytes() {
                return ((ProfilerConfig) this.instance).getCalculatorFilterBytes();
            }

            public Builder setCalculatorFilter(String str) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setCalculatorFilter(str);
                return this;
            }

            public Builder clearCalculatorFilter() {
                copyOnWrite();
                ((ProfilerConfig) this.instance).clearCalculatorFilter();
                return this;
            }

            public Builder setCalculatorFilterBytes(ByteString byteString) {
                copyOnWrite();
                ((ProfilerConfig) this.instance).setCalculatorFilterBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ProfilerConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0012\u0000\u0000\u0001\u0012\u0012\u0000\u0001\u0000\u0001\u0002\u0002\u0002\u0003\u0007\u0004\u0007\u0005\u0007\u0006\u0007\u0007\u0002\b'\tȈ\n\u0004\u000b\u0002\f\u0002\r\u0007\u000e\u0004\u000f\u0007\u0010\u0007\u0011\u0007\u0012Ȉ", new Object[]{"histogramIntervalSizeUsec_", "numHistogramIntervals_", "enableInputOutputLatency_", "enableProfiler_", "enableStreamLatency_", "usePacketTimestampForAddedPacket_", "traceLogCapacity_", "traceEventTypesDisabled_", "traceLogPath_", "traceLogCount_", "traceLogIntervalUsec_", "traceLogMarginUsec_", "traceLogDurationEvents_", "traceLogIntervalCount_", "traceLogDisabled_", "traceEnabled_", "traceLogInstantEvents_", "calculatorFilter_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ProfilerConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ProfilerConfig.class) {
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
            ProfilerConfig profilerConfig = new ProfilerConfig();
            DEFAULT_INSTANCE = profilerConfig;
            GeneratedMessageLite.registerDefaultInstance(ProfilerConfig.class, profilerConfig);
        }

        public static ProfilerConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ProfilerConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class GraphRuntimeInfoConfig extends GeneratedMessageLite<GraphRuntimeInfoConfig, Builder> implements GraphRuntimeInfoConfigOrBuilder {
        public static final int CAPTURE_PERIOD_MSEC_FIELD_NUMBER = 2;
        private static final GraphRuntimeInfoConfig DEFAULT_INSTANCE;
        public static final int ENABLE_GRAPH_RUNTIME_INFO_FIELD_NUMBER = 1;
        private static volatile Parser<GraphRuntimeInfoConfig> PARSER;
        private int capturePeriodMsec_;
        private boolean enableGraphRuntimeInfo_;

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

        private GraphRuntimeInfoConfig() {
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.GraphRuntimeInfoConfigOrBuilder
        public boolean getEnableGraphRuntimeInfo() {
            return this.enableGraphRuntimeInfo_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setEnableGraphRuntimeInfo(boolean z) {
            this.enableGraphRuntimeInfo_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearEnableGraphRuntimeInfo() {
            this.enableGraphRuntimeInfo_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.GraphRuntimeInfoConfigOrBuilder
        public int getCapturePeriodMsec() {
            return this.capturePeriodMsec_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCapturePeriodMsec(int i) {
            this.capturePeriodMsec_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCapturePeriodMsec() {
            this.capturePeriodMsec_ = 0;
        }

        public static GraphRuntimeInfoConfig parseFrom(ByteBuffer byteBuffer) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static GraphRuntimeInfoConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static GraphRuntimeInfoConfig parseFrom(ByteString byteString) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static GraphRuntimeInfoConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static GraphRuntimeInfoConfig parseFrom(byte[] bArr) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static GraphRuntimeInfoConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static GraphRuntimeInfoConfig parseFrom(InputStream inputStream) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static GraphRuntimeInfoConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static GraphRuntimeInfoConfig parseDelimitedFrom(InputStream inputStream) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static GraphRuntimeInfoConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static GraphRuntimeInfoConfig parseFrom(CodedInputStream codedInputStream) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static GraphRuntimeInfoConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GraphRuntimeInfoConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(GraphRuntimeInfoConfig graphRuntimeInfoConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(graphRuntimeInfoConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<GraphRuntimeInfoConfig, Builder> implements GraphRuntimeInfoConfigOrBuilder {
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
                super(GraphRuntimeInfoConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.GraphRuntimeInfoConfigOrBuilder
            public boolean getEnableGraphRuntimeInfo() {
                return ((GraphRuntimeInfoConfig) this.instance).getEnableGraphRuntimeInfo();
            }

            public Builder setEnableGraphRuntimeInfo(boolean z) {
                copyOnWrite();
                ((GraphRuntimeInfoConfig) this.instance).setEnableGraphRuntimeInfo(z);
                return this;
            }

            public Builder clearEnableGraphRuntimeInfo() {
                copyOnWrite();
                ((GraphRuntimeInfoConfig) this.instance).clearEnableGraphRuntimeInfo();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.GraphRuntimeInfoConfigOrBuilder
            public int getCapturePeriodMsec() {
                return ((GraphRuntimeInfoConfig) this.instance).getCapturePeriodMsec();
            }

            public Builder setCapturePeriodMsec(int i) {
                copyOnWrite();
                ((GraphRuntimeInfoConfig) this.instance).setCapturePeriodMsec(i);
                return this;
            }

            public Builder clearCapturePeriodMsec() {
                copyOnWrite();
                ((GraphRuntimeInfoConfig) this.instance).clearCapturePeriodMsec();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new GraphRuntimeInfoConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0002\u0000\u0000\u0001\u0002\u0002\u0000\u0000\u0000\u0001\u0007\u0002\u000b", new Object[]{"enableGraphRuntimeInfo_", "capturePeriodMsec_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<GraphRuntimeInfoConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (GraphRuntimeInfoConfig.class) {
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
            GraphRuntimeInfoConfig graphRuntimeInfoConfig = new GraphRuntimeInfoConfig();
            DEFAULT_INSTANCE = graphRuntimeInfoConfig;
            GeneratedMessageLite.registerDefaultInstance(GraphRuntimeInfoConfig.class, graphRuntimeInfoConfig);
        }

        public static GraphRuntimeInfoConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<GraphRuntimeInfoConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class CalculatorGraphConfig extends GeneratedMessageLite<CalculatorGraphConfig, Builder> implements CalculatorGraphConfigOrBuilder {
        private static final CalculatorGraphConfig DEFAULT_INSTANCE;
        public static final int EXECUTOR_FIELD_NUMBER = 14;
        public static final int GRAPH_OPTIONS_FIELD_NUMBER = 1002;
        public static final int INPUT_SIDE_PACKET_FIELD_NUMBER = 16;
        public static final int INPUT_STREAM_FIELD_NUMBER = 10;
        public static final int INPUT_STREAM_HANDLER_FIELD_NUMBER = 12;
        public static final int MAX_QUEUE_SIZE_FIELD_NUMBER = 11;
        public static final int NODE_FIELD_NUMBER = 1;
        public static final int NUM_THREADS_FIELD_NUMBER = 8;
        public static final int OPTIONS_FIELD_NUMBER = 1001;
        public static final int OUTPUT_SIDE_PACKET_FIELD_NUMBER = 17;
        public static final int OUTPUT_STREAM_FIELD_NUMBER = 15;
        public static final int OUTPUT_STREAM_HANDLER_FIELD_NUMBER = 13;
        public static final int PACKAGE_FIELD_NUMBER = 19;
        public static final int PACKET_FACTORY_FIELD_NUMBER = 6;
        public static final int PACKET_GENERATOR_FIELD_NUMBER = 7;
        private static volatile Parser<CalculatorGraphConfig> PARSER = null;
        public static final int PROFILER_CONFIG_FIELD_NUMBER = 18;
        public static final int REPORT_DEADLOCK_FIELD_NUMBER = 21;
        public static final int RUNTIME_INFO_FIELD_NUMBER = 22;
        public static final int STATUS_HANDLER_FIELD_NUMBER = 9;
        public static final int TYPE_FIELD_NUMBER = 20;
        private int bitField0_;
        private StreamHandlerProto.InputStreamHandlerConfig inputStreamHandler_;
        private int maxQueueSize_;
        private int numThreads_;
        private MediaPipeOptionsProto.MediaPipeOptions options_;
        private StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandler_;
        private ProfilerConfig profilerConfig_;
        private boolean reportDeadlock_;
        private GraphRuntimeInfoConfig runtimeInfo_;
        private byte memoizedIsInitialized = 2;
        private Internal.ProtobufList<Node> node_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<PacketFactoryProto.PacketFactoryConfig> packetFactory_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<PacketGeneratorProto.PacketGeneratorConfig> packetGenerator_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<StatusHandlerProto.StatusHandlerConfig> statusHandler_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> inputStream_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> outputStream_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> inputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> outputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<ExecutorConfig> executor_ = GeneratedMessageLite.emptyProtobufList();
        private String package_ = "";
        private String type_ = "";
        private Internal.ProtobufList<Any> graphOptions_ = GeneratedMessageLite.emptyProtobufList();

        public interface NodeOrBuilder extends MessageLiteOrBuilder {
            int getBufferSizeHint();

            String getCalculator();

            ByteString getCalculatorBytes();

            String getExecutor();

            ByteString getExecutorBytes();

            String getExternalInput(int i);

            ByteString getExternalInputBytes(int i);

            int getExternalInputCount();

            List<String> getExternalInputList();

            String getInputSidePacket(int i);

            ByteString getInputSidePacketBytes(int i);

            int getInputSidePacketCount();

            List<String> getInputSidePacketList();

            String getInputStream(int i);

            ByteString getInputStreamBytes(int i);

            int getInputStreamCount();

            StreamHandlerProto.InputStreamHandlerConfig getInputStreamHandler();

            InputStreamInfo getInputStreamInfo(int i);

            int getInputStreamInfoCount();

            List<InputStreamInfo> getInputStreamInfoList();

            List<String> getInputStreamList();

            int getMaxInFlight();

            String getName();

            ByteString getNameBytes();

            Any getNodeOptions(int i);

            int getNodeOptionsCount();

            List<Any> getNodeOptionsList();

            String getOptionValue(int i);

            ByteString getOptionValueBytes(int i);

            int getOptionValueCount();

            List<String> getOptionValueList();

            CalculatorOptionsProto.CalculatorOptions getOptions();

            String getOutputSidePacket(int i);

            ByteString getOutputSidePacketBytes(int i);

            int getOutputSidePacketCount();

            List<String> getOutputSidePacketList();

            String getOutputStream(int i);

            ByteString getOutputStreamBytes(int i);

            int getOutputStreamCount();

            StreamHandlerProto.OutputStreamHandlerConfig getOutputStreamHandler();

            List<String> getOutputStreamList();

            @Deprecated
            ProfilerConfig getProfilerConfig();

            int getSourceLayer();

            boolean hasInputStreamHandler();

            boolean hasOptions();

            boolean hasOutputStreamHandler();

            @Deprecated
            boolean hasProfilerConfig();
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

        private CalculatorGraphConfig() {
        }

        public static final class Node extends GeneratedMessageLite<Node, Builder> implements NodeOrBuilder {
            public static final int BUFFER_SIZE_HINT_FIELD_NUMBER = 10;
            public static final int CALCULATOR_FIELD_NUMBER = 2;
            private static final Node DEFAULT_INSTANCE;
            public static final int EXECUTOR_FIELD_NUMBER = 14;
            public static final int EXTERNAL_INPUT_FIELD_NUMBER = 1005;
            public static final int INPUT_SIDE_PACKET_FIELD_NUMBER = 5;
            public static final int INPUT_STREAM_FIELD_NUMBER = 3;
            public static final int INPUT_STREAM_HANDLER_FIELD_NUMBER = 11;
            public static final int INPUT_STREAM_INFO_FIELD_NUMBER = 13;
            public static final int MAX_IN_FLIGHT_FIELD_NUMBER = 16;
            public static final int NAME_FIELD_NUMBER = 1;
            public static final int NODE_OPTIONS_FIELD_NUMBER = 8;
            public static final int OPTIONS_FIELD_NUMBER = 7;
            public static final int OPTION_VALUE_FIELD_NUMBER = 17;
            public static final int OUTPUT_SIDE_PACKET_FIELD_NUMBER = 6;
            public static final int OUTPUT_STREAM_FIELD_NUMBER = 4;
            public static final int OUTPUT_STREAM_HANDLER_FIELD_NUMBER = 12;
            private static volatile Parser<Node> PARSER = null;
            public static final int PROFILER_CONFIG_FIELD_NUMBER = 15;
            public static final int SOURCE_LAYER_FIELD_NUMBER = 9;
            private int bitField0_;
            private int bufferSizeHint_;
            private StreamHandlerProto.InputStreamHandlerConfig inputStreamHandler_;
            private int maxInFlight_;
            private CalculatorOptionsProto.CalculatorOptions options_;
            private StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandler_;
            private ProfilerConfig profilerConfig_;
            private int sourceLayer_;
            private byte memoizedIsInitialized = 2;
            private String name_ = "";
            private String calculator_ = "";
            private Internal.ProtobufList<String> inputStream_ = GeneratedMessageLite.emptyProtobufList();
            private Internal.ProtobufList<String> outputStream_ = GeneratedMessageLite.emptyProtobufList();
            private Internal.ProtobufList<String> inputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
            private Internal.ProtobufList<String> outputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
            private Internal.ProtobufList<Any> nodeOptions_ = GeneratedMessageLite.emptyProtobufList();
            private Internal.ProtobufList<InputStreamInfo> inputStreamInfo_ = GeneratedMessageLite.emptyProtobufList();
            private String executor_ = "";
            private Internal.ProtobufList<String> optionValue_ = GeneratedMessageLite.emptyProtobufList();
            private Internal.ProtobufList<String> externalInput_ = GeneratedMessageLite.emptyProtobufList();

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

            private Node() {
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getName() {
                return this.name_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getNameBytes() {
                return ByteString.copyFromUtf8(this.name_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setName(String str) {
                str.getClass();
                this.name_ = str;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearName() {
                this.name_ = getDefaultInstance().getName();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNameBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                this.name_ = byteString.toStringUtf8();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getCalculator() {
                return this.calculator_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getCalculatorBytes() {
                return ByteString.copyFromUtf8(this.calculator_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setCalculator(String str) {
                str.getClass();
                this.calculator_ = str;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearCalculator() {
                this.calculator_ = getDefaultInstance().getCalculator();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setCalculatorBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                this.calculator_ = byteString.toStringUtf8();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<String> getInputStreamList() {
                return this.inputStream_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getInputStreamCount() {
                return this.inputStream_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getInputStream(int i) {
                return this.inputStream_.get(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getInputStreamBytes(int i) {
                return ByteString.copyFromUtf8(this.inputStream_.get(i));
            }

            private void ensureInputStreamIsMutable() {
                Internal.ProtobufList<String> protobufList = this.inputStream_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.inputStream_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setInputStream(int i, String str) {
                str.getClass();
                ensureInputStreamIsMutable();
                this.inputStream_.set(i, str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addInputStream(String str) {
                str.getClass();
                ensureInputStreamIsMutable();
                this.inputStream_.add(str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllInputStream(Iterable<String> iterable) {
                ensureInputStreamIsMutable();
                AbstractMessageLite.addAll(iterable, this.inputStream_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearInputStream() {
                this.inputStream_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addInputStreamBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                ensureInputStreamIsMutable();
                this.inputStream_.add(byteString.toStringUtf8());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<String> getOutputStreamList() {
                return this.outputStream_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getOutputStreamCount() {
                return this.outputStream_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getOutputStream(int i) {
                return this.outputStream_.get(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getOutputStreamBytes(int i) {
                return ByteString.copyFromUtf8(this.outputStream_.get(i));
            }

            private void ensureOutputStreamIsMutable() {
                Internal.ProtobufList<String> protobufList = this.outputStream_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.outputStream_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOutputStream(int i, String str) {
                str.getClass();
                ensureOutputStreamIsMutable();
                this.outputStream_.set(i, str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addOutputStream(String str) {
                str.getClass();
                ensureOutputStreamIsMutable();
                this.outputStream_.add(str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllOutputStream(Iterable<String> iterable) {
                ensureOutputStreamIsMutable();
                AbstractMessageLite.addAll(iterable, this.outputStream_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutputStream() {
                this.outputStream_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addOutputStreamBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                ensureOutputStreamIsMutable();
                this.outputStream_.add(byteString.toStringUtf8());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<String> getInputSidePacketList() {
                return this.inputSidePacket_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getInputSidePacketCount() {
                return this.inputSidePacket_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getInputSidePacket(int i) {
                return this.inputSidePacket_.get(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getInputSidePacketBytes(int i) {
                return ByteString.copyFromUtf8(this.inputSidePacket_.get(i));
            }

            private void ensureInputSidePacketIsMutable() {
                Internal.ProtobufList<String> protobufList = this.inputSidePacket_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.inputSidePacket_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setInputSidePacket(int i, String str) {
                str.getClass();
                ensureInputSidePacketIsMutable();
                this.inputSidePacket_.set(i, str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addInputSidePacket(String str) {
                str.getClass();
                ensureInputSidePacketIsMutable();
                this.inputSidePacket_.add(str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllInputSidePacket(Iterable<String> iterable) {
                ensureInputSidePacketIsMutable();
                AbstractMessageLite.addAll(iterable, this.inputSidePacket_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearInputSidePacket() {
                this.inputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addInputSidePacketBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                ensureInputSidePacketIsMutable();
                this.inputSidePacket_.add(byteString.toStringUtf8());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<String> getOutputSidePacketList() {
                return this.outputSidePacket_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getOutputSidePacketCount() {
                return this.outputSidePacket_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getOutputSidePacket(int i) {
                return this.outputSidePacket_.get(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getOutputSidePacketBytes(int i) {
                return ByteString.copyFromUtf8(this.outputSidePacket_.get(i));
            }

            private void ensureOutputSidePacketIsMutable() {
                Internal.ProtobufList<String> protobufList = this.outputSidePacket_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.outputSidePacket_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOutputSidePacket(int i, String str) {
                str.getClass();
                ensureOutputSidePacketIsMutable();
                this.outputSidePacket_.set(i, str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addOutputSidePacket(String str) {
                str.getClass();
                ensureOutputSidePacketIsMutable();
                this.outputSidePacket_.add(str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllOutputSidePacket(Iterable<String> iterable) {
                ensureOutputSidePacketIsMutable();
                AbstractMessageLite.addAll(iterable, this.outputSidePacket_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutputSidePacket() {
                this.outputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addOutputSidePacketBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                ensureOutputSidePacketIsMutable();
                this.outputSidePacket_.add(byteString.toStringUtf8());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public boolean hasOptions() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public CalculatorOptionsProto.CalculatorOptions getOptions() {
                CalculatorOptionsProto.CalculatorOptions calculatorOptions = this.options_;
                return calculatorOptions == null ? CalculatorOptionsProto.CalculatorOptions.getDefaultInstance() : calculatorOptions;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOptions(CalculatorOptionsProto.CalculatorOptions calculatorOptions) {
                calculatorOptions.getClass();
                this.options_ = calculatorOptions;
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            /* JADX WARN: Multi-variable type inference failed */
            public void mergeOptions(CalculatorOptionsProto.CalculatorOptions calculatorOptions) {
                calculatorOptions.getClass();
                CalculatorOptionsProto.CalculatorOptions calculatorOptions2 = this.options_;
                if (calculatorOptions2 != null && calculatorOptions2 != CalculatorOptionsProto.CalculatorOptions.getDefaultInstance()) {
                    this.options_ = ((CalculatorOptionsProto.CalculatorOptions.Builder) CalculatorOptionsProto.CalculatorOptions.newBuilder(this.options_).mergeFrom(calculatorOptions)).buildPartial();
                } else {
                    this.options_ = calculatorOptions;
                }
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOptions() {
                this.options_ = null;
                this.bitField0_ &= -2;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<Any> getNodeOptionsList() {
                return this.nodeOptions_;
            }

            public List<? extends AnyOrBuilder> getNodeOptionsOrBuilderList() {
                return this.nodeOptions_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getNodeOptionsCount() {
                return this.nodeOptions_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public Any getNodeOptions(int i) {
                return this.nodeOptions_.get(i);
            }

            public AnyOrBuilder getNodeOptionsOrBuilder(int i) {
                return this.nodeOptions_.get(i);
            }

            private void ensureNodeOptionsIsMutable() {
                Internal.ProtobufList<Any> protobufList = this.nodeOptions_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.nodeOptions_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNodeOptions(int i, Any any) {
                any.getClass();
                ensureNodeOptionsIsMutable();
                this.nodeOptions_.set(i, any);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addNodeOptions(Any any) {
                any.getClass();
                ensureNodeOptionsIsMutable();
                this.nodeOptions_.add(any);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addNodeOptions(int i, Any any) {
                any.getClass();
                ensureNodeOptionsIsMutable();
                this.nodeOptions_.add(i, any);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllNodeOptions(Iterable<? extends Any> iterable) {
                ensureNodeOptionsIsMutable();
                AbstractMessageLite.addAll(iterable, this.nodeOptions_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNodeOptions() {
                this.nodeOptions_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void removeNodeOptions(int i) {
                ensureNodeOptionsIsMutable();
                this.nodeOptions_.remove(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getSourceLayer() {
                return this.sourceLayer_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setSourceLayer(int i) {
                this.sourceLayer_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearSourceLayer() {
                this.sourceLayer_ = 0;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getBufferSizeHint() {
                return this.bufferSizeHint_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setBufferSizeHint(int i) {
                this.bufferSizeHint_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearBufferSizeHint() {
                this.bufferSizeHint_ = 0;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public boolean hasInputStreamHandler() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public StreamHandlerProto.InputStreamHandlerConfig getInputStreamHandler() {
                StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig = this.inputStreamHandler_;
                return inputStreamHandlerConfig == null ? StreamHandlerProto.InputStreamHandlerConfig.getDefaultInstance() : inputStreamHandlerConfig;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
                inputStreamHandlerConfig.getClass();
                this.inputStreamHandler_ = inputStreamHandlerConfig;
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
                inputStreamHandlerConfig.getClass();
                StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig2 = this.inputStreamHandler_;
                if (inputStreamHandlerConfig2 != null && inputStreamHandlerConfig2 != StreamHandlerProto.InputStreamHandlerConfig.getDefaultInstance()) {
                    this.inputStreamHandler_ = StreamHandlerProto.InputStreamHandlerConfig.newBuilder(this.inputStreamHandler_).mergeFrom(inputStreamHandlerConfig).buildPartial();
                } else {
                    this.inputStreamHandler_ = inputStreamHandlerConfig;
                }
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearInputStreamHandler() {
                this.inputStreamHandler_ = null;
                this.bitField0_ &= -3;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public boolean hasOutputStreamHandler() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public StreamHandlerProto.OutputStreamHandlerConfig getOutputStreamHandler() {
                StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig = this.outputStreamHandler_;
                return outputStreamHandlerConfig == null ? StreamHandlerProto.OutputStreamHandlerConfig.getDefaultInstance() : outputStreamHandlerConfig;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
                outputStreamHandlerConfig.getClass();
                this.outputStreamHandler_ = outputStreamHandlerConfig;
                this.bitField0_ |= 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
                outputStreamHandlerConfig.getClass();
                StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig2 = this.outputStreamHandler_;
                if (outputStreamHandlerConfig2 != null && outputStreamHandlerConfig2 != StreamHandlerProto.OutputStreamHandlerConfig.getDefaultInstance()) {
                    this.outputStreamHandler_ = StreamHandlerProto.OutputStreamHandlerConfig.newBuilder(this.outputStreamHandler_).mergeFrom(outputStreamHandlerConfig).buildPartial();
                } else {
                    this.outputStreamHandler_ = outputStreamHandlerConfig;
                }
                this.bitField0_ |= 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutputStreamHandler() {
                this.outputStreamHandler_ = null;
                this.bitField0_ &= -5;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<InputStreamInfo> getInputStreamInfoList() {
                return this.inputStreamInfo_;
            }

            public List<? extends InputStreamInfoOrBuilder> getInputStreamInfoOrBuilderList() {
                return this.inputStreamInfo_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getInputStreamInfoCount() {
                return this.inputStreamInfo_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public InputStreamInfo getInputStreamInfo(int i) {
                return this.inputStreamInfo_.get(i);
            }

            public InputStreamInfoOrBuilder getInputStreamInfoOrBuilder(int i) {
                return this.inputStreamInfo_.get(i);
            }

            private void ensureInputStreamInfoIsMutable() {
                Internal.ProtobufList<InputStreamInfo> protobufList = this.inputStreamInfo_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.inputStreamInfo_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setInputStreamInfo(int i, InputStreamInfo inputStreamInfo) {
                inputStreamInfo.getClass();
                ensureInputStreamInfoIsMutable();
                this.inputStreamInfo_.set(i, inputStreamInfo);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addInputStreamInfo(InputStreamInfo inputStreamInfo) {
                inputStreamInfo.getClass();
                ensureInputStreamInfoIsMutable();
                this.inputStreamInfo_.add(inputStreamInfo);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addInputStreamInfo(int i, InputStreamInfo inputStreamInfo) {
                inputStreamInfo.getClass();
                ensureInputStreamInfoIsMutable();
                this.inputStreamInfo_.add(i, inputStreamInfo);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllInputStreamInfo(Iterable<? extends InputStreamInfo> iterable) {
                ensureInputStreamInfoIsMutable();
                AbstractMessageLite.addAll(iterable, this.inputStreamInfo_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearInputStreamInfo() {
                this.inputStreamInfo_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void removeInputStreamInfo(int i) {
                ensureInputStreamInfoIsMutable();
                this.inputStreamInfo_.remove(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getExecutor() {
                return this.executor_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getExecutorBytes() {
                return ByteString.copyFromUtf8(this.executor_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setExecutor(String str) {
                str.getClass();
                this.executor_ = str;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearExecutor() {
                this.executor_ = getDefaultInstance().getExecutor();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setExecutorBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                this.executor_ = byteString.toStringUtf8();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            @Deprecated
            public boolean hasProfilerConfig() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            @Deprecated
            public ProfilerConfig getProfilerConfig() {
                ProfilerConfig profilerConfig = this.profilerConfig_;
                return profilerConfig == null ? ProfilerConfig.getDefaultInstance() : profilerConfig;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setProfilerConfig(ProfilerConfig profilerConfig) {
                profilerConfig.getClass();
                this.profilerConfig_ = profilerConfig;
                this.bitField0_ |= 8;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeProfilerConfig(ProfilerConfig profilerConfig) {
                profilerConfig.getClass();
                ProfilerConfig profilerConfig2 = this.profilerConfig_;
                if (profilerConfig2 != null && profilerConfig2 != ProfilerConfig.getDefaultInstance()) {
                    this.profilerConfig_ = ProfilerConfig.newBuilder(this.profilerConfig_).mergeFrom(profilerConfig).buildPartial();
                } else {
                    this.profilerConfig_ = profilerConfig;
                }
                this.bitField0_ |= 8;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearProfilerConfig() {
                this.profilerConfig_ = null;
                this.bitField0_ &= -9;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getMaxInFlight() {
                return this.maxInFlight_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setMaxInFlight(int i) {
                this.maxInFlight_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearMaxInFlight() {
                this.maxInFlight_ = 0;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<String> getOptionValueList() {
                return this.optionValue_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getOptionValueCount() {
                return this.optionValue_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getOptionValue(int i) {
                return this.optionValue_.get(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getOptionValueBytes(int i) {
                return ByteString.copyFromUtf8(this.optionValue_.get(i));
            }

            private void ensureOptionValueIsMutable() {
                Internal.ProtobufList<String> protobufList = this.optionValue_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.optionValue_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOptionValue(int i, String str) {
                str.getClass();
                ensureOptionValueIsMutable();
                this.optionValue_.set(i, str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addOptionValue(String str) {
                str.getClass();
                ensureOptionValueIsMutable();
                this.optionValue_.add(str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllOptionValue(Iterable<String> iterable) {
                ensureOptionValueIsMutable();
                AbstractMessageLite.addAll(iterable, this.optionValue_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOptionValue() {
                this.optionValue_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addOptionValueBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                ensureOptionValueIsMutable();
                this.optionValue_.add(byteString.toStringUtf8());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public List<String> getExternalInputList() {
                return this.externalInput_;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public int getExternalInputCount() {
                return this.externalInput_.size();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public String getExternalInput(int i) {
                return this.externalInput_.get(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
            public ByteString getExternalInputBytes(int i) {
                return ByteString.copyFromUtf8(this.externalInput_.get(i));
            }

            private void ensureExternalInputIsMutable() {
                Internal.ProtobufList<String> protobufList = this.externalInput_;
                if (protobufList.isModifiable()) {
                    return;
                }
                this.externalInput_ = GeneratedMessageLite.mutableCopy(protobufList);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setExternalInput(int i, String str) {
                str.getClass();
                ensureExternalInputIsMutable();
                this.externalInput_.set(i, str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addExternalInput(String str) {
                str.getClass();
                ensureExternalInputIsMutable();
                this.externalInput_.add(str);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addAllExternalInput(Iterable<String> iterable) {
                ensureExternalInputIsMutable();
                AbstractMessageLite.addAll(iterable, this.externalInput_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearExternalInput() {
                this.externalInput_ = GeneratedMessageLite.emptyProtobufList();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void addExternalInputBytes(ByteString byteString) {
                AbstractMessageLite.checkByteStringIsUtf8(byteString);
                ensureExternalInputIsMutable();
                this.externalInput_.add(byteString.toStringUtf8());
            }

            public static Node parseFrom(ByteBuffer byteBuffer) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Node parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Node parseFrom(ByteString byteString) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Node parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Node parseFrom(byte[] bArr) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Node parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Node parseFrom(InputStream inputStream) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Node parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Node parseDelimitedFrom(InputStream inputStream) {
                return (Node) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Node parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Node) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Node parseFrom(CodedInputStream codedInputStream) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Node parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Node) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Node node) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(node);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Node, Builder> implements NodeOrBuilder {
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
                    super(Node.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getName() {
                    return ((Node) this.instance).getName();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getNameBytes() {
                    return ((Node) this.instance).getNameBytes();
                }

                public Builder setName(String str) {
                    copyOnWrite();
                    ((Node) this.instance).setName(str);
                    return this;
                }

                public Builder clearName() {
                    copyOnWrite();
                    ((Node) this.instance).clearName();
                    return this;
                }

                public Builder setNameBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).setNameBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getCalculator() {
                    return ((Node) this.instance).getCalculator();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getCalculatorBytes() {
                    return ((Node) this.instance).getCalculatorBytes();
                }

                public Builder setCalculator(String str) {
                    copyOnWrite();
                    ((Node) this.instance).setCalculator(str);
                    return this;
                }

                public Builder clearCalculator() {
                    copyOnWrite();
                    ((Node) this.instance).clearCalculator();
                    return this;
                }

                public Builder setCalculatorBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).setCalculatorBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<String> getInputStreamList() {
                    return Collections.unmodifiableList(((Node) this.instance).getInputStreamList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getInputStreamCount() {
                    return ((Node) this.instance).getInputStreamCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getInputStream(int i) {
                    return ((Node) this.instance).getInputStream(i);
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getInputStreamBytes(int i) {
                    return ((Node) this.instance).getInputStreamBytes(i);
                }

                public Builder setInputStream(int i, String str) {
                    copyOnWrite();
                    ((Node) this.instance).setInputStream(i, str);
                    return this;
                }

                public Builder addInputStream(String str) {
                    copyOnWrite();
                    ((Node) this.instance).addInputStream(str);
                    return this;
                }

                public Builder addAllInputStream(Iterable<String> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllInputStream(iterable);
                    return this;
                }

                public Builder clearInputStream() {
                    copyOnWrite();
                    ((Node) this.instance).clearInputStream();
                    return this;
                }

                public Builder addInputStreamBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).addInputStreamBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<String> getOutputStreamList() {
                    return Collections.unmodifiableList(((Node) this.instance).getOutputStreamList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getOutputStreamCount() {
                    return ((Node) this.instance).getOutputStreamCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getOutputStream(int i) {
                    return ((Node) this.instance).getOutputStream(i);
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getOutputStreamBytes(int i) {
                    return ((Node) this.instance).getOutputStreamBytes(i);
                }

                public Builder setOutputStream(int i, String str) {
                    copyOnWrite();
                    ((Node) this.instance).setOutputStream(i, str);
                    return this;
                }

                public Builder addOutputStream(String str) {
                    copyOnWrite();
                    ((Node) this.instance).addOutputStream(str);
                    return this;
                }

                public Builder addAllOutputStream(Iterable<String> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllOutputStream(iterable);
                    return this;
                }

                public Builder clearOutputStream() {
                    copyOnWrite();
                    ((Node) this.instance).clearOutputStream();
                    return this;
                }

                public Builder addOutputStreamBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).addOutputStreamBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<String> getInputSidePacketList() {
                    return Collections.unmodifiableList(((Node) this.instance).getInputSidePacketList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getInputSidePacketCount() {
                    return ((Node) this.instance).getInputSidePacketCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getInputSidePacket(int i) {
                    return ((Node) this.instance).getInputSidePacket(i);
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getInputSidePacketBytes(int i) {
                    return ((Node) this.instance).getInputSidePacketBytes(i);
                }

                public Builder setInputSidePacket(int i, String str) {
                    copyOnWrite();
                    ((Node) this.instance).setInputSidePacket(i, str);
                    return this;
                }

                public Builder addInputSidePacket(String str) {
                    copyOnWrite();
                    ((Node) this.instance).addInputSidePacket(str);
                    return this;
                }

                public Builder addAllInputSidePacket(Iterable<String> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllInputSidePacket(iterable);
                    return this;
                }

                public Builder clearInputSidePacket() {
                    copyOnWrite();
                    ((Node) this.instance).clearInputSidePacket();
                    return this;
                }

                public Builder addInputSidePacketBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).addInputSidePacketBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<String> getOutputSidePacketList() {
                    return Collections.unmodifiableList(((Node) this.instance).getOutputSidePacketList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getOutputSidePacketCount() {
                    return ((Node) this.instance).getOutputSidePacketCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getOutputSidePacket(int i) {
                    return ((Node) this.instance).getOutputSidePacket(i);
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getOutputSidePacketBytes(int i) {
                    return ((Node) this.instance).getOutputSidePacketBytes(i);
                }

                public Builder setOutputSidePacket(int i, String str) {
                    copyOnWrite();
                    ((Node) this.instance).setOutputSidePacket(i, str);
                    return this;
                }

                public Builder addOutputSidePacket(String str) {
                    copyOnWrite();
                    ((Node) this.instance).addOutputSidePacket(str);
                    return this;
                }

                public Builder addAllOutputSidePacket(Iterable<String> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllOutputSidePacket(iterable);
                    return this;
                }

                public Builder clearOutputSidePacket() {
                    copyOnWrite();
                    ((Node) this.instance).clearOutputSidePacket();
                    return this;
                }

                public Builder addOutputSidePacketBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).addOutputSidePacketBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public boolean hasOptions() {
                    return ((Node) this.instance).hasOptions();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public CalculatorOptionsProto.CalculatorOptions getOptions() {
                    return ((Node) this.instance).getOptions();
                }

                public Builder setOptions(CalculatorOptionsProto.CalculatorOptions calculatorOptions) {
                    copyOnWrite();
                    ((Node) this.instance).setOptions(calculatorOptions);
                    return this;
                }

                /* JADX WARN: Multi-variable type inference failed */
                public Builder setOptions(CalculatorOptionsProto.CalculatorOptions.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).setOptions((CalculatorOptionsProto.CalculatorOptions) builder.build());
                    return this;
                }

                public Builder mergeOptions(CalculatorOptionsProto.CalculatorOptions calculatorOptions) {
                    copyOnWrite();
                    ((Node) this.instance).mergeOptions(calculatorOptions);
                    return this;
                }

                public Builder clearOptions() {
                    copyOnWrite();
                    ((Node) this.instance).clearOptions();
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<Any> getNodeOptionsList() {
                    return Collections.unmodifiableList(((Node) this.instance).getNodeOptionsList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getNodeOptionsCount() {
                    return ((Node) this.instance).getNodeOptionsCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public Any getNodeOptions(int i) {
                    return ((Node) this.instance).getNodeOptions(i);
                }

                public Builder setNodeOptions(int i, Any any) {
                    copyOnWrite();
                    ((Node) this.instance).setNodeOptions(i, any);
                    return this;
                }

                public Builder setNodeOptions(int i, Any.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).setNodeOptions(i, builder.build());
                    return this;
                }

                public Builder addNodeOptions(Any any) {
                    copyOnWrite();
                    ((Node) this.instance).addNodeOptions(any);
                    return this;
                }

                public Builder addNodeOptions(int i, Any any) {
                    copyOnWrite();
                    ((Node) this.instance).addNodeOptions(i, any);
                    return this;
                }

                public Builder addNodeOptions(Any.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).addNodeOptions(builder.build());
                    return this;
                }

                public Builder addNodeOptions(int i, Any.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).addNodeOptions(i, builder.build());
                    return this;
                }

                public Builder addAllNodeOptions(Iterable<? extends Any> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllNodeOptions(iterable);
                    return this;
                }

                public Builder clearNodeOptions() {
                    copyOnWrite();
                    ((Node) this.instance).clearNodeOptions();
                    return this;
                }

                public Builder removeNodeOptions(int i) {
                    copyOnWrite();
                    ((Node) this.instance).removeNodeOptions(i);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getSourceLayer() {
                    return ((Node) this.instance).getSourceLayer();
                }

                public Builder setSourceLayer(int i) {
                    copyOnWrite();
                    ((Node) this.instance).setSourceLayer(i);
                    return this;
                }

                public Builder clearSourceLayer() {
                    copyOnWrite();
                    ((Node) this.instance).clearSourceLayer();
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getBufferSizeHint() {
                    return ((Node) this.instance).getBufferSizeHint();
                }

                public Builder setBufferSizeHint(int i) {
                    copyOnWrite();
                    ((Node) this.instance).setBufferSizeHint(i);
                    return this;
                }

                public Builder clearBufferSizeHint() {
                    copyOnWrite();
                    ((Node) this.instance).clearBufferSizeHint();
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public boolean hasInputStreamHandler() {
                    return ((Node) this.instance).hasInputStreamHandler();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public StreamHandlerProto.InputStreamHandlerConfig getInputStreamHandler() {
                    return ((Node) this.instance).getInputStreamHandler();
                }

                public Builder setInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
                    copyOnWrite();
                    ((Node) this.instance).setInputStreamHandler(inputStreamHandlerConfig);
                    return this;
                }

                public Builder setInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).setInputStreamHandler(builder.build());
                    return this;
                }

                public Builder mergeInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
                    copyOnWrite();
                    ((Node) this.instance).mergeInputStreamHandler(inputStreamHandlerConfig);
                    return this;
                }

                public Builder clearInputStreamHandler() {
                    copyOnWrite();
                    ((Node) this.instance).clearInputStreamHandler();
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public boolean hasOutputStreamHandler() {
                    return ((Node) this.instance).hasOutputStreamHandler();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public StreamHandlerProto.OutputStreamHandlerConfig getOutputStreamHandler() {
                    return ((Node) this.instance).getOutputStreamHandler();
                }

                public Builder setOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
                    copyOnWrite();
                    ((Node) this.instance).setOutputStreamHandler(outputStreamHandlerConfig);
                    return this;
                }

                public Builder setOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).setOutputStreamHandler(builder.build());
                    return this;
                }

                public Builder mergeOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
                    copyOnWrite();
                    ((Node) this.instance).mergeOutputStreamHandler(outputStreamHandlerConfig);
                    return this;
                }

                public Builder clearOutputStreamHandler() {
                    copyOnWrite();
                    ((Node) this.instance).clearOutputStreamHandler();
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<InputStreamInfo> getInputStreamInfoList() {
                    return Collections.unmodifiableList(((Node) this.instance).getInputStreamInfoList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getInputStreamInfoCount() {
                    return ((Node) this.instance).getInputStreamInfoCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public InputStreamInfo getInputStreamInfo(int i) {
                    return ((Node) this.instance).getInputStreamInfo(i);
                }

                public Builder setInputStreamInfo(int i, InputStreamInfo inputStreamInfo) {
                    copyOnWrite();
                    ((Node) this.instance).setInputStreamInfo(i, inputStreamInfo);
                    return this;
                }

                public Builder setInputStreamInfo(int i, InputStreamInfo.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).setInputStreamInfo(i, builder.build());
                    return this;
                }

                public Builder addInputStreamInfo(InputStreamInfo inputStreamInfo) {
                    copyOnWrite();
                    ((Node) this.instance).addInputStreamInfo(inputStreamInfo);
                    return this;
                }

                public Builder addInputStreamInfo(int i, InputStreamInfo inputStreamInfo) {
                    copyOnWrite();
                    ((Node) this.instance).addInputStreamInfo(i, inputStreamInfo);
                    return this;
                }

                public Builder addInputStreamInfo(InputStreamInfo.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).addInputStreamInfo(builder.build());
                    return this;
                }

                public Builder addInputStreamInfo(int i, InputStreamInfo.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).addInputStreamInfo(i, builder.build());
                    return this;
                }

                public Builder addAllInputStreamInfo(Iterable<? extends InputStreamInfo> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllInputStreamInfo(iterable);
                    return this;
                }

                public Builder clearInputStreamInfo() {
                    copyOnWrite();
                    ((Node) this.instance).clearInputStreamInfo();
                    return this;
                }

                public Builder removeInputStreamInfo(int i) {
                    copyOnWrite();
                    ((Node) this.instance).removeInputStreamInfo(i);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getExecutor() {
                    return ((Node) this.instance).getExecutor();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getExecutorBytes() {
                    return ((Node) this.instance).getExecutorBytes();
                }

                public Builder setExecutor(String str) {
                    copyOnWrite();
                    ((Node) this.instance).setExecutor(str);
                    return this;
                }

                public Builder clearExecutor() {
                    copyOnWrite();
                    ((Node) this.instance).clearExecutor();
                    return this;
                }

                public Builder setExecutorBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).setExecutorBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                @Deprecated
                public boolean hasProfilerConfig() {
                    return ((Node) this.instance).hasProfilerConfig();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                @Deprecated
                public ProfilerConfig getProfilerConfig() {
                    return ((Node) this.instance).getProfilerConfig();
                }

                @Deprecated
                public Builder setProfilerConfig(ProfilerConfig profilerConfig) {
                    copyOnWrite();
                    ((Node) this.instance).setProfilerConfig(profilerConfig);
                    return this;
                }

                @Deprecated
                public Builder setProfilerConfig(ProfilerConfig.Builder builder) {
                    copyOnWrite();
                    ((Node) this.instance).setProfilerConfig(builder.build());
                    return this;
                }

                @Deprecated
                public Builder mergeProfilerConfig(ProfilerConfig profilerConfig) {
                    copyOnWrite();
                    ((Node) this.instance).mergeProfilerConfig(profilerConfig);
                    return this;
                }

                @Deprecated
                public Builder clearProfilerConfig() {
                    copyOnWrite();
                    ((Node) this.instance).clearProfilerConfig();
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getMaxInFlight() {
                    return ((Node) this.instance).getMaxInFlight();
                }

                public Builder setMaxInFlight(int i) {
                    copyOnWrite();
                    ((Node) this.instance).setMaxInFlight(i);
                    return this;
                }

                public Builder clearMaxInFlight() {
                    copyOnWrite();
                    ((Node) this.instance).clearMaxInFlight();
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<String> getOptionValueList() {
                    return Collections.unmodifiableList(((Node) this.instance).getOptionValueList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getOptionValueCount() {
                    return ((Node) this.instance).getOptionValueCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getOptionValue(int i) {
                    return ((Node) this.instance).getOptionValue(i);
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getOptionValueBytes(int i) {
                    return ((Node) this.instance).getOptionValueBytes(i);
                }

                public Builder setOptionValue(int i, String str) {
                    copyOnWrite();
                    ((Node) this.instance).setOptionValue(i, str);
                    return this;
                }

                public Builder addOptionValue(String str) {
                    copyOnWrite();
                    ((Node) this.instance).addOptionValue(str);
                    return this;
                }

                public Builder addAllOptionValue(Iterable<String> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllOptionValue(iterable);
                    return this;
                }

                public Builder clearOptionValue() {
                    copyOnWrite();
                    ((Node) this.instance).clearOptionValue();
                    return this;
                }

                public Builder addOptionValueBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).addOptionValueBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public List<String> getExternalInputList() {
                    return Collections.unmodifiableList(((Node) this.instance).getExternalInputList());
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public int getExternalInputCount() {
                    return ((Node) this.instance).getExternalInputCount();
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public String getExternalInput(int i) {
                    return ((Node) this.instance).getExternalInput(i);
                }

                @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfig.NodeOrBuilder
                public ByteString getExternalInputBytes(int i) {
                    return ((Node) this.instance).getExternalInputBytes(i);
                }

                public Builder setExternalInput(int i, String str) {
                    copyOnWrite();
                    ((Node) this.instance).setExternalInput(i, str);
                    return this;
                }

                public Builder addExternalInput(String str) {
                    copyOnWrite();
                    ((Node) this.instance).addExternalInput(str);
                    return this;
                }

                public Builder addAllExternalInput(Iterable<String> iterable) {
                    copyOnWrite();
                    ((Node) this.instance).addAllExternalInput(iterable);
                    return this;
                }

                public Builder clearExternalInput() {
                    copyOnWrite();
                    ((Node) this.instance).clearExternalInput();
                    return this;
                }

                public Builder addExternalInputBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Node) this.instance).addExternalInputBytes(byteString);
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Node();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0012\u0000\u0001\u0001ϭ\u0012\u0000\b\u0003\u0001Ȉ\u0002Ȉ\u0003Ț\u0004Ț\u0005Ț\u0006Ț\u0007ᐉ\u0000\b\u001b\t\u0004\n\u0004\u000bᐉ\u0001\fᐉ\u0002\r\u001b\u000eȈ\u000fဉ\u0003\u0010\u0004\u0011ȚϭȚ", new Object[]{"bitField0_", "name_", "calculator_", "inputStream_", "outputStream_", "inputSidePacket_", "outputSidePacket_", "options_", "nodeOptions_", Any.class, "sourceLayer_", "bufferSizeHint_", "inputStreamHandler_", "outputStreamHandler_", "inputStreamInfo_", InputStreamInfo.class, "executor_", "profilerConfig_", "maxInFlight_", "optionValue_", "externalInput_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Node> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Node.class) {
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
                        return Byte.valueOf(this.memoizedIsInitialized);
                    case 7:
                        this.memoizedIsInitialized = (byte) (obj == null ? 0 : 1);
                        return null;
                    default:
                        throw new UnsupportedOperationException();
                }
            }

            static {
                Node node = new Node();
                DEFAULT_INSTANCE = node;
                GeneratedMessageLite.registerDefaultInstance(Node.class, node);
            }

            public static Node getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Node> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<Node> getNodeList() {
            return this.node_;
        }

        public List<? extends NodeOrBuilder> getNodeOrBuilderList() {
            return this.node_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getNodeCount() {
            return this.node_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public Node getNode(int i) {
            return this.node_.get(i);
        }

        public NodeOrBuilder getNodeOrBuilder(int i) {
            return this.node_.get(i);
        }

        private void ensureNodeIsMutable() {
            Internal.ProtobufList<Node> protobufList = this.node_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.node_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setNode(int i, Node node) {
            node.getClass();
            ensureNodeIsMutable();
            this.node_.set(i, node);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addNode(Node node) {
            node.getClass();
            ensureNodeIsMutable();
            this.node_.add(node);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addNode(int i, Node node) {
            node.getClass();
            ensureNodeIsMutable();
            this.node_.add(i, node);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllNode(Iterable<? extends Node> iterable) {
            ensureNodeIsMutable();
            AbstractMessageLite.addAll(iterable, this.node_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearNode() {
            this.node_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeNode(int i) {
            ensureNodeIsMutable();
            this.node_.remove(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<PacketFactoryProto.PacketFactoryConfig> getPacketFactoryList() {
            return this.packetFactory_;
        }

        public List<? extends PacketFactoryProto.PacketFactoryConfigOrBuilder> getPacketFactoryOrBuilderList() {
            return this.packetFactory_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getPacketFactoryCount() {
            return this.packetFactory_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public PacketFactoryProto.PacketFactoryConfig getPacketFactory(int i) {
            return this.packetFactory_.get(i);
        }

        public PacketFactoryProto.PacketFactoryConfigOrBuilder getPacketFactoryOrBuilder(int i) {
            return this.packetFactory_.get(i);
        }

        private void ensurePacketFactoryIsMutable() {
            Internal.ProtobufList<PacketFactoryProto.PacketFactoryConfig> protobufList = this.packetFactory_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.packetFactory_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPacketFactory(int i, PacketFactoryProto.PacketFactoryConfig packetFactoryConfig) {
            packetFactoryConfig.getClass();
            ensurePacketFactoryIsMutable();
            this.packetFactory_.set(i, packetFactoryConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPacketFactory(PacketFactoryProto.PacketFactoryConfig packetFactoryConfig) {
            packetFactoryConfig.getClass();
            ensurePacketFactoryIsMutable();
            this.packetFactory_.add(packetFactoryConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPacketFactory(int i, PacketFactoryProto.PacketFactoryConfig packetFactoryConfig) {
            packetFactoryConfig.getClass();
            ensurePacketFactoryIsMutable();
            this.packetFactory_.add(i, packetFactoryConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllPacketFactory(Iterable<? extends PacketFactoryProto.PacketFactoryConfig> iterable) {
            ensurePacketFactoryIsMutable();
            AbstractMessageLite.addAll(iterable, this.packetFactory_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPacketFactory() {
            this.packetFactory_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removePacketFactory(int i) {
            ensurePacketFactoryIsMutable();
            this.packetFactory_.remove(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        @Deprecated
        public List<PacketGeneratorProto.PacketGeneratorConfig> getPacketGeneratorList() {
            return this.packetGenerator_;
        }

        @Deprecated
        public List<? extends PacketGeneratorProto.PacketGeneratorConfigOrBuilder> getPacketGeneratorOrBuilderList() {
            return this.packetGenerator_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        @Deprecated
        public int getPacketGeneratorCount() {
            return this.packetGenerator_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        @Deprecated
        public PacketGeneratorProto.PacketGeneratorConfig getPacketGenerator(int i) {
            return this.packetGenerator_.get(i);
        }

        @Deprecated
        public PacketGeneratorProto.PacketGeneratorConfigOrBuilder getPacketGeneratorOrBuilder(int i) {
            return this.packetGenerator_.get(i);
        }

        private void ensurePacketGeneratorIsMutable() {
            Internal.ProtobufList<PacketGeneratorProto.PacketGeneratorConfig> protobufList = this.packetGenerator_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.packetGenerator_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPacketGenerator(int i, PacketGeneratorProto.PacketGeneratorConfig packetGeneratorConfig) {
            packetGeneratorConfig.getClass();
            ensurePacketGeneratorIsMutable();
            this.packetGenerator_.set(i, packetGeneratorConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPacketGenerator(PacketGeneratorProto.PacketGeneratorConfig packetGeneratorConfig) {
            packetGeneratorConfig.getClass();
            ensurePacketGeneratorIsMutable();
            this.packetGenerator_.add(packetGeneratorConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPacketGenerator(int i, PacketGeneratorProto.PacketGeneratorConfig packetGeneratorConfig) {
            packetGeneratorConfig.getClass();
            ensurePacketGeneratorIsMutable();
            this.packetGenerator_.add(i, packetGeneratorConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllPacketGenerator(Iterable<? extends PacketGeneratorProto.PacketGeneratorConfig> iterable) {
            ensurePacketGeneratorIsMutable();
            AbstractMessageLite.addAll(iterable, this.packetGenerator_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPacketGenerator() {
            this.packetGenerator_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removePacketGenerator(int i) {
            ensurePacketGeneratorIsMutable();
            this.packetGenerator_.remove(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getNumThreads() {
            return this.numThreads_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setNumThreads(int i) {
            this.numThreads_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearNumThreads() {
            this.numThreads_ = 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<StatusHandlerProto.StatusHandlerConfig> getStatusHandlerList() {
            return this.statusHandler_;
        }

        public List<? extends StatusHandlerProto.StatusHandlerConfigOrBuilder> getStatusHandlerOrBuilderList() {
            return this.statusHandler_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getStatusHandlerCount() {
            return this.statusHandler_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public StatusHandlerProto.StatusHandlerConfig getStatusHandler(int i) {
            return this.statusHandler_.get(i);
        }

        public StatusHandlerProto.StatusHandlerConfigOrBuilder getStatusHandlerOrBuilder(int i) {
            return this.statusHandler_.get(i);
        }

        private void ensureStatusHandlerIsMutable() {
            Internal.ProtobufList<StatusHandlerProto.StatusHandlerConfig> protobufList = this.statusHandler_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.statusHandler_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setStatusHandler(int i, StatusHandlerProto.StatusHandlerConfig statusHandlerConfig) {
            statusHandlerConfig.getClass();
            ensureStatusHandlerIsMutable();
            this.statusHandler_.set(i, statusHandlerConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addStatusHandler(StatusHandlerProto.StatusHandlerConfig statusHandlerConfig) {
            statusHandlerConfig.getClass();
            ensureStatusHandlerIsMutable();
            this.statusHandler_.add(statusHandlerConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addStatusHandler(int i, StatusHandlerProto.StatusHandlerConfig statusHandlerConfig) {
            statusHandlerConfig.getClass();
            ensureStatusHandlerIsMutable();
            this.statusHandler_.add(i, statusHandlerConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllStatusHandler(Iterable<? extends StatusHandlerProto.StatusHandlerConfig> iterable) {
            ensureStatusHandlerIsMutable();
            AbstractMessageLite.addAll(iterable, this.statusHandler_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearStatusHandler() {
            this.statusHandler_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeStatusHandler(int i) {
            ensureStatusHandlerIsMutable();
            this.statusHandler_.remove(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<String> getInputStreamList() {
            return this.inputStream_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getInputStreamCount() {
            return this.inputStream_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public String getInputStream(int i) {
            return this.inputStream_.get(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ByteString getInputStreamBytes(int i) {
            return ByteString.copyFromUtf8(this.inputStream_.get(i));
        }

        private void ensureInputStreamIsMutable() {
            Internal.ProtobufList<String> protobufList = this.inputStream_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.inputStream_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInputStream(int i, String str) {
            str.getClass();
            ensureInputStreamIsMutable();
            this.inputStream_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInputStream(String str) {
            str.getClass();
            ensureInputStreamIsMutable();
            this.inputStream_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllInputStream(Iterable<String> iterable) {
            ensureInputStreamIsMutable();
            AbstractMessageLite.addAll(iterable, this.inputStream_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInputStream() {
            this.inputStream_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInputStreamBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            ensureInputStreamIsMutable();
            this.inputStream_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<String> getOutputStreamList() {
            return this.outputStream_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getOutputStreamCount() {
            return this.outputStream_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public String getOutputStream(int i) {
            return this.outputStream_.get(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ByteString getOutputStreamBytes(int i) {
            return ByteString.copyFromUtf8(this.outputStream_.get(i));
        }

        private void ensureOutputStreamIsMutable() {
            Internal.ProtobufList<String> protobufList = this.outputStream_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.outputStream_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputStream(int i, String str) {
            str.getClass();
            ensureOutputStreamIsMutable();
            this.outputStream_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addOutputStream(String str) {
            str.getClass();
            ensureOutputStreamIsMutable();
            this.outputStream_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllOutputStream(Iterable<String> iterable) {
            ensureOutputStreamIsMutable();
            AbstractMessageLite.addAll(iterable, this.outputStream_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOutputStream() {
            this.outputStream_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addOutputStreamBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            ensureOutputStreamIsMutable();
            this.outputStream_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<String> getInputSidePacketList() {
            return this.inputSidePacket_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getInputSidePacketCount() {
            return this.inputSidePacket_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public String getInputSidePacket(int i) {
            return this.inputSidePacket_.get(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ByteString getInputSidePacketBytes(int i) {
            return ByteString.copyFromUtf8(this.inputSidePacket_.get(i));
        }

        private void ensureInputSidePacketIsMutable() {
            Internal.ProtobufList<String> protobufList = this.inputSidePacket_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.inputSidePacket_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInputSidePacket(int i, String str) {
            str.getClass();
            ensureInputSidePacketIsMutable();
            this.inputSidePacket_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInputSidePacket(String str) {
            str.getClass();
            ensureInputSidePacketIsMutable();
            this.inputSidePacket_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllInputSidePacket(Iterable<String> iterable) {
            ensureInputSidePacketIsMutable();
            AbstractMessageLite.addAll(iterable, this.inputSidePacket_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInputSidePacket() {
            this.inputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInputSidePacketBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            ensureInputSidePacketIsMutable();
            this.inputSidePacket_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<String> getOutputSidePacketList() {
            return this.outputSidePacket_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getOutputSidePacketCount() {
            return this.outputSidePacket_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public String getOutputSidePacket(int i) {
            return this.outputSidePacket_.get(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ByteString getOutputSidePacketBytes(int i) {
            return ByteString.copyFromUtf8(this.outputSidePacket_.get(i));
        }

        private void ensureOutputSidePacketIsMutable() {
            Internal.ProtobufList<String> protobufList = this.outputSidePacket_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.outputSidePacket_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputSidePacket(int i, String str) {
            str.getClass();
            ensureOutputSidePacketIsMutable();
            this.outputSidePacket_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addOutputSidePacket(String str) {
            str.getClass();
            ensureOutputSidePacketIsMutable();
            this.outputSidePacket_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllOutputSidePacket(Iterable<String> iterable) {
            ensureOutputSidePacketIsMutable();
            AbstractMessageLite.addAll(iterable, this.outputSidePacket_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOutputSidePacket() {
            this.outputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addOutputSidePacketBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            ensureOutputSidePacketIsMutable();
            this.outputSidePacket_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getMaxQueueSize() {
            return this.maxQueueSize_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMaxQueueSize(int i) {
            this.maxQueueSize_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMaxQueueSize() {
            this.maxQueueSize_ = 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public boolean getReportDeadlock() {
            return this.reportDeadlock_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setReportDeadlock(boolean z) {
            this.reportDeadlock_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearReportDeadlock() {
            this.reportDeadlock_ = false;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public boolean hasRuntimeInfo() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public GraphRuntimeInfoConfig getRuntimeInfo() {
            GraphRuntimeInfoConfig graphRuntimeInfoConfig = this.runtimeInfo_;
            return graphRuntimeInfoConfig == null ? GraphRuntimeInfoConfig.getDefaultInstance() : graphRuntimeInfoConfig;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRuntimeInfo(GraphRuntimeInfoConfig graphRuntimeInfoConfig) {
            graphRuntimeInfoConfig.getClass();
            this.runtimeInfo_ = graphRuntimeInfoConfig;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeRuntimeInfo(GraphRuntimeInfoConfig graphRuntimeInfoConfig) {
            graphRuntimeInfoConfig.getClass();
            GraphRuntimeInfoConfig graphRuntimeInfoConfig2 = this.runtimeInfo_;
            if (graphRuntimeInfoConfig2 != null && graphRuntimeInfoConfig2 != GraphRuntimeInfoConfig.getDefaultInstance()) {
                this.runtimeInfo_ = GraphRuntimeInfoConfig.newBuilder(this.runtimeInfo_).mergeFrom(graphRuntimeInfoConfig).buildPartial();
            } else {
                this.runtimeInfo_ = graphRuntimeInfoConfig;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRuntimeInfo() {
            this.runtimeInfo_ = null;
            this.bitField0_ &= -2;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public boolean hasInputStreamHandler() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public StreamHandlerProto.InputStreamHandlerConfig getInputStreamHandler() {
            StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig = this.inputStreamHandler_;
            return inputStreamHandlerConfig == null ? StreamHandlerProto.InputStreamHandlerConfig.getDefaultInstance() : inputStreamHandlerConfig;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
            inputStreamHandlerConfig.getClass();
            this.inputStreamHandler_ = inputStreamHandlerConfig;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
            inputStreamHandlerConfig.getClass();
            StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig2 = this.inputStreamHandler_;
            if (inputStreamHandlerConfig2 != null && inputStreamHandlerConfig2 != StreamHandlerProto.InputStreamHandlerConfig.getDefaultInstance()) {
                this.inputStreamHandler_ = StreamHandlerProto.InputStreamHandlerConfig.newBuilder(this.inputStreamHandler_).mergeFrom(inputStreamHandlerConfig).buildPartial();
            } else {
                this.inputStreamHandler_ = inputStreamHandlerConfig;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInputStreamHandler() {
            this.inputStreamHandler_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public boolean hasOutputStreamHandler() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public StreamHandlerProto.OutputStreamHandlerConfig getOutputStreamHandler() {
            StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig = this.outputStreamHandler_;
            return outputStreamHandlerConfig == null ? StreamHandlerProto.OutputStreamHandlerConfig.getDefaultInstance() : outputStreamHandlerConfig;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
            outputStreamHandlerConfig.getClass();
            this.outputStreamHandler_ = outputStreamHandlerConfig;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
            outputStreamHandlerConfig.getClass();
            StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig2 = this.outputStreamHandler_;
            if (outputStreamHandlerConfig2 != null && outputStreamHandlerConfig2 != StreamHandlerProto.OutputStreamHandlerConfig.getDefaultInstance()) {
                this.outputStreamHandler_ = StreamHandlerProto.OutputStreamHandlerConfig.newBuilder(this.outputStreamHandler_).mergeFrom(outputStreamHandlerConfig).buildPartial();
            } else {
                this.outputStreamHandler_ = outputStreamHandlerConfig;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOutputStreamHandler() {
            this.outputStreamHandler_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<ExecutorConfig> getExecutorList() {
            return this.executor_;
        }

        public List<? extends ExecutorConfigOrBuilder> getExecutorOrBuilderList() {
            return this.executor_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getExecutorCount() {
            return this.executor_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ExecutorConfig getExecutor(int i) {
            return this.executor_.get(i);
        }

        public ExecutorConfigOrBuilder getExecutorOrBuilder(int i) {
            return this.executor_.get(i);
        }

        private void ensureExecutorIsMutable() {
            Internal.ProtobufList<ExecutorConfig> protobufList = this.executor_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.executor_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setExecutor(int i, ExecutorConfig executorConfig) {
            executorConfig.getClass();
            ensureExecutorIsMutable();
            this.executor_.set(i, executorConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addExecutor(ExecutorConfig executorConfig) {
            executorConfig.getClass();
            ensureExecutorIsMutable();
            this.executor_.add(executorConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addExecutor(int i, ExecutorConfig executorConfig) {
            executorConfig.getClass();
            ensureExecutorIsMutable();
            this.executor_.add(i, executorConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllExecutor(Iterable<? extends ExecutorConfig> iterable) {
            ensureExecutorIsMutable();
            AbstractMessageLite.addAll(iterable, this.executor_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearExecutor() {
            this.executor_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeExecutor(int i) {
            ensureExecutorIsMutable();
            this.executor_.remove(i);
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public boolean hasProfilerConfig() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ProfilerConfig getProfilerConfig() {
            ProfilerConfig profilerConfig = this.profilerConfig_;
            return profilerConfig == null ? ProfilerConfig.getDefaultInstance() : profilerConfig;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setProfilerConfig(ProfilerConfig profilerConfig) {
            profilerConfig.getClass();
            this.profilerConfig_ = profilerConfig;
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeProfilerConfig(ProfilerConfig profilerConfig) {
            profilerConfig.getClass();
            ProfilerConfig profilerConfig2 = this.profilerConfig_;
            if (profilerConfig2 != null && profilerConfig2 != ProfilerConfig.getDefaultInstance()) {
                this.profilerConfig_ = ProfilerConfig.newBuilder(this.profilerConfig_).mergeFrom(profilerConfig).buildPartial();
            } else {
                this.profilerConfig_ = profilerConfig;
            }
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearProfilerConfig() {
            this.profilerConfig_ = null;
            this.bitField0_ &= -9;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public String getPackage() {
            return this.package_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ByteString getPackageBytes() {
            return ByteString.copyFromUtf8(this.package_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPackage(String str) {
            str.getClass();
            this.package_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPackage() {
            this.package_ = getDefaultInstance().getPackage();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPackageBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.package_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public String getType() {
            return this.type_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public ByteString getTypeBytes() {
            return ByteString.copyFromUtf8(this.type_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setType(String str) {
            str.getClass();
            this.type_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearType() {
            this.type_ = getDefaultInstance().getType();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTypeBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.type_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public boolean hasOptions() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public MediaPipeOptionsProto.MediaPipeOptions getOptions() {
            MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions = this.options_;
            return mediaPipeOptions == null ? MediaPipeOptionsProto.MediaPipeOptions.getDefaultInstance() : mediaPipeOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
            mediaPipeOptions.getClass();
            this.options_ = mediaPipeOptions;
            this.bitField0_ |= 16;
        }

        /* JADX INFO: Access modifiers changed from: private */
        /* JADX WARN: Multi-variable type inference failed */
        public void mergeOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
            mediaPipeOptions.getClass();
            MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions2 = this.options_;
            if (mediaPipeOptions2 != null && mediaPipeOptions2 != MediaPipeOptionsProto.MediaPipeOptions.getDefaultInstance()) {
                this.options_ = ((MediaPipeOptionsProto.MediaPipeOptions.Builder) MediaPipeOptionsProto.MediaPipeOptions.newBuilder(this.options_).mergeFrom(mediaPipeOptions)).buildPartial();
            } else {
                this.options_ = mediaPipeOptions;
            }
            this.bitField0_ |= 16;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOptions() {
            this.options_ = null;
            this.bitField0_ &= -17;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public List<Any> getGraphOptionsList() {
            return this.graphOptions_;
        }

        public List<? extends AnyOrBuilder> getGraphOptionsOrBuilderList() {
            return this.graphOptions_;
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public int getGraphOptionsCount() {
            return this.graphOptions_.size();
        }

        @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
        public Any getGraphOptions(int i) {
            return this.graphOptions_.get(i);
        }

        public AnyOrBuilder getGraphOptionsOrBuilder(int i) {
            return this.graphOptions_.get(i);
        }

        private void ensureGraphOptionsIsMutable() {
            Internal.ProtobufList<Any> protobufList = this.graphOptions_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.graphOptions_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setGraphOptions(int i, Any any) {
            any.getClass();
            ensureGraphOptionsIsMutable();
            this.graphOptions_.set(i, any);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addGraphOptions(Any any) {
            any.getClass();
            ensureGraphOptionsIsMutable();
            this.graphOptions_.add(any);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addGraphOptions(int i, Any any) {
            any.getClass();
            ensureGraphOptionsIsMutable();
            this.graphOptions_.add(i, any);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllGraphOptions(Iterable<? extends Any> iterable) {
            ensureGraphOptionsIsMutable();
            AbstractMessageLite.addAll(iterable, this.graphOptions_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearGraphOptions() {
            this.graphOptions_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeGraphOptions(int i) {
            ensureGraphOptionsIsMutable();
            this.graphOptions_.remove(i);
        }

        public static CalculatorGraphConfig parseFrom(ByteBuffer byteBuffer) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static CalculatorGraphConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static CalculatorGraphConfig parseFrom(ByteString byteString) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static CalculatorGraphConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static CalculatorGraphConfig parseFrom(byte[] bArr) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static CalculatorGraphConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static CalculatorGraphConfig parseFrom(InputStream inputStream) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static CalculatorGraphConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static CalculatorGraphConfig parseDelimitedFrom(InputStream inputStream) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static CalculatorGraphConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static CalculatorGraphConfig parseFrom(CodedInputStream codedInputStream) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static CalculatorGraphConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (CalculatorGraphConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(CalculatorGraphConfig calculatorGraphConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(calculatorGraphConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<CalculatorGraphConfig, Builder> implements CalculatorGraphConfigOrBuilder {
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
                super(CalculatorGraphConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<Node> getNodeList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getNodeList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getNodeCount() {
                return ((CalculatorGraphConfig) this.instance).getNodeCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public Node getNode(int i) {
                return ((CalculatorGraphConfig) this.instance).getNode(i);
            }

            public Builder setNode(int i, Node node) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setNode(i, node);
                return this;
            }

            public Builder setNode(int i, Node.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setNode(i, builder.build());
                return this;
            }

            public Builder addNode(Node node) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addNode(node);
                return this;
            }

            public Builder addNode(int i, Node node) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addNode(i, node);
                return this;
            }

            public Builder addNode(Node.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addNode(builder.build());
                return this;
            }

            public Builder addNode(int i, Node.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addNode(i, builder.build());
                return this;
            }

            public Builder addAllNode(Iterable<? extends Node> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllNode(iterable);
                return this;
            }

            public Builder clearNode() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearNode();
                return this;
            }

            public Builder removeNode(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).removeNode(i);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<PacketFactoryProto.PacketFactoryConfig> getPacketFactoryList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getPacketFactoryList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getPacketFactoryCount() {
                return ((CalculatorGraphConfig) this.instance).getPacketFactoryCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public PacketFactoryProto.PacketFactoryConfig getPacketFactory(int i) {
                return ((CalculatorGraphConfig) this.instance).getPacketFactory(i);
            }

            public Builder setPacketFactory(int i, PacketFactoryProto.PacketFactoryConfig packetFactoryConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setPacketFactory(i, packetFactoryConfig);
                return this;
            }

            public Builder setPacketFactory(int i, PacketFactoryProto.PacketFactoryConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setPacketFactory(i, builder.build());
                return this;
            }

            public Builder addPacketFactory(PacketFactoryProto.PacketFactoryConfig packetFactoryConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketFactory(packetFactoryConfig);
                return this;
            }

            public Builder addPacketFactory(int i, PacketFactoryProto.PacketFactoryConfig packetFactoryConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketFactory(i, packetFactoryConfig);
                return this;
            }

            public Builder addPacketFactory(PacketFactoryProto.PacketFactoryConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketFactory(builder.build());
                return this;
            }

            public Builder addPacketFactory(int i, PacketFactoryProto.PacketFactoryConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketFactory(i, builder.build());
                return this;
            }

            public Builder addAllPacketFactory(Iterable<? extends PacketFactoryProto.PacketFactoryConfig> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllPacketFactory(iterable);
                return this;
            }

            public Builder clearPacketFactory() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearPacketFactory();
                return this;
            }

            public Builder removePacketFactory(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).removePacketFactory(i);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            @Deprecated
            public List<PacketGeneratorProto.PacketGeneratorConfig> getPacketGeneratorList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getPacketGeneratorList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            @Deprecated
            public int getPacketGeneratorCount() {
                return ((CalculatorGraphConfig) this.instance).getPacketGeneratorCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            @Deprecated
            public PacketGeneratorProto.PacketGeneratorConfig getPacketGenerator(int i) {
                return ((CalculatorGraphConfig) this.instance).getPacketGenerator(i);
            }

            @Deprecated
            public Builder setPacketGenerator(int i, PacketGeneratorProto.PacketGeneratorConfig packetGeneratorConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setPacketGenerator(i, packetGeneratorConfig);
                return this;
            }

            @Deprecated
            public Builder setPacketGenerator(int i, PacketGeneratorProto.PacketGeneratorConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setPacketGenerator(i, builder.build());
                return this;
            }

            @Deprecated
            public Builder addPacketGenerator(PacketGeneratorProto.PacketGeneratorConfig packetGeneratorConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketGenerator(packetGeneratorConfig);
                return this;
            }

            @Deprecated
            public Builder addPacketGenerator(int i, PacketGeneratorProto.PacketGeneratorConfig packetGeneratorConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketGenerator(i, packetGeneratorConfig);
                return this;
            }

            @Deprecated
            public Builder addPacketGenerator(PacketGeneratorProto.PacketGeneratorConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketGenerator(builder.build());
                return this;
            }

            @Deprecated
            public Builder addPacketGenerator(int i, PacketGeneratorProto.PacketGeneratorConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addPacketGenerator(i, builder.build());
                return this;
            }

            @Deprecated
            public Builder addAllPacketGenerator(Iterable<? extends PacketGeneratorProto.PacketGeneratorConfig> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllPacketGenerator(iterable);
                return this;
            }

            @Deprecated
            public Builder clearPacketGenerator() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearPacketGenerator();
                return this;
            }

            @Deprecated
            public Builder removePacketGenerator(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).removePacketGenerator(i);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getNumThreads() {
                return ((CalculatorGraphConfig) this.instance).getNumThreads();
            }

            public Builder setNumThreads(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setNumThreads(i);
                return this;
            }

            public Builder clearNumThreads() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearNumThreads();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<StatusHandlerProto.StatusHandlerConfig> getStatusHandlerList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getStatusHandlerList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getStatusHandlerCount() {
                return ((CalculatorGraphConfig) this.instance).getStatusHandlerCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public StatusHandlerProto.StatusHandlerConfig getStatusHandler(int i) {
                return ((CalculatorGraphConfig) this.instance).getStatusHandler(i);
            }

            public Builder setStatusHandler(int i, StatusHandlerProto.StatusHandlerConfig statusHandlerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setStatusHandler(i, statusHandlerConfig);
                return this;
            }

            public Builder setStatusHandler(int i, StatusHandlerProto.StatusHandlerConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setStatusHandler(i, builder.build());
                return this;
            }

            public Builder addStatusHandler(StatusHandlerProto.StatusHandlerConfig statusHandlerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addStatusHandler(statusHandlerConfig);
                return this;
            }

            public Builder addStatusHandler(int i, StatusHandlerProto.StatusHandlerConfig statusHandlerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addStatusHandler(i, statusHandlerConfig);
                return this;
            }

            public Builder addStatusHandler(StatusHandlerProto.StatusHandlerConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addStatusHandler(builder.build());
                return this;
            }

            public Builder addStatusHandler(int i, StatusHandlerProto.StatusHandlerConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addStatusHandler(i, builder.build());
                return this;
            }

            public Builder addAllStatusHandler(Iterable<? extends StatusHandlerProto.StatusHandlerConfig> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllStatusHandler(iterable);
                return this;
            }

            public Builder clearStatusHandler() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearStatusHandler();
                return this;
            }

            public Builder removeStatusHandler(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).removeStatusHandler(i);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<String> getInputStreamList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getInputStreamList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getInputStreamCount() {
                return ((CalculatorGraphConfig) this.instance).getInputStreamCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public String getInputStream(int i) {
                return ((CalculatorGraphConfig) this.instance).getInputStream(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ByteString getInputStreamBytes(int i) {
                return ((CalculatorGraphConfig) this.instance).getInputStreamBytes(i);
            }

            public Builder setInputStream(int i, String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setInputStream(i, str);
                return this;
            }

            public Builder addInputStream(String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addInputStream(str);
                return this;
            }

            public Builder addAllInputStream(Iterable<String> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllInputStream(iterable);
                return this;
            }

            public Builder clearInputStream() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearInputStream();
                return this;
            }

            public Builder addInputStreamBytes(ByteString byteString) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addInputStreamBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<String> getOutputStreamList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getOutputStreamList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getOutputStreamCount() {
                return ((CalculatorGraphConfig) this.instance).getOutputStreamCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public String getOutputStream(int i) {
                return ((CalculatorGraphConfig) this.instance).getOutputStream(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ByteString getOutputStreamBytes(int i) {
                return ((CalculatorGraphConfig) this.instance).getOutputStreamBytes(i);
            }

            public Builder setOutputStream(int i, String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setOutputStream(i, str);
                return this;
            }

            public Builder addOutputStream(String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addOutputStream(str);
                return this;
            }

            public Builder addAllOutputStream(Iterable<String> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllOutputStream(iterable);
                return this;
            }

            public Builder clearOutputStream() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearOutputStream();
                return this;
            }

            public Builder addOutputStreamBytes(ByteString byteString) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addOutputStreamBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<String> getInputSidePacketList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getInputSidePacketList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getInputSidePacketCount() {
                return ((CalculatorGraphConfig) this.instance).getInputSidePacketCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public String getInputSidePacket(int i) {
                return ((CalculatorGraphConfig) this.instance).getInputSidePacket(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ByteString getInputSidePacketBytes(int i) {
                return ((CalculatorGraphConfig) this.instance).getInputSidePacketBytes(i);
            }

            public Builder setInputSidePacket(int i, String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setInputSidePacket(i, str);
                return this;
            }

            public Builder addInputSidePacket(String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addInputSidePacket(str);
                return this;
            }

            public Builder addAllInputSidePacket(Iterable<String> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllInputSidePacket(iterable);
                return this;
            }

            public Builder clearInputSidePacket() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearInputSidePacket();
                return this;
            }

            public Builder addInputSidePacketBytes(ByteString byteString) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addInputSidePacketBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<String> getOutputSidePacketList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getOutputSidePacketList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getOutputSidePacketCount() {
                return ((CalculatorGraphConfig) this.instance).getOutputSidePacketCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public String getOutputSidePacket(int i) {
                return ((CalculatorGraphConfig) this.instance).getOutputSidePacket(i);
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ByteString getOutputSidePacketBytes(int i) {
                return ((CalculatorGraphConfig) this.instance).getOutputSidePacketBytes(i);
            }

            public Builder setOutputSidePacket(int i, String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setOutputSidePacket(i, str);
                return this;
            }

            public Builder addOutputSidePacket(String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addOutputSidePacket(str);
                return this;
            }

            public Builder addAllOutputSidePacket(Iterable<String> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllOutputSidePacket(iterable);
                return this;
            }

            public Builder clearOutputSidePacket() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearOutputSidePacket();
                return this;
            }

            public Builder addOutputSidePacketBytes(ByteString byteString) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addOutputSidePacketBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getMaxQueueSize() {
                return ((CalculatorGraphConfig) this.instance).getMaxQueueSize();
            }

            public Builder setMaxQueueSize(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setMaxQueueSize(i);
                return this;
            }

            public Builder clearMaxQueueSize() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearMaxQueueSize();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public boolean getReportDeadlock() {
                return ((CalculatorGraphConfig) this.instance).getReportDeadlock();
            }

            public Builder setReportDeadlock(boolean z) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setReportDeadlock(z);
                return this;
            }

            public Builder clearReportDeadlock() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearReportDeadlock();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public boolean hasRuntimeInfo() {
                return ((CalculatorGraphConfig) this.instance).hasRuntimeInfo();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public GraphRuntimeInfoConfig getRuntimeInfo() {
                return ((CalculatorGraphConfig) this.instance).getRuntimeInfo();
            }

            public Builder setRuntimeInfo(GraphRuntimeInfoConfig graphRuntimeInfoConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setRuntimeInfo(graphRuntimeInfoConfig);
                return this;
            }

            public Builder setRuntimeInfo(GraphRuntimeInfoConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setRuntimeInfo(builder.build());
                return this;
            }

            public Builder mergeRuntimeInfo(GraphRuntimeInfoConfig graphRuntimeInfoConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).mergeRuntimeInfo(graphRuntimeInfoConfig);
                return this;
            }

            public Builder clearRuntimeInfo() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearRuntimeInfo();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public boolean hasInputStreamHandler() {
                return ((CalculatorGraphConfig) this.instance).hasInputStreamHandler();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public StreamHandlerProto.InputStreamHandlerConfig getInputStreamHandler() {
                return ((CalculatorGraphConfig) this.instance).getInputStreamHandler();
            }

            public Builder setInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setInputStreamHandler(inputStreamHandlerConfig);
                return this;
            }

            public Builder setInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setInputStreamHandler(builder.build());
                return this;
            }

            public Builder mergeInputStreamHandler(StreamHandlerProto.InputStreamHandlerConfig inputStreamHandlerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).mergeInputStreamHandler(inputStreamHandlerConfig);
                return this;
            }

            public Builder clearInputStreamHandler() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearInputStreamHandler();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public boolean hasOutputStreamHandler() {
                return ((CalculatorGraphConfig) this.instance).hasOutputStreamHandler();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public StreamHandlerProto.OutputStreamHandlerConfig getOutputStreamHandler() {
                return ((CalculatorGraphConfig) this.instance).getOutputStreamHandler();
            }

            public Builder setOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setOutputStreamHandler(outputStreamHandlerConfig);
                return this;
            }

            public Builder setOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setOutputStreamHandler(builder.build());
                return this;
            }

            public Builder mergeOutputStreamHandler(StreamHandlerProto.OutputStreamHandlerConfig outputStreamHandlerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).mergeOutputStreamHandler(outputStreamHandlerConfig);
                return this;
            }

            public Builder clearOutputStreamHandler() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearOutputStreamHandler();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<ExecutorConfig> getExecutorList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getExecutorList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getExecutorCount() {
                return ((CalculatorGraphConfig) this.instance).getExecutorCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ExecutorConfig getExecutor(int i) {
                return ((CalculatorGraphConfig) this.instance).getExecutor(i);
            }

            public Builder setExecutor(int i, ExecutorConfig executorConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setExecutor(i, executorConfig);
                return this;
            }

            public Builder setExecutor(int i, ExecutorConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setExecutor(i, builder.build());
                return this;
            }

            public Builder addExecutor(ExecutorConfig executorConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addExecutor(executorConfig);
                return this;
            }

            public Builder addExecutor(int i, ExecutorConfig executorConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addExecutor(i, executorConfig);
                return this;
            }

            public Builder addExecutor(ExecutorConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addExecutor(builder.build());
                return this;
            }

            public Builder addExecutor(int i, ExecutorConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addExecutor(i, builder.build());
                return this;
            }

            public Builder addAllExecutor(Iterable<? extends ExecutorConfig> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllExecutor(iterable);
                return this;
            }

            public Builder clearExecutor() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearExecutor();
                return this;
            }

            public Builder removeExecutor(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).removeExecutor(i);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public boolean hasProfilerConfig() {
                return ((CalculatorGraphConfig) this.instance).hasProfilerConfig();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ProfilerConfig getProfilerConfig() {
                return ((CalculatorGraphConfig) this.instance).getProfilerConfig();
            }

            public Builder setProfilerConfig(ProfilerConfig profilerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setProfilerConfig(profilerConfig);
                return this;
            }

            public Builder setProfilerConfig(ProfilerConfig.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setProfilerConfig(builder.build());
                return this;
            }

            public Builder mergeProfilerConfig(ProfilerConfig profilerConfig) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).mergeProfilerConfig(profilerConfig);
                return this;
            }

            public Builder clearProfilerConfig() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearProfilerConfig();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public String getPackage() {
                return ((CalculatorGraphConfig) this.instance).getPackage();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ByteString getPackageBytes() {
                return ((CalculatorGraphConfig) this.instance).getPackageBytes();
            }

            public Builder setPackage(String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setPackage(str);
                return this;
            }

            public Builder clearPackage() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearPackage();
                return this;
            }

            public Builder setPackageBytes(ByteString byteString) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setPackageBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public String getType() {
                return ((CalculatorGraphConfig) this.instance).getType();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public ByteString getTypeBytes() {
                return ((CalculatorGraphConfig) this.instance).getTypeBytes();
            }

            public Builder setType(String str) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setType(str);
                return this;
            }

            public Builder clearType() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearType();
                return this;
            }

            public Builder setTypeBytes(ByteString byteString) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setTypeBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public boolean hasOptions() {
                return ((CalculatorGraphConfig) this.instance).hasOptions();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public MediaPipeOptionsProto.MediaPipeOptions getOptions() {
                return ((CalculatorGraphConfig) this.instance).getOptions();
            }

            public Builder setOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setOptions(mediaPipeOptions);
                return this;
            }

            /* JADX WARN: Multi-variable type inference failed */
            public Builder setOptions(MediaPipeOptionsProto.MediaPipeOptions.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setOptions((MediaPipeOptionsProto.MediaPipeOptions) builder.build());
                return this;
            }

            public Builder mergeOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).mergeOptions(mediaPipeOptions);
                return this;
            }

            public Builder clearOptions() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearOptions();
                return this;
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public List<Any> getGraphOptionsList() {
                return Collections.unmodifiableList(((CalculatorGraphConfig) this.instance).getGraphOptionsList());
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public int getGraphOptionsCount() {
                return ((CalculatorGraphConfig) this.instance).getGraphOptionsCount();
            }

            @Override // com.google.mediapipe.proto.CalculatorProto.CalculatorGraphConfigOrBuilder
            public Any getGraphOptions(int i) {
                return ((CalculatorGraphConfig) this.instance).getGraphOptions(i);
            }

            public Builder setGraphOptions(int i, Any any) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setGraphOptions(i, any);
                return this;
            }

            public Builder setGraphOptions(int i, Any.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).setGraphOptions(i, builder.build());
                return this;
            }

            public Builder addGraphOptions(Any any) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addGraphOptions(any);
                return this;
            }

            public Builder addGraphOptions(int i, Any any) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addGraphOptions(i, any);
                return this;
            }

            public Builder addGraphOptions(Any.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addGraphOptions(builder.build());
                return this;
            }

            public Builder addGraphOptions(int i, Any.Builder builder) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addGraphOptions(i, builder.build());
                return this;
            }

            public Builder addAllGraphOptions(Iterable<? extends Any> iterable) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).addAllGraphOptions(iterable);
                return this;
            }

            public Builder clearGraphOptions() {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).clearGraphOptions();
                return this;
            }

            public Builder removeGraphOptions(int i) {
                copyOnWrite();
                ((CalculatorGraphConfig) this.instance).removeGraphOptions(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new CalculatorGraphConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0014\u0000\u0001\u0001Ϫ\u0014\u0000\n\b\u0001Л\u0006Л\u0007Л\b\u0004\tЛ\nȚ\u000b\u0004\fᐉ\u0001\rᐉ\u0002\u000eЛ\u000fȚ\u0010Ț\u0011Ț\u0012ဉ\u0003\u0013Ȉ\u0014Ȉ\u0015\u0007\u0016ဉ\u0000ϩᐉ\u0004Ϫ\u001b", new Object[]{"bitField0_", "node_", Node.class, "packetFactory_", PacketFactoryProto.PacketFactoryConfig.class, "packetGenerator_", PacketGeneratorProto.PacketGeneratorConfig.class, "numThreads_", "statusHandler_", StatusHandlerProto.StatusHandlerConfig.class, "inputStream_", "maxQueueSize_", "inputStreamHandler_", "outputStreamHandler_", "executor_", ExecutorConfig.class, "outputStream_", "inputSidePacket_", "outputSidePacket_", "profilerConfig_", "package_", "type_", "reportDeadlock_", "runtimeInfo_", "options_", "graphOptions_", Any.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<CalculatorGraphConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (CalculatorGraphConfig.class) {
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
                    return Byte.valueOf(this.memoizedIsInitialized);
                case 7:
                    this.memoizedIsInitialized = (byte) (obj == null ? 0 : 1);
                    return null;
                default:
                    throw new UnsupportedOperationException();
            }
        }

        static {
            CalculatorGraphConfig calculatorGraphConfig = new CalculatorGraphConfig();
            DEFAULT_INSTANCE = calculatorGraphConfig;
            GeneratedMessageLite.registerDefaultInstance(CalculatorGraphConfig.class, calculatorGraphConfig);
        }

        public static CalculatorGraphConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<CalculatorGraphConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
