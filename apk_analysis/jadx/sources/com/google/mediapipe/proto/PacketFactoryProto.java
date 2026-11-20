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
public final class PacketFactoryProto {

    public interface PacketFactoryConfigOrBuilder extends MessageLiteOrBuilder {
        String getExternalOutput();

        ByteString getExternalOutputBytes();

        PacketFactoryOptions getOptions();

        String getOutputSidePacket();

        ByteString getOutputSidePacketBytes();

        String getPacketFactory();

        ByteString getPacketFactoryBytes();

        boolean hasExternalOutput();

        boolean hasOptions();

        boolean hasOutputSidePacket();

        boolean hasPacketFactory();
    }

    public interface PacketFactoryOptionsOrBuilder extends GeneratedMessageLite.ExtendableMessageOrBuilder<PacketFactoryOptions, PacketFactoryOptions.Builder> {
    }

    public interface PacketManagerConfigOrBuilder extends MessageLiteOrBuilder {
        PacketFactoryConfig getPacket(int i);

        int getPacketCount();

        List<PacketFactoryConfig> getPacketList();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private PacketFactoryProto() {
    }

    public static final class PacketFactoryOptions extends GeneratedMessageLite.ExtendableMessage<PacketFactoryOptions, Builder> implements PacketFactoryOptionsOrBuilder {
        private static final PacketFactoryOptions DEFAULT_INSTANCE;
        private static volatile Parser<PacketFactoryOptions> PARSER;
        private byte memoizedIsInitialized = 2;

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

        private PacketFactoryOptions() {
        }

        public static PacketFactoryOptions parseFrom(ByteBuffer byteBuffer) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static PacketFactoryOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static PacketFactoryOptions parseFrom(ByteString byteString) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static PacketFactoryOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static PacketFactoryOptions parseFrom(byte[] bArr) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static PacketFactoryOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static PacketFactoryOptions parseFrom(InputStream inputStream) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketFactoryOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketFactoryOptions parseDelimitedFrom(InputStream inputStream) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketFactoryOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketFactoryOptions parseFrom(CodedInputStream codedInputStream) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static PacketFactoryOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(PacketFactoryOptions packetFactoryOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(packetFactoryOptions);
        }

        public static final class Builder extends GeneratedMessageLite.ExtendableBuilder<PacketFactoryOptions, Builder> implements PacketFactoryOptionsOrBuilder {
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
                super(PacketFactoryOptions.DEFAULT_INSTANCE);
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new PacketFactoryOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0000", null);
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<PacketFactoryOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (PacketFactoryOptions.class) {
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
            PacketFactoryOptions packetFactoryOptions = new PacketFactoryOptions();
            DEFAULT_INSTANCE = packetFactoryOptions;
            GeneratedMessageLite.registerDefaultInstance(PacketFactoryOptions.class, packetFactoryOptions);
        }

        public static PacketFactoryOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<PacketFactoryOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.proto.PacketFactoryProto$1, reason: invalid class name */
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

    public static final class PacketFactoryConfig extends GeneratedMessageLite<PacketFactoryConfig, Builder> implements PacketFactoryConfigOrBuilder {
        private static final PacketFactoryConfig DEFAULT_INSTANCE;
        public static final int EXTERNAL_OUTPUT_FIELD_NUMBER = 1002;
        public static final int OPTIONS_FIELD_NUMBER = 3;
        public static final int OUTPUT_SIDE_PACKET_FIELD_NUMBER = 2;
        public static final int PACKET_FACTORY_FIELD_NUMBER = 1;
        private static volatile Parser<PacketFactoryConfig> PARSER;
        private int bitField0_;
        private PacketFactoryOptions options_;
        private byte memoizedIsInitialized = 2;
        private String packetFactory_ = "";
        private String outputSidePacket_ = "";
        private String externalOutput_ = "";

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

