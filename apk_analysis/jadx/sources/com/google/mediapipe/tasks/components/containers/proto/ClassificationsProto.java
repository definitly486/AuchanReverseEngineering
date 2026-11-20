package com.google.mediapipe.tasks.components.containers.proto;

import com.google.mediapipe.formats.proto.ClassificationProto;
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
public final class ClassificationsProto {

    public interface ClassificationResultOrBuilder extends MessageLiteOrBuilder {
        Classifications getClassifications(int i);

        int getClassificationsCount();

        List<Classifications> getClassificationsList();

        long getTimestampMs();

        boolean hasTimestampMs();
    }

    public interface ClassificationsOrBuilder extends MessageLiteOrBuilder {
        ClassificationProto.ClassificationList getClassificationList();

        int getHeadIndex();

        String getHeadName();

        ByteString getHeadNameBytes();

        boolean hasClassificationList();

        boolean hasHeadIndex();

        boolean hasHeadName();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private ClassificationsProto() {
    }

    public static final class Classifications extends GeneratedMessageLite<Classifications, Builder> implements ClassificationsOrBuilder {
        public static final int CLASSIFICATION_LIST_FIELD_NUMBER = 4;
        private static final Classifications DEFAULT_INSTANCE;
        public static final int HEAD_INDEX_FIELD_NUMBER = 2;
        public static final int HEAD_NAME_FIELD_NUMBER = 3;
        private static volatile Parser<Classifications> PARSER;
        private int bitField0_;
        private ClassificationProto.ClassificationList classificationList_;
        private int headIndex_;
        private String headName_ = "";

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

