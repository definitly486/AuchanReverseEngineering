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
public final class StatusHandlerProto {

    public interface StatusHandlerConfigOrBuilder extends MessageLiteOrBuilder {
        String getExternalInput(int i);

        ByteString getExternalInputBytes(int i);

        int getExternalInputCount();

        List<String> getExternalInputList();

        String getInputSidePacket(int i);

        ByteString getInputSidePacketBytes(int i);

        int getInputSidePacketCount();

        List<String> getInputSidePacketList();

        MediaPipeOptionsProto.MediaPipeOptions getOptions();

        String getStatusHandler();

        ByteString getStatusHandlerBytes();

        boolean hasOptions();

        boolean hasStatusHandler();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private StatusHandlerProto() {
    }

    public static final class StatusHandlerConfig extends GeneratedMessageLite<StatusHandlerConfig, Builder> implements StatusHandlerConfigOrBuilder {
        private static final StatusHandlerConfig DEFAULT_INSTANCE;
        public static final int EXTERNAL_INPUT_FIELD_NUMBER = 1002;
        public static final int INPUT_SIDE_PACKET_FIELD_NUMBER = 2;
        public static final int OPTIONS_FIELD_NUMBER = 3;
        private static volatile Parser<StatusHandlerConfig> PARSER = null;
        public static final int STATUS_HANDLER_FIELD_NUMBER = 1;
        private int bitField0_;
        private MediaPipeOptionsProto.MediaPipeOptions options_;
        private byte memoizedIsInitialized = 2;
        private String statusHandler_ = "";
        private Internal.ProtobufList<String> inputSidePacket_ = GeneratedMessageLite.emptyProtobufList();
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

