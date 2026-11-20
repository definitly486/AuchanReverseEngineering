package com.google.mediapipe.tasks.core.proto;

import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import java.io.InputStream;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public final class ExternalFileProto {

    public interface ExternalFileOrBuilder extends MessageLiteOrBuilder {
        ByteString getFileContent();

        FileDescriptorMeta getFileDescriptorMeta();

        String getFileName();

        ByteString getFileNameBytes();

        FilePointerMeta getFilePointerMeta();

        boolean hasFileContent();

        boolean hasFileDescriptorMeta();

        boolean hasFileName();

        boolean hasFilePointerMeta();
    }

    public interface FileDescriptorMetaOrBuilder extends MessageLiteOrBuilder {
        int getFd();

        long getLength();

        long getOffset();

        boolean hasFd();

        boolean hasLength();

        boolean hasOffset();
    }

    public interface FilePointerMetaOrBuilder extends MessageLiteOrBuilder {
        long getLength();

        long getPointer();

        boolean hasLength();

        boolean hasPointer();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private ExternalFileProto() {
    }

    public static final class ExternalFile extends GeneratedMessageLite<ExternalFile, Builder> implements ExternalFileOrBuilder {
        private static final ExternalFile DEFAULT_INSTANCE;
        public static final int FILE_CONTENT_FIELD_NUMBER = 1;
        public static final int FILE_DESCRIPTOR_META_FIELD_NUMBER = 3;
        public static final int FILE_NAME_FIELD_NUMBER = 2;
        public static final int FILE_POINTER_META_FIELD_NUMBER = 4;
        private static volatile Parser<ExternalFile> PARSER;
        private int bitField0_;
        private FileDescriptorMeta fileDescriptorMeta_;
        private FilePointerMeta filePointerMeta_;
        private ByteString fileContent_ = ByteString.EMPTY;
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

        private ExternalFile() {
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public boolean hasFileContent() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public ByteString getFileContent() {
            return this.fileContent_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileContent(ByteString byteString) {
            byteString.getClass();
            this.bitField0_ |= 1;
            this.fileContent_ = byteString;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFileContent() {
            this.bitField0_ &= -2;
            this.fileContent_ = getDefaultInstance().getFileContent();
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public boolean hasFileName() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public String getFileName() {
            return this.fileName_;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public ByteString getFileNameBytes() {
            return ByteString.copyFromUtf8(this.fileName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileName(String str) {
            str.getClass();
            this.bitField0_ |= 2;
            this.fileName_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFileName() {
            this.bitField0_ &= -3;
            this.fileName_ = getDefaultInstance().getFileName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileNameBytes(ByteString byteString) {
            this.fileName_ = byteString.toStringUtf8();
            this.bitField0_ |= 2;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public boolean hasFileDescriptorMeta() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public FileDescriptorMeta getFileDescriptorMeta() {
            FileDescriptorMeta fileDescriptorMeta = this.fileDescriptorMeta_;
            return fileDescriptorMeta == null ? FileDescriptorMeta.getDefaultInstance() : fileDescriptorMeta;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileDescriptorMeta(FileDescriptorMeta fileDescriptorMeta) {
            fileDescriptorMeta.getClass();
            this.fileDescriptorMeta_ = fileDescriptorMeta;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFileDescriptorMeta(FileDescriptorMeta fileDescriptorMeta) {
            fileDescriptorMeta.getClass();
            FileDescriptorMeta fileDescriptorMeta2 = this.fileDescriptorMeta_;
            if (fileDescriptorMeta2 != null && fileDescriptorMeta2 != FileDescriptorMeta.getDefaultInstance()) {
                this.fileDescriptorMeta_ = FileDescriptorMeta.newBuilder(this.fileDescriptorMeta_).mergeFrom(fileDescriptorMeta).buildPartial();
            } else {
                this.fileDescriptorMeta_ = fileDescriptorMeta;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFileDescriptorMeta() {
            this.fileDescriptorMeta_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public boolean hasFilePointerMeta() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
        public FilePointerMeta getFilePointerMeta() {
            FilePointerMeta filePointerMeta = this.filePointerMeta_;
            return filePointerMeta == null ? FilePointerMeta.getDefaultInstance() : filePointerMeta;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFilePointerMeta(FilePointerMeta filePointerMeta) {
            filePointerMeta.getClass();
            this.filePointerMeta_ = filePointerMeta;
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFilePointerMeta(FilePointerMeta filePointerMeta) {
            filePointerMeta.getClass();
            FilePointerMeta filePointerMeta2 = this.filePointerMeta_;
            if (filePointerMeta2 != null && filePointerMeta2 != FilePointerMeta.getDefaultInstance()) {
                this.filePointerMeta_ = FilePointerMeta.newBuilder(this.filePointerMeta_).mergeFrom(filePointerMeta).buildPartial();
            } else {
                this.filePointerMeta_ = filePointerMeta;
            }
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFilePointerMeta() {
            this.filePointerMeta_ = null;
            this.bitField0_ &= -9;
        }

        public static ExternalFile parseFrom(ByteBuffer byteBuffer) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ExternalFile parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ExternalFile parseFrom(ByteString byteString) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ExternalFile parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ExternalFile parseFrom(byte[] bArr) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ExternalFile parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ExternalFile parseFrom(InputStream inputStream) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ExternalFile parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ExternalFile parseDelimitedFrom(InputStream inputStream) {
            return (ExternalFile) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ExternalFile parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ExternalFile) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ExternalFile parseFrom(CodedInputStream codedInputStream) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ExternalFile parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ExternalFile) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ExternalFile externalFile) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(externalFile);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ExternalFile, Builder> implements ExternalFileOrBuilder {
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
                super(ExternalFile.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public boolean hasFileContent() {
                return ((ExternalFile) this.instance).hasFileContent();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public ByteString getFileContent() {
                return ((ExternalFile) this.instance).getFileContent();
            }

            public Builder setFileContent(ByteString byteString) {
                copyOnWrite();
                ((ExternalFile) this.instance).setFileContent(byteString);
                return this;
            }

            public Builder clearFileContent() {
                copyOnWrite();
                ((ExternalFile) this.instance).clearFileContent();
                return this;
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public boolean hasFileName() {
                return ((ExternalFile) this.instance).hasFileName();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public String getFileName() {
                return ((ExternalFile) this.instance).getFileName();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public ByteString getFileNameBytes() {
                return ((ExternalFile) this.instance).getFileNameBytes();
            }

            public Builder setFileName(String str) {
                copyOnWrite();
                ((ExternalFile) this.instance).setFileName(str);
                return this;
            }

            public Builder clearFileName() {
                copyOnWrite();
                ((ExternalFile) this.instance).clearFileName();
                return this;
            }

            public Builder setFileNameBytes(ByteString byteString) {
                copyOnWrite();
                ((ExternalFile) this.instance).setFileNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public boolean hasFileDescriptorMeta() {
                return ((ExternalFile) this.instance).hasFileDescriptorMeta();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public FileDescriptorMeta getFileDescriptorMeta() {
                return ((ExternalFile) this.instance).getFileDescriptorMeta();
            }

            public Builder setFileDescriptorMeta(FileDescriptorMeta fileDescriptorMeta) {
                copyOnWrite();
                ((ExternalFile) this.instance).setFileDescriptorMeta(fileDescriptorMeta);
                return this;
            }

            public Builder setFileDescriptorMeta(FileDescriptorMeta.Builder builder) {
                copyOnWrite();
                ((ExternalFile) this.instance).setFileDescriptorMeta(builder.build());
                return this;
            }

            public Builder mergeFileDescriptorMeta(FileDescriptorMeta fileDescriptorMeta) {
                copyOnWrite();
                ((ExternalFile) this.instance).mergeFileDescriptorMeta(fileDescriptorMeta);
                return this;
            }

            public Builder clearFileDescriptorMeta() {
                copyOnWrite();
                ((ExternalFile) this.instance).clearFileDescriptorMeta();
                return this;
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public boolean hasFilePointerMeta() {
                return ((ExternalFile) this.instance).hasFilePointerMeta();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.ExternalFileOrBuilder
            public FilePointerMeta getFilePointerMeta() {
                return ((ExternalFile) this.instance).getFilePointerMeta();
            }

            public Builder setFilePointerMeta(FilePointerMeta filePointerMeta) {
                copyOnWrite();
                ((ExternalFile) this.instance).setFilePointerMeta(filePointerMeta);
                return this;
            }

            public Builder setFilePointerMeta(FilePointerMeta.Builder builder) {
                copyOnWrite();
                ((ExternalFile) this.instance).setFilePointerMeta(builder.build());
                return this;
            }

            public Builder mergeFilePointerMeta(FilePointerMeta filePointerMeta) {
                copyOnWrite();
                ((ExternalFile) this.instance).mergeFilePointerMeta(filePointerMeta);
                return this;
            }

            public Builder clearFilePointerMeta() {
                copyOnWrite();
                ((ExternalFile) this.instance).clearFilePointerMeta();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ExternalFile();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001ည\u0000\u0002ဈ\u0001\u0003ဉ\u0002\u0004ဉ\u0003", new Object[]{"bitField0_", "fileContent_", "fileName_", "fileDescriptorMeta_", "filePointerMeta_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ExternalFile> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ExternalFile.class) {
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
            ExternalFile externalFile = new ExternalFile();
            DEFAULT_INSTANCE = externalFile;
            GeneratedMessageLite.registerDefaultInstance(ExternalFile.class, externalFile);
        }

        public static ExternalFile getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ExternalFile> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.core.proto.ExternalFileProto$1, reason: invalid class name */
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

    public static final class FileDescriptorMeta extends GeneratedMessageLite<FileDescriptorMeta, Builder> implements FileDescriptorMetaOrBuilder {
        private static final FileDescriptorMeta DEFAULT_INSTANCE;
        public static final int FD_FIELD_NUMBER = 1;
        public static final int LENGTH_FIELD_NUMBER = 2;
        public static final int OFFSET_FIELD_NUMBER = 3;
        private static volatile Parser<FileDescriptorMeta> PARSER;
        private int bitField0_;
        private int fd_;
        private long length_;
        private long offset_;

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

        private FileDescriptorMeta() {
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
        public boolean hasFd() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
        public int getFd() {
            return this.fd_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFd(int i) {
            this.bitField0_ |= 1;
            this.fd_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFd() {
            this.bitField0_ &= -2;
            this.fd_ = 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
        public boolean hasLength() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
        public long getLength() {
            return this.length_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLength(long j) {
            this.bitField0_ |= 2;
            this.length_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLength() {
            this.bitField0_ &= -3;
            this.length_ = 0L;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
        public boolean hasOffset() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
        public long getOffset() {
            return this.offset_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOffset(long j) {
            this.bitField0_ |= 4;
            this.offset_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOffset() {
            this.bitField0_ &= -5;
            this.offset_ = 0L;
        }

        public static FileDescriptorMeta parseFrom(ByteBuffer byteBuffer) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static FileDescriptorMeta parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static FileDescriptorMeta parseFrom(ByteString byteString) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static FileDescriptorMeta parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static FileDescriptorMeta parseFrom(byte[] bArr) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static FileDescriptorMeta parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static FileDescriptorMeta parseFrom(InputStream inputStream) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FileDescriptorMeta parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FileDescriptorMeta parseDelimitedFrom(InputStream inputStream) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FileDescriptorMeta parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FileDescriptorMeta parseFrom(CodedInputStream codedInputStream) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static FileDescriptorMeta parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FileDescriptorMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(FileDescriptorMeta fileDescriptorMeta) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(fileDescriptorMeta);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<FileDescriptorMeta, Builder> implements FileDescriptorMetaOrBuilder {
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
                super(FileDescriptorMeta.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
            public boolean hasFd() {
                return ((FileDescriptorMeta) this.instance).hasFd();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
            public int getFd() {
                return ((FileDescriptorMeta) this.instance).getFd();
            }

            public Builder setFd(int i) {
                copyOnWrite();
                ((FileDescriptorMeta) this.instance).setFd(i);
                return this;
            }

            public Builder clearFd() {
                copyOnWrite();
                ((FileDescriptorMeta) this.instance).clearFd();
                return this;
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
            public boolean hasLength() {
                return ((FileDescriptorMeta) this.instance).hasLength();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
            public long getLength() {
                return ((FileDescriptorMeta) this.instance).getLength();
            }

            public Builder setLength(long j) {
                copyOnWrite();
                ((FileDescriptorMeta) this.instance).setLength(j);
                return this;
            }

            public Builder clearLength() {
                copyOnWrite();
                ((FileDescriptorMeta) this.instance).clearLength();
                return this;
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
            public boolean hasOffset() {
                return ((FileDescriptorMeta) this.instance).hasOffset();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FileDescriptorMetaOrBuilder
            public long getOffset() {
                return ((FileDescriptorMeta) this.instance).getOffset();
            }

            public Builder setOffset(long j) {
                copyOnWrite();
                ((FileDescriptorMeta) this.instance).setOffset(j);
                return this;
            }

            public Builder clearOffset() {
                copyOnWrite();
                ((FileDescriptorMeta) this.instance).clearOffset();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new FileDescriptorMeta();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001င\u0000\u0002ဂ\u0001\u0003ဂ\u0002", new Object[]{"bitField0_", "fd_", "length_", "offset_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<FileDescriptorMeta> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (FileDescriptorMeta.class) {
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
            FileDescriptorMeta fileDescriptorMeta = new FileDescriptorMeta();
            DEFAULT_INSTANCE = fileDescriptorMeta;
            GeneratedMessageLite.registerDefaultInstance(FileDescriptorMeta.class, fileDescriptorMeta);
        }

        public static FileDescriptorMeta getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<FileDescriptorMeta> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class FilePointerMeta extends GeneratedMessageLite<FilePointerMeta, Builder> implements FilePointerMetaOrBuilder {
        private static final FilePointerMeta DEFAULT_INSTANCE;
        public static final int LENGTH_FIELD_NUMBER = 2;
        private static volatile Parser<FilePointerMeta> PARSER = null;
        public static final int POINTER_FIELD_NUMBER = 1;
        private int bitField0_;
        private long length_;
        private long pointer_;

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

        private FilePointerMeta() {
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
        public boolean hasPointer() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
        public long getPointer() {
            return this.pointer_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPointer(long j) {
            this.bitField0_ |= 1;
            this.pointer_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPointer() {
            this.bitField0_ &= -2;
            this.pointer_ = 0L;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
        public boolean hasLength() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
        public long getLength() {
            return this.length_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLength(long j) {
            this.bitField0_ |= 2;
            this.length_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLength() {
            this.bitField0_ &= -3;
            this.length_ = 0L;
        }

        public static FilePointerMeta parseFrom(ByteBuffer byteBuffer) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static FilePointerMeta parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static FilePointerMeta parseFrom(ByteString byteString) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static FilePointerMeta parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static FilePointerMeta parseFrom(byte[] bArr) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static FilePointerMeta parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static FilePointerMeta parseFrom(InputStream inputStream) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FilePointerMeta parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FilePointerMeta parseDelimitedFrom(InputStream inputStream) {
            return (FilePointerMeta) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FilePointerMeta parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FilePointerMeta) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FilePointerMeta parseFrom(CodedInputStream codedInputStream) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static FilePointerMeta parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FilePointerMeta) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(FilePointerMeta filePointerMeta) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(filePointerMeta);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<FilePointerMeta, Builder> implements FilePointerMetaOrBuilder {
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
                super(FilePointerMeta.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
            public boolean hasPointer() {
                return ((FilePointerMeta) this.instance).hasPointer();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
            public long getPointer() {
                return ((FilePointerMeta) this.instance).getPointer();
            }

            public Builder setPointer(long j) {
                copyOnWrite();
                ((FilePointerMeta) this.instance).setPointer(j);
                return this;
            }

            public Builder clearPointer() {
                copyOnWrite();
                ((FilePointerMeta) this.instance).clearPointer();
                return this;
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
            public boolean hasLength() {
                return ((FilePointerMeta) this.instance).hasLength();
            }

            @Override // com.google.mediapipe.tasks.core.proto.ExternalFileProto.FilePointerMetaOrBuilder
            public long getLength() {
                return ((FilePointerMeta) this.instance).getLength();
            }

            public Builder setLength(long j) {
                copyOnWrite();
                ((FilePointerMeta) this.instance).setLength(j);
                return this;
            }

            public Builder clearLength() {
                copyOnWrite();
                ((FilePointerMeta) this.instance).clearLength();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new FilePointerMeta();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001ဃ\u0000\u0002ဂ\u0001", new Object[]{"bitField0_", "pointer_", "length_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<FilePointerMeta> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (FilePointerMeta.class) {
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
            FilePointerMeta filePointerMeta = new FilePointerMeta();
            DEFAULT_INSTANCE = filePointerMeta;
            GeneratedMessageLite.registerDefaultInstance(FilePointerMeta.class, filePointerMeta);
        }

        public static FilePointerMeta getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<FilePointerMeta> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
