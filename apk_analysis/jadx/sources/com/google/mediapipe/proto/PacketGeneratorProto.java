package com.google.mediapipe.proto;

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
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class PacketGeneratorProto {

    @Deprecated
    public interface PacketGeneratorConfigOrBuilder extends MessageLiteOrBuilder {
        String getExternalInput(int i);

        ByteString getExternalInputBytes(int i);

        int getExternalInputCount();

        List<String> getExternalInputList();

        String getExternalOutput(int i);

        ByteString getExternalOutputBytes(int i);

        int getExternalOutputCount();

        List<String> getExternalOutputList();

        String getInputSidePacket(int i);

        ByteString getInputSidePacketBytes(int i);

        int getInputSidePacketCount();

        List<String> getInputSidePacketList();

        PacketGeneratorOptions getOptions();

        String getOutputSidePacket(int i);

        ByteString getOutputSidePacketBytes(int i);

        int getOutputSidePacketCount();

        List<String> getOutputSidePacketList();

        String getPacketGenerator();

        ByteString getPacketGeneratorBytes();

        boolean hasOptions();

        boolean hasPacketGenerator();
    }

    @Deprecated
    public interface PacketGeneratorOptionsOrBuilder extends GeneratedMessageLite.ExtendableMessageOrBuilder<PacketGeneratorOptions, PacketGeneratorOptions.Builder> {
        boolean getMergeFields();

        boolean hasMergeFields();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private PacketGeneratorProto() {
    }

    @Deprecated
    public static final class PacketGeneratorOptions extends GeneratedMessageLite.ExtendableMessage<PacketGeneratorOptions, Builder> implements PacketGeneratorOptionsOrBuilder {
        private static final PacketGeneratorOptions DEFAULT_INSTANCE;
        public static final int MERGE_FIELDS_FIELD_NUMBER = 1;
        private static volatile Parser<PacketGeneratorOptions> PARSER;
        private int bitField0_;
        private byte memoizedIsInitialized = 2;
        private boolean mergeFields_ = true;

        @Override // com.google.protobuf.GeneratedMessageLite.ExtendableMessage, com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
        public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
            return super.getDefaultInstanceForType();
        }

        @Override // com.google.protobuf.GeneratedMessageLite.ExtendableMessage, com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
        public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
            return super.newBuilderForType();
        }

        @Override // com.google.protobuf.GeneratedMessageLite.ExtendableMessage, com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
        public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
            return super.toBuilder();
        }

        private PacketGeneratorOptions() {
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorOptionsOrBuilder
        public boolean hasMergeFields() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorOptionsOrBuilder
        public boolean getMergeFields() {
            return this.mergeFields_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMergeFields(boolean z) {
            this.bitField0_ |= 1;
            this.mergeFields_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMergeFields() {
            this.bitField0_ &= -2;
            this.mergeFields_ = true;
        }

        public static PacketGeneratorOptions parseFrom(ByteBuffer byteBuffer) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static PacketGeneratorOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static PacketGeneratorOptions parseFrom(ByteString byteString) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static PacketGeneratorOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static PacketGeneratorOptions parseFrom(byte[] bArr) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static PacketGeneratorOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static PacketGeneratorOptions parseFrom(InputStream inputStream) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketGeneratorOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketGeneratorOptions parseDelimitedFrom(InputStream inputStream) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketGeneratorOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketGeneratorOptions parseFrom(CodedInputStream codedInputStream) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static PacketGeneratorOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(PacketGeneratorOptions packetGeneratorOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(packetGeneratorOptions);
        }

        public static final class Builder extends GeneratedMessageLite.ExtendableBuilder<PacketGeneratorOptions, Builder> implements PacketGeneratorOptionsOrBuilder {
            /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                this();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite build() {
                return super.build();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.ExtendableBuilder, com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ GeneratedMessageLite buildPartial() {
                return super.buildPartial();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.ExtendableBuilder, com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
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
                super(PacketGeneratorOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorOptionsOrBuilder
            public boolean hasMergeFields() {
                return ((PacketGeneratorOptions) this.instance).hasMergeFields();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorOptionsOrBuilder
            public boolean getMergeFields() {
                return ((PacketGeneratorOptions) this.instance).getMergeFields();
            }

            public Builder setMergeFields(boolean z) {
                copyOnWrite();
                ((PacketGeneratorOptions) this.instance).setMergeFields(z);
                return this;
            }

            public Builder clearMergeFields() {
                copyOnWrite();
                ((PacketGeneratorOptions) this.instance).clearMergeFields();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new PacketGeneratorOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0001\u0001\u0001\u0001\u0000\u0000\u0000\u0001ဇ\u0000", new Object[]{"bitField0_", "mergeFields_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<PacketGeneratorOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (PacketGeneratorOptions.class) {
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
            PacketGeneratorOptions packetGeneratorOptions = new PacketGeneratorOptions();
            DEFAULT_INSTANCE = packetGeneratorOptions;
            GeneratedMessageLite.registerDefaultInstance(PacketGeneratorOptions.class, packetGeneratorOptions);
        }

        public static PacketGeneratorOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<PacketGeneratorOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.proto.PacketGeneratorProto$1, reason: invalid class name */
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

    @Deprecated
    public static final class PacketGeneratorConfig extends GeneratedMessageLite<PacketGeneratorConfig, Builder> implements PacketGeneratorConfigOrBuilder {
        private static final PacketGeneratorConfig DEFAULT_INSTANCE;
        public static final int EXTERNAL_INPUT_FIELD_NUMBER = 1002;
        public static final int EXTERNAL_OUTPUT_FIELD_NUMBER = 1003;
        public static final int INPUT_SIDE_PACKET_FIELD_NUMBER = 2;
        public static final int OPTIONS_FIELD_NUMBER = 4;
        public static final int OUTPUT_SIDE_PACKET_FIELD_NUMBER = 3;
        public static final int PACKET_GENERATOR_FIELD_NUMBER = 1;
        private static volatile Parser<PacketGeneratorConfig> PARSER;
        private int bitField0_;
        private PacketGeneratorOptions options_;
        private byte memoizedIsInitialized = 2;
        private String packetGenerator_ = "";
        private Internal.ProtobufList<String> inputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> externalInput_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> outputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> externalOutput_ = GeneratedMessageLite.emptyProtobufList();

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

        private PacketGeneratorConfig() {
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public boolean hasPacketGenerator() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public String getPacketGenerator() {
            return this.packetGenerator_;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public ByteString getPacketGeneratorBytes() {
            return ByteString.copyFromUtf8(this.packetGenerator_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPacketGenerator(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.packetGenerator_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPacketGenerator() {
            this.bitField0_ &= -2;
            this.packetGenerator_ = getDefaultInstance().getPacketGenerator();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPacketGeneratorBytes(ByteString byteString) {
            this.packetGenerator_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public List<String> getInputSidePacketList() {
            return this.inputSidePacket_;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public int getInputSidePacketCount() {
            return this.inputSidePacket_.size();
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public String getInputSidePacket(int i) {
            return this.inputSidePacket_.get(i);
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
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
            ensureInputSidePacketIsMutable();
            this.inputSidePacket_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public List<String> getExternalInputList() {
            return this.externalInput_;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public int getExternalInputCount() {
            return this.externalInput_.size();
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public String getExternalInput(int i) {
            return this.externalInput_.get(i);
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
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
            ensureExternalInputIsMutable();
            this.externalInput_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public List<String> getOutputSidePacketList() {
            return this.outputSidePacket_;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public int getOutputSidePacketCount() {
            return this.outputSidePacket_.size();
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public String getOutputSidePacket(int i) {
            return this.outputSidePacket_.get(i);
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
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
            ensureOutputSidePacketIsMutable();
            this.outputSidePacket_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public List<String> getExternalOutputList() {
            return this.externalOutput_;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public int getExternalOutputCount() {
            return this.externalOutput_.size();
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public String getExternalOutput(int i) {
            return this.externalOutput_.get(i);
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public ByteString getExternalOutputBytes(int i) {
            return ByteString.copyFromUtf8(this.externalOutput_.get(i));
        }

        private void ensureExternalOutputIsMutable() {
            Internal.ProtobufList<String> protobufList = this.externalOutput_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.externalOutput_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setExternalOutput(int i, String str) {
            str.getClass();
            ensureExternalOutputIsMutable();
            this.externalOutput_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addExternalOutput(String str) {
            str.getClass();
            ensureExternalOutputIsMutable();
            this.externalOutput_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllExternalOutput(Iterable<String> iterable) {
            ensureExternalOutputIsMutable();
            AbstractMessageLite.addAll(iterable, this.externalOutput_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearExternalOutput() {
            this.externalOutput_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addExternalOutputBytes(ByteString byteString) {
            ensureExternalOutputIsMutable();
            this.externalOutput_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public boolean hasOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
        public PacketGeneratorOptions getOptions() {
            PacketGeneratorOptions packetGeneratorOptions = this.options_;
            return packetGeneratorOptions == null ? PacketGeneratorOptions.getDefaultInstance() : packetGeneratorOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOptions(PacketGeneratorOptions packetGeneratorOptions) {
            packetGeneratorOptions.getClass();
            this.options_ = packetGeneratorOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        /* JADX WARN: Multi-variable type inference failed */
        public void mergeOptions(PacketGeneratorOptions packetGeneratorOptions) {
            packetGeneratorOptions.getClass();
            PacketGeneratorOptions packetGeneratorOptions2 = this.options_;
            if (packetGeneratorOptions2 != null && packetGeneratorOptions2 != PacketGeneratorOptions.getDefaultInstance()) {
                this.options_ = ((PacketGeneratorOptions.Builder) PacketGeneratorOptions.newBuilder(this.options_).mergeFrom(packetGeneratorOptions)).buildPartial();
            } else {
                this.options_ = packetGeneratorOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOptions() {
            this.options_ = null;
            this.bitField0_ &= -3;
        }

        public static PacketGeneratorConfig parseFrom(ByteBuffer byteBuffer) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static PacketGeneratorConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static PacketGeneratorConfig parseFrom(ByteString byteString) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static PacketGeneratorConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static PacketGeneratorConfig parseFrom(byte[] bArr) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static PacketGeneratorConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static PacketGeneratorConfig parseFrom(InputStream inputStream) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketGeneratorConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketGeneratorConfig parseDelimitedFrom(InputStream inputStream) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketGeneratorConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketGeneratorConfig parseFrom(CodedInputStream codedInputStream) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static PacketGeneratorConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketGeneratorConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(PacketGeneratorConfig packetGeneratorConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(packetGeneratorConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<PacketGeneratorConfig, Builder> implements PacketGeneratorConfigOrBuilder {
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
                super(PacketGeneratorConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public boolean hasPacketGenerator() {
                return ((PacketGeneratorConfig) this.instance).hasPacketGenerator();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public String getPacketGenerator() {
                return ((PacketGeneratorConfig) this.instance).getPacketGenerator();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public ByteString getPacketGeneratorBytes() {
                return ((PacketGeneratorConfig) this.instance).getPacketGeneratorBytes();
            }

            public Builder setPacketGenerator(String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setPacketGenerator(str);
                return this;
            }

            public Builder clearPacketGenerator() {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).clearPacketGenerator();
                return this;
            }

            public Builder setPacketGeneratorBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setPacketGeneratorBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public List<String> getInputSidePacketList() {
                return Collections.unmodifiableList(((PacketGeneratorConfig) this.instance).getInputSidePacketList());
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public int getInputSidePacketCount() {
                return ((PacketGeneratorConfig) this.instance).getInputSidePacketCount();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public String getInputSidePacket(int i) {
                return ((PacketGeneratorConfig) this.instance).getInputSidePacket(i);
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public ByteString getInputSidePacketBytes(int i) {
                return ((PacketGeneratorConfig) this.instance).getInputSidePacketBytes(i);
            }

            public Builder setInputSidePacket(int i, String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setInputSidePacket(i, str);
                return this;
            }

            public Builder addInputSidePacket(String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addInputSidePacket(str);
                return this;
            }

            public Builder addAllInputSidePacket(Iterable<String> iterable) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addAllInputSidePacket(iterable);
                return this;
            }

            public Builder clearInputSidePacket() {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).clearInputSidePacket();
                return this;
            }

            public Builder addInputSidePacketBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addInputSidePacketBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public List<String> getExternalInputList() {
                return Collections.unmodifiableList(((PacketGeneratorConfig) this.instance).getExternalInputList());
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public int getExternalInputCount() {
                return ((PacketGeneratorConfig) this.instance).getExternalInputCount();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public String getExternalInput(int i) {
                return ((PacketGeneratorConfig) this.instance).getExternalInput(i);
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public ByteString getExternalInputBytes(int i) {
                return ((PacketGeneratorConfig) this.instance).getExternalInputBytes(i);
            }

            public Builder setExternalInput(int i, String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setExternalInput(i, str);
                return this;
            }

            public Builder addExternalInput(String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addExternalInput(str);
                return this;
            }

            public Builder addAllExternalInput(Iterable<String> iterable) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addAllExternalInput(iterable);
                return this;
            }

            public Builder clearExternalInput() {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).clearExternalInput();
                return this;
            }

            public Builder addExternalInputBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addExternalInputBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public List<String> getOutputSidePacketList() {
                return Collections.unmodifiableList(((PacketGeneratorConfig) this.instance).getOutputSidePacketList());
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public int getOutputSidePacketCount() {
                return ((PacketGeneratorConfig) this.instance).getOutputSidePacketCount();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public String getOutputSidePacket(int i) {
                return ((PacketGeneratorConfig) this.instance).getOutputSidePacket(i);
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public ByteString getOutputSidePacketBytes(int i) {
                return ((PacketGeneratorConfig) this.instance).getOutputSidePacketBytes(i);
            }

            public Builder setOutputSidePacket(int i, String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setOutputSidePacket(i, str);
                return this;
            }

            public Builder addOutputSidePacket(String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addOutputSidePacket(str);
                return this;
            }

            public Builder addAllOutputSidePacket(Iterable<String> iterable) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addAllOutputSidePacket(iterable);
                return this;
            }

            public Builder clearOutputSidePacket() {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).clearOutputSidePacket();
                return this;
            }

            public Builder addOutputSidePacketBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addOutputSidePacketBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public List<String> getExternalOutputList() {
                return Collections.unmodifiableList(((PacketGeneratorConfig) this.instance).getExternalOutputList());
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public int getExternalOutputCount() {
                return ((PacketGeneratorConfig) this.instance).getExternalOutputCount();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public String getExternalOutput(int i) {
                return ((PacketGeneratorConfig) this.instance).getExternalOutput(i);
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public ByteString getExternalOutputBytes(int i) {
                return ((PacketGeneratorConfig) this.instance).getExternalOutputBytes(i);
            }

            public Builder setExternalOutput(int i, String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setExternalOutput(i, str);
                return this;
            }

            public Builder addExternalOutput(String str) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addExternalOutput(str);
                return this;
            }

            public Builder addAllExternalOutput(Iterable<String> iterable) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addAllExternalOutput(iterable);
                return this;
            }

            public Builder clearExternalOutput() {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).clearExternalOutput();
                return this;
            }

            public Builder addExternalOutputBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).addExternalOutputBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public boolean hasOptions() {
                return ((PacketGeneratorConfig) this.instance).hasOptions();
            }

            @Override // com.google.mediapipe.proto.PacketGeneratorProto.PacketGeneratorConfigOrBuilder
            public PacketGeneratorOptions getOptions() {
                return ((PacketGeneratorConfig) this.instance).getOptions();
            }

            public Builder setOptions(PacketGeneratorOptions packetGeneratorOptions) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setOptions(packetGeneratorOptions);
                return this;
            }

            /* JADX WARN: Multi-variable type inference failed */
            public Builder setOptions(PacketGeneratorOptions.Builder builder) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).setOptions((PacketGeneratorOptions) builder.build());
                return this;
            }

            public Builder mergeOptions(PacketGeneratorOptions packetGeneratorOptions) {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).mergeOptions(packetGeneratorOptions);
                return this;
            }

            public Builder clearOptions() {
                copyOnWrite();
                ((PacketGeneratorConfig) this.instance).clearOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new PacketGeneratorConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0006\u0000\u0001\u0001ϫ\u0006\u0000\u0004\u0001\u0001ဈ\u0000\u0002\u001a\u0003\u001a\u0004ᐉ\u0001Ϫ\u001aϫ\u001a", new Object[]{"bitField0_", "packetGenerator_", "inputSidePacket_", "outputSidePacket_", "options_", "externalInput_", "externalOutput_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<PacketGeneratorConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (PacketGeneratorConfig.class) {
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
            PacketGeneratorConfig packetGeneratorConfig = new PacketGeneratorConfig();
            DEFAULT_INSTANCE = packetGeneratorConfig;
            GeneratedMessageLite.registerDefaultInstance(PacketGeneratorConfig.class, packetGeneratorConfig);
        }

        public static PacketGeneratorConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<PacketGeneratorConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