        private StatusHandlerConfig() {
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public boolean hasStatusHandler() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public String getStatusHandler() {
            return this.statusHandler_;
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public ByteString getStatusHandlerBytes() {
            return ByteString.copyFromUtf8(this.statusHandler_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setStatusHandler(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.statusHandler_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearStatusHandler() {
            this.bitField0_ &= -2;
            this.statusHandler_ = getDefaultInstance().getStatusHandler();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setStatusHandlerBytes(ByteString byteString) {
            this.statusHandler_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public List<String> getInputSidePacketList() {
            return this.inputSidePacket_;
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public int getInputSidePacketCount() {
            return this.inputSidePacket_.size();
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public String getInputSidePacket(int i) {
            return this.inputSidePacket_.get(i);
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
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

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public List<String> getExternalInputList() {
            return this.externalInput_;
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public int getExternalInputCount() {
            return this.externalInput_.size();
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public String getExternalInput(int i) {
            return this.externalInput_.get(i);
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
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

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public boolean hasOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
        public MediaPipeOptionsProto.MediaPipeOptions getOptions() {
            MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions = this.options_;
            return mediaPipeOptions == null ? MediaPipeOptionsProto.MediaPipeOptions.getDefaultInstance() : mediaPipeOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
            mediaPipeOptions.getClass();
            this.options_ = mediaPipeOptions;
            this.bitField0_ |= 2;
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
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOptions() {
            this.options_ = null;
            this.bitField0_ &= -3;
        }

        public static StatusHandlerConfig parseFrom(ByteBuffer byteBuffer) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static StatusHandlerConfig parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static StatusHandlerConfig parseFrom(ByteString byteString) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static StatusHandlerConfig parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static StatusHandlerConfig parseFrom(byte[] bArr) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static StatusHandlerConfig parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static StatusHandlerConfig parseFrom(InputStream inputStream) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static StatusHandlerConfig parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static StatusHandlerConfig parseDelimitedFrom(InputStream inputStream) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static StatusHandlerConfig parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static StatusHandlerConfig parseFrom(CodedInputStream codedInputStream) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static StatusHandlerConfig parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (StatusHandlerConfig) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(StatusHandlerConfig statusHandlerConfig) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(statusHandlerConfig);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<StatusHandlerConfig, Builder> implements StatusHandlerConfigOrBuilder {
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
                super(StatusHandlerConfig.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public boolean hasStatusHandler() {
                return ((StatusHandlerConfig) this.instance).hasStatusHandler();
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public String getStatusHandler() {
                return ((StatusHandlerConfig) this.instance).getStatusHandler();
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public ByteString getStatusHandlerBytes() {
                return ((StatusHandlerConfig) this.instance).getStatusHandlerBytes();
            }

            public Builder setStatusHandler(String str) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).setStatusHandler(str);
                return this;
            }

            public Builder clearStatusHandler() {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).clearStatusHandler();
                return this;
            }

            public Builder setStatusHandlerBytes(ByteString byteString) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).setStatusHandlerBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public List<String> getInputSidePacketList() {
                return Collections.unmodifiableList(((StatusHandlerConfig) this.instance).getInputSidePacketList());
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public int getInputSidePacketCount() {
                return ((StatusHandlerConfig) this.instance).getInputSidePacketCount();
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public String getInputSidePacket(int i) {
                return ((StatusHandlerConfig) this.instance).getInputSidePacket(i);
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public ByteString getInputSidePacketBytes(int i) {
                return ((StatusHandlerConfig) this.instance).getInputSidePacketBytes(i);
            }

            public Builder setInputSidePacket(int i, String str) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).setInputSidePacket(i, str);
                return this;
            }

            public Builder addInputSidePacket(String str) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).addInputSidePacket(str);
                return this;
            }

            public Builder addAllInputSidePacket(Iterable<String> iterable) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).addAllInputSidePacket(iterable);
                return this;
            }

            public Builder clearInputSidePacket() {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).clearInputSidePacket();
                return this;
            }

            public Builder addInputSidePacketBytes(ByteString byteString) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).addInputSidePacketBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public List<String> getExternalInputList() {
                return Collections.unmodifiableList(((StatusHandlerConfig) this.instance).getExternalInputList());
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public int getExternalInputCount() {
                return ((StatusHandlerConfig) this.instance).getExternalInputCount();
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public String getExternalInput(int i) {
                return ((StatusHandlerConfig) this.instance).getExternalInput(i);
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public ByteString getExternalInputBytes(int i) {
                return ((StatusHandlerConfig) this.instance).getExternalInputBytes(i);
            }

            public Builder setExternalInput(int i, String str) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).setExternalInput(i, str);
                return this;
            }

            public Builder addExternalInput(String str) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).addExternalInput(str);
                return this;
            }

            public Builder addAllExternalInput(Iterable<String> iterable) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).addAllExternalInput(iterable);
                return this;
            }

            public Builder clearExternalInput() {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).clearExternalInput();
                return this;
            }

            public Builder addExternalInputBytes(ByteString byteString) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).addExternalInputBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public boolean hasOptions() {
                return ((StatusHandlerConfig) this.instance).hasOptions();
            }

            @Override // com.google.mediapipe.proto.StatusHandlerProto.StatusHandlerConfigOrBuilder
            public MediaPipeOptionsProto.MediaPipeOptions getOptions() {
                return ((StatusHandlerConfig) this.instance).getOptions();
            }

            public Builder setOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).setOptions(mediaPipeOptions);
                return this;
            }

            /* JADX WARN: Multi-variable type inference failed */
            public Builder setOptions(MediaPipeOptionsProto.MediaPipeOptions.Builder builder) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).setOptions((MediaPipeOptionsProto.MediaPipeOptions) builder.build());
                return this;
            }

            public Builder mergeOptions(MediaPipeOptionsProto.MediaPipeOptions mediaPipeOptions) {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).mergeOptions(mediaPipeOptions);
                return this;
            }

            public Builder clearOptions() {
                copyOnWrite();
                ((StatusHandlerConfig) this.instance).clearOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new StatusHandlerConfig();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001Ϫ\u0004\u0000\u0002\u0001\u0001ဈ\u0000\u0002\u001a\u0003ᐉ\u0001Ϫ\u001a", new Object[]{"bitField0_", "statusHandler_", "inputSidePacket_", "options_", "externalInput_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<StatusHandlerConfig> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (StatusHandlerConfig.class) {
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
            StatusHandlerConfig statusHandlerConfig = new StatusHandlerConfig();
            DEFAULT_INSTANCE = statusHandlerConfig;
            GeneratedMessageLite.registerDefaultInstance(StatusHandlerConfig.class, statusHandlerConfig);
        }

        public static StatusHandlerConfig getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<StatusHandlerConfig> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.proto.StatusHandlerProto$1, reason: invalid class name */
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