        private Classifications() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
        public boolean hasClassificationList() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
        public ClassificationProto.ClassificationList getClassificationList() {
            ClassificationProto.ClassificationList classificationList = this.classificationList_;
            return classificationList == null ? ClassificationProto.ClassificationList.getDefaultInstance() : classificationList;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClassificationList(ClassificationProto.ClassificationList classificationList) {
            classificationList.getClass();
            this.classificationList_ = classificationList;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeClassificationList(ClassificationProto.ClassificationList classificationList) {
            classificationList.getClass();
            ClassificationProto.ClassificationList classificationList2 = this.classificationList_;
            if (classificationList2 != null && classificationList2 != ClassificationProto.ClassificationList.getDefaultInstance()) {
                this.classificationList_ = ClassificationProto.ClassificationList.newBuilder(this.classificationList_).mergeFrom(classificationList).buildPartial();
            } else {
                this.classificationList_ = classificationList;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearClassificationList() {
            this.classificationList_ = null;
            this.bitField0_ &= -2;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
        public boolean hasHeadIndex() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
        public int getHeadIndex() {
            return this.headIndex_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeadIndex(int i) {
            this.bitField0_ |= 2;
            this.headIndex_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHeadIndex() {
            this.bitField0_ &= -3;
            this.headIndex_ = 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
        public boolean hasHeadName() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
        public String getHeadName() {
            return this.headName_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
        public ByteString getHeadNameBytes() {
            return ByteString.copyFromUtf8(this.headName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeadName(String str) {
            str.getClass();
            this.bitField0_ |= 4;
            this.headName_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHeadName() {
            this.bitField0_ &= -5;
            this.headName_ = getDefaultInstance().getHeadName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeadNameBytes(ByteString byteString) {
            this.headName_ = byteString.toStringUtf8();
            this.bitField0_ |= 4;
        }

        public static Classifications parseFrom(ByteBuffer byteBuffer) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Classifications parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Classifications parseFrom(ByteString byteString) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Classifications parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Classifications parseFrom(byte[] bArr) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Classifications parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Classifications parseFrom(InputStream inputStream) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Classifications parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Classifications parseDelimitedFrom(InputStream inputStream) {
            return (Classifications) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Classifications parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Classifications) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Classifications parseFrom(CodedInputStream codedInputStream) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Classifications parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Classifications) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Classifications classifications) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(classifications);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Classifications, Builder> implements ClassificationsOrBuilder {
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
                super(Classifications.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
            public boolean hasClassificationList() {
                return ((Classifications) this.instance).hasClassificationList();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
            public ClassificationProto.ClassificationList getClassificationList() {
                return ((Classifications) this.instance).getClassificationList();
            }

            public Builder setClassificationList(ClassificationProto.ClassificationList classificationList) {
                copyOnWrite();
                ((Classifications) this.instance).setClassificationList(classificationList);
                return this;
            }

            public Builder setClassificationList(ClassificationProto.ClassificationList.Builder builder) {
                copyOnWrite();
                ((Classifications) this.instance).setClassificationList(builder.build());
                return this;
            }

            public Builder mergeClassificationList(ClassificationProto.ClassificationList classificationList) {
                copyOnWrite();
                ((Classifications) this.instance).mergeClassificationList(classificationList);
                return this;
            }

            public Builder clearClassificationList() {
                copyOnWrite();
                ((Classifications) this.instance).clearClassificationList();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
            public boolean hasHeadIndex() {
                return ((Classifications) this.instance).hasHeadIndex();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
            public int getHeadIndex() {
                return ((Classifications) this.instance).getHeadIndex();
            }

            public Builder setHeadIndex(int i) {
                copyOnWrite();
                ((Classifications) this.instance).setHeadIndex(i);
                return this;
            }

            public Builder clearHeadIndex() {
                copyOnWrite();
                ((Classifications) this.instance).clearHeadIndex();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
            public boolean hasHeadName() {
                return ((Classifications) this.instance).hasHeadName();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
            public String getHeadName() {
                return ((Classifications) this.instance).getHeadName();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationsOrBuilder
            public ByteString getHeadNameBytes() {
                return ((Classifications) this.instance).getHeadNameBytes();
            }

            public Builder setHeadName(String str) {
                copyOnWrite();
                ((Classifications) this.instance).setHeadName(str);
                return this;
            }

            public Builder clearHeadName() {
                copyOnWrite();
                ((Classifications) this.instance).clearHeadName();
                return this;
            }

            public Builder setHeadNameBytes(ByteString byteString) {
                copyOnWrite();
                ((Classifications) this.instance).setHeadNameBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Classifications();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0002\u0004\u0003\u0000\u0000\u0000\u0002င\u0001\u0003ဈ\u0002\u0004ဉ\u0000", new Object[]{"bitField0_", "headIndex_", "headName_", "classificationList_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Classifications> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Classifications.class) {
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
            Classifications classifications = new Classifications();
            DEFAULT_INSTANCE = classifications;
            GeneratedMessageLite.registerDefaultInstance(Classifications.class, classifications);
        }

        public static Classifications getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Classifications> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto$1, reason: invalid class name */
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

    public static final class ClassificationResult extends GeneratedMessageLite<ClassificationResult, Builder> implements ClassificationResultOrBuilder {
        public static final int CLASSIFICATIONS_FIELD_NUMBER = 1;
        private static final ClassificationResult DEFAULT_INSTANCE;
        private static volatile Parser<ClassificationResult> PARSER = null;
        public static final int TIMESTAMP_MS_FIELD_NUMBER = 2;
        private int bitField0_;
        private Internal.ProtobufList<Classifications> classifications_ = GeneratedMessageLite.emptyProtobufList();
        private long timestampMs_;

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

        private ClassificationResult() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
        public List<Classifications> getClassificationsList() {
            return this.classifications_;
        }

        public List<? extends ClassificationsOrBuilder> getClassificationsOrBuilderList() {
            return this.classifications_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
        public int getClassificationsCount() {
            return this.classifications_.size();
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
        public Classifications getClassifications(int i) {
            return this.classifications_.get(i);
        }

        public ClassificationsOrBuilder getClassificationsOrBuilder(int i) {
            return this.classifications_.get(i);
        }

        private void ensureClassificationsIsMutable() {
            Internal.ProtobufList<Classifications> protobufList = this.classifications_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.classifications_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClassifications(int i, Classifications classifications) {
            classifications.getClass();
            ensureClassificationsIsMutable();
            this.classifications_.set(i, classifications);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassifications(Classifications classifications) {
            classifications.getClass();
            ensureClassificationsIsMutable();
            this.classifications_.add(classifications);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassifications(int i, Classifications classifications) {
            classifications.getClass();
            ensureClassificationsIsMutable();
            this.classifications_.add(i, classifications);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllClassifications(Iterable<? extends Classifications> iterable) {
            ensureClassificationsIsMutable();
            AbstractMessageLite.addAll(iterable, this.classifications_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearClassifications() {
            this.classifications_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeClassifications(int i) {
            ensureClassificationsIsMutable();
            this.classifications_.remove(i);
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
        public boolean hasTimestampMs() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
        public long getTimestampMs() {
            return this.timestampMs_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTimestampMs(long j) {
            this.bitField0_ |= 1;
            this.timestampMs_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTimestampMs() {
            this.bitField0_ &= -2;
            this.timestampMs_ = 0L;
        }

        public static ClassificationResult parseFrom(ByteBuffer byteBuffer) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ClassificationResult parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ClassificationResult parseFrom(ByteString byteString) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ClassificationResult parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ClassificationResult parseFrom(byte[] bArr) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ClassificationResult parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ClassificationResult parseFrom(InputStream inputStream) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassificationResult parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassificationResult parseDelimitedFrom(InputStream inputStream) {
            return (ClassificationResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassificationResult parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassificationResult parseFrom(CodedInputStream codedInputStream) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ClassificationResult parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ClassificationResult classificationResult) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(classificationResult);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ClassificationResult, Builder> implements ClassificationResultOrBuilder {
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
                super(ClassificationResult.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
            public List<Classifications> getClassificationsList() {
                return Collections.unmodifiableList(((ClassificationResult) this.instance).getClassificationsList());
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
            public int getClassificationsCount() {
                return ((ClassificationResult) this.instance).getClassificationsCount();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
            public Classifications getClassifications(int i) {
                return ((ClassificationResult) this.instance).getClassifications(i);
            }

            public Builder setClassifications(int i, Classifications classifications) {
                copyOnWrite();
                ((ClassificationResult) this.instance).setClassifications(i, classifications);
                return this;
            }

            public Builder setClassifications(int i, Classifications.Builder builder) {
                copyOnWrite();
                ((ClassificationResult) this.instance).setClassifications(i, builder.build());
                return this;
            }

            public Builder addClassifications(Classifications classifications) {
                copyOnWrite();
                ((ClassificationResult) this.instance).addClassifications(classifications);
                return this;
            }

            public Builder addClassifications(int i, Classifications classifications) {
                copyOnWrite();
                ((ClassificationResult) this.instance).addClassifications(i, classifications);
                return this;
            }

            public Builder addClassifications(Classifications.Builder builder) {
                copyOnWrite();
                ((ClassificationResult) this.instance).addClassifications(builder.build());
                return this;
            }

            public Builder addClassifications(int i, Classifications.Builder builder) {
                copyOnWrite();
                ((ClassificationResult) this.instance).addClassifications(i, builder.build());
                return this;
            }

            public Builder addAllClassifications(Iterable<? extends Classifications> iterable) {
                copyOnWrite();
                ((ClassificationResult) this.instance).addAllClassifications(iterable);
                return this;
            }

            public Builder clearClassifications() {
                copyOnWrite();
                ((ClassificationResult) this.instance).clearClassifications();
                return this;
            }

            public Builder removeClassifications(int i) {
                copyOnWrite();
                ((ClassificationResult) this.instance).removeClassifications(i);
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
            public boolean hasTimestampMs() {
                return ((ClassificationResult) this.instance).hasTimestampMs();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.ClassificationsProto.ClassificationResultOrBuilder
            public long getTimestampMs() {
                return ((ClassificationResult) this.instance).getTimestampMs();
            }

            public Builder setTimestampMs(long j) {
                copyOnWrite();
                ((ClassificationResult) this.instance).setTimestampMs(j);
                return this;
            }

            public Builder clearTimestampMs() {
                copyOnWrite();
                ((ClassificationResult) this.instance).clearTimestampMs();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ClassificationResult();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0001\u0000\u0001\u001b\u0002ဂ\u0000", new Object[]{"bitField0_", "classifications_", Classifications.class, "timestampMs_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ClassificationResult> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ClassificationResult.class) {
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
            ClassificationResult classificationResult = new ClassificationResult();
            DEFAULT_INSTANCE = classificationResult;
            GeneratedMessageLite.registerDefaultInstance(ClassificationResult.class, classificationResult);
        }

        public static ClassificationResult getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ClassificationResult> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