        private PacketFactoryConfig() {
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public boolean hasPacketFactory() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public String getPacketFactory() {
            return this.packetFactory_;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public ByteString getPacketFactoryBytes() {
            return ByteString.copyFromUtf8(this.packetFactory_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPacketFactory(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.packetFactory_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPacketFactory() {
            this.bitField0_ &= -2;
            this.packetFactory_ = getDefaultInstance().getPacketFactory();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPacketFactoryBytes(ByteString byteString) {
            this.packetFactory_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public boolean hasOutputSidePacket() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public String getOutputSidePacket() {
            return this.outputSidePacket_;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public ByteString getOutputSidePacketBytes() {
            return ByteString.copyFromUtf8(this.outputSidePacket_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputSidePacket(String str) {
            str.getClass();
            this.bitField0_ |= 2;
            this.outputSidePacket_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOutputSidePacket() {
            this.bitField0_ &= -3;
            this.outputSidePacket_ = getDefaultInstance().getOutputSidePacket();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputSidePacketBytes(ByteString byteString) {
            this.outputSidePacket_ = byteString.toStringUtf8();
            this.bitField0_ |= 2;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public boolean hasExternalOutput() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public String getExternalOutput() {
            return this.externalOutput_;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public ByteString getExternalOutputBytes() {
            return ByteString.copyFromUtf8(this.externalOutput_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setExternalOutput(String str) {
            str.getClass();
            this.bitField0_ |= 4;
            this.externalOutput_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearExternalOutput() {
            this.bitField0_ &= -5;
            this.externalOutput_ = getDefaultInstance().getExternalOutput();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setExternalOutputBytes(ByteString byteString) {
            this.externalOutput_ = byteString.toStringUtf8();
            this.bitField0_ |= 4;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public boolean hasOptions() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
        public PacketFactoryOptions getOptions() {
            PacketFactoryOptions packetFactoryOptions = this.options_;
            return packetFactoryOptions == null ? PacketFactoryOptions.getDefaultInstance() : packetFactoryOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOptions(PacketFactoryOptions packetFactoryOptions) {
            packetFactoryOptions.getClass();
            this.options_ = packetFactoryOptions;
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        /* JADX WARN: Multi-variable type inference failed */
        public void mergeOptions(PacketFactoryOptions packetFactoryOptions) {
            packetFactoryOptions.getClass();
            PacketFactoryOptions packetFactoryOptions2 = this.options_;
            if (packetFactoryOptions2 != null && packetFactoryOptions2 != PacketFactoryOptions.getDefaultInstance()) {
                this.options_ = ((PacketFactoryOptions.Builder) PacketFactoryOptions.newBuilder(this.options_).mergeFrom(packetFactoryOptions)).buildPartial();
            } else {
                this.options_ = packetFactoryOptions;
            }
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOptions() {
            this.options_ = null;
            this.bitField0_ &= -9;
        }

        public static PacketFactoryConfig parseFrom(ByteBuffer byteBuffer) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static PacketFactoryConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static PacketFactoryConfig parseFrom(ByteString byteString) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static PacketFactoryConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static PacketFactoryConfig parseFrom(byte[] bArr) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static PacketFactoryConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static PacketFactoryConfig parseFrom(InputStream inputStream) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketFactoryConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketFactoryConfig parseDelimitedFrom(InputStream inputStream) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketFactoryConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketFactoryConfig parseFrom(CodedInputStream codedInputStream) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static PacketFactoryConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketFactoryConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(PacketFactoryConfig packetFactoryConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(packetFactoryConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<PacketFactoryConfig, Builder> implements PacketFactoryConfigOrBuilder {
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
                super(PacketFactoryConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public boolean hasPacketFactory() {
                return ((PacketFactoryConfig) this.instance).hasPacketFactory();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public String getPacketFactory() {
                return ((PacketFactoryConfig) this.instance).getPacketFactory();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public ByteString getPacketFactoryBytes() {
                return ((PacketFactoryConfig) this.instance).getPacketFactoryBytes();
            }

            public Builder setPacketFactory(String str) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setPacketFactory(str);
                return this;
            }

            public Builder clearPacketFactory() {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).clearPacketFactory();
                return this;
            }

            public Builder setPacketFactoryBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setPacketFactoryBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public boolean hasOutputSidePacket() {
                return ((PacketFactoryConfig) this.instance).hasOutputSidePacket();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public String getOutputSidePacket() {
                return ((PacketFactoryConfig) this.instance).getOutputSidePacket();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public ByteString getOutputSidePacketBytes() {
                return ((PacketFactoryConfig) this.instance).getOutputSidePacketBytes();
            }

            public Builder setOutputSidePacket(String str) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setOutputSidePacket(str);
                return this;
            }

            public Builder clearOutputSidePacket() {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).clearOutputSidePacket();
                return this;
            }

            public Builder setOutputSidePacketBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setOutputSidePacketBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public boolean hasExternalOutput() {
                return ((PacketFactoryConfig) this.instance).hasExternalOutput();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public String getExternalOutput() {
                return ((PacketFactoryConfig) this.instance).getExternalOutput();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public ByteString getExternalOutputBytes() {
                return ((PacketFactoryConfig) this.instance).getExternalOutputBytes();
            }

            public Builder setExternalOutput(String str) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setExternalOutput(str);
                return this;
            }

            public Builder clearExternalOutput() {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).clearExternalOutput();
                return this;
            }

            public Builder setExternalOutputBytes(ByteString byteString) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setExternalOutputBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public boolean hasOptions() {
                return ((PacketFactoryConfig) this.instance).hasOptions();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketFactoryConfigOrBuilder
            public PacketFactoryOptions getOptions() {
                return ((PacketFactoryConfig) this.instance).getOptions();
            }

            public Builder setOptions(PacketFactoryOptions packetFactoryOptions) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setOptions(packetFactoryOptions);
                return this;
            }

            /* JADX WARN: Multi-variable type inference failed */
            public Builder setOptions(PacketFactoryOptions.Builder builder) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).setOptions((PacketFactoryOptions) builder.build());
                return this;
            }

            public Builder mergeOptions(PacketFactoryOptions packetFactoryOptions) {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).mergeOptions(packetFactoryOptions);
                return this;
            }

            public Builder clearOptions() {
                copyOnWrite();
                ((PacketFactoryConfig) this.instance).clearOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new PacketFactoryConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001Ϫ\u0004\u0000\u0000\u0001\u0001ဈ\u0000\u0002ဈ\u0001\u0003ᐉ\u0003Ϫဈ\u0002", new Object[]{"bitField0_", "packetFactory_", "outputSidePacket_", "options_", "externalOutput_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<PacketFactoryConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (PacketFactoryConfig.class) {
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
            PacketFactoryConfig packetFactoryConfig = new PacketFactoryConfig();
            DEFAULT_INSTANCE = packetFactoryConfig;
            GeneratedMessageLite.registerDefaultInstance(PacketFactoryConfig.class, packetFactoryConfig);
        }

        public static PacketFactoryConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<PacketFactoryConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class PacketManagerConfig extends GeneratedMessageLite<PacketManagerConfig, Builder> implements PacketManagerConfigOrBuilder {
        private static final PacketManagerConfig DEFAULT_INSTANCE;
        public static final int PACKET_FIELD_NUMBER = 1;
        private static volatile Parser<PacketManagerConfig> PARSER;
        private byte memoizedIsInitialized = 2;
        private Internal.ProtobufList<PacketFactoryConfig> packet_ = GeneratedMessageLite.emptyProtobufList();

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

        private PacketManagerConfig() {
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketManagerConfigOrBuilder
        public List<PacketFactoryConfig> getPacketList() {
            return this.packet_;
        }

        public List<? extends PacketFactoryConfigOrBuilder> getPacketOrBuilderList() {
            return this.packet_;
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketManagerConfigOrBuilder
        public int getPacketCount() {
            return this.packet_.size();
        }

        @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketManagerConfigOrBuilder
        public PacketFactoryConfig getPacket(int i) {
            return this.packet_.get(i);
        }

        public PacketFactoryConfigOrBuilder getPacketOrBuilder(int i) {
            return this.packet_.get(i);
        }

        private void ensurePacketIsMutable() {
            Internal.ProtobufList<PacketFactoryConfig> protobufList = this.packet_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.packet_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPacket(int i, PacketFactoryConfig packetFactoryConfig) {
            packetFactoryConfig.getClass();
            ensurePacketIsMutable();
            this.packet_.set(i, packetFactoryConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPacket(PacketFactoryConfig packetFactoryConfig) {
            packetFactoryConfig.getClass();
            ensurePacketIsMutable();
            this.packet_.add(packetFactoryConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPacket(int i, PacketFactoryConfig packetFactoryConfig) {
            packetFactoryConfig.getClass();
            ensurePacketIsMutable();
            this.packet_.add(i, packetFactoryConfig);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllPacket(Iterable<? extends PacketFactoryConfig> iterable) {
            ensurePacketIsMutable();
            AbstractMessageLite.addAll(iterable, this.packet_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPacket() {
            this.packet_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removePacket(int i) {
            ensurePacketIsMutable();
            this.packet_.remove(i);
        }

        public static PacketManagerConfig parseFrom(ByteBuffer byteBuffer) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static PacketManagerConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static PacketManagerConfig parseFrom(ByteString byteString) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static PacketManagerConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static PacketManagerConfig parseFrom(byte[] bArr) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static PacketManagerConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static PacketManagerConfig parseFrom(InputStream inputStream) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketManagerConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketManagerConfig parseDelimitedFrom(InputStream inputStream) {
            return (PacketManagerConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PacketManagerConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketManagerConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PacketManagerConfig parseFrom(CodedInputStream codedInputStream) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static PacketManagerConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PacketManagerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(PacketManagerConfig packetManagerConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(packetManagerConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<PacketManagerConfig, Builder> implements PacketManagerConfigOrBuilder {
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
                super(PacketManagerConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketManagerConfigOrBuilder
            public List<PacketFactoryConfig> getPacketList() {
                return Collections.unmodifiableList(((PacketManagerConfig) this.instance).getPacketList());
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketManagerConfigOrBuilder
            public int getPacketCount() {
                return ((PacketManagerConfig) this.instance).getPacketCount();
            }

            @Override // com.google.mediapipe.proto.PacketFactoryProto.PacketManagerConfigOrBuilder
            public PacketFactoryConfig getPacket(int i) {
                return ((PacketManagerConfig) this.instance).getPacket(i);
            }

            public Builder setPacket(int i, PacketFactoryConfig packetFactoryConfig) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).setPacket(i, packetFactoryConfig);
                return this;
            }

            public Builder setPacket(int i, PacketFactoryConfig.Builder builder) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).setPacket(i, builder.build());
                return this;
            }

            public Builder addPacket(PacketFactoryConfig packetFactoryConfig) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).addPacket(packetFactoryConfig);
                return this;
            }

            public Builder addPacket(int i, PacketFactoryConfig packetFactoryConfig) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).addPacket(i, packetFactoryConfig);
                return this;
            }

            public Builder addPacket(PacketFactoryConfig.Builder builder) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).addPacket(builder.build());
                return this;
            }

            public Builder addPacket(int i, PacketFactoryConfig.Builder builder) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).addPacket(i, builder.build());
                return this;
            }

            public Builder addAllPacket(Iterable<? extends PacketFactoryConfig> iterable) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).addAllPacket(iterable);
                return this;
            }

            public Builder clearPacket() {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).clearPacket();
                return this;
            }

            public Builder removePacket(int i) {
                copyOnWrite();
                ((PacketManagerConfig) this.instance).removePacket(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new PacketManagerConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0001\u0001Л", new Object[]{"packet_", PacketFactoryConfig.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<PacketManagerConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (PacketManagerConfig.class) {
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
            PacketManagerConfig packetManagerConfig = new PacketManagerConfig();
            DEFAULT_INSTANCE = packetManagerConfig;
            GeneratedMessageLite.registerDefaultInstance(PacketManagerConfig.class, packetManagerConfig);
        }

        public static PacketManagerConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<PacketManagerConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
