package com.google.mediapipe.formats.proto;

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
public final class ClassificationProto {

    public interface ClassificationListCollectionOrBuilder extends MessageLiteOrBuilder {
        ClassificationList getClassificationList(int i);

        int getClassificationListCount();

        List<ClassificationList> getClassificationListList();
    }

    public interface ClassificationListOrBuilder extends MessageLiteOrBuilder {
        Classification getClassification(int i);

        int getClassificationCount();

        List<Classification> getClassificationList();
    }

    public interface ClassificationOrBuilder extends MessageLiteOrBuilder {
        String getDisplayName();

        ByteString getDisplayNameBytes();

        int getIndex();

        String getLabel();

        ByteString getLabelBytes();

        float getScore();

        boolean hasDisplayName();

        boolean hasIndex();

        boolean hasLabel();

        boolean hasScore();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private ClassificationProto() {
    }

    public static final class Classification extends GeneratedMessageLite<Classification, Builder> implements ClassificationOrBuilder {
        private static final Classification DEFAULT_INSTANCE;
        public static final int DISPLAY_NAME_FIELD_NUMBER = 4;
        public static final int INDEX_FIELD_NUMBER = 1;
        public static final int LABEL_FIELD_NUMBER = 3;
        private static volatile Parser<Classification> PARSER = null;
        public static final int SCORE_FIELD_NUMBER = 2;
        private int bitField0_;
        private int index_;
        private float score_;
        private String label_ = "";
        private String displayName_ = "";

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

        private Classification() {
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public boolean hasIndex() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public int getIndex() {
            return this.index_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setIndex(int i) {
            this.bitField0_ |= 1;
            this.index_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearIndex() {
            this.bitField0_ &= -2;
            this.index_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public boolean hasScore() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public float getScore() {
            return this.score_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setScore(float f) {
            this.bitField0_ |= 2;
            this.score_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearScore() {
            this.bitField0_ &= -3;
            this.score_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public boolean hasLabel() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public String getLabel() {
            return this.label_;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public ByteString getLabelBytes() {
            return ByteString.copyFromUtf8(this.label_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLabel(String str) {
            str.getClass();
            this.bitField0_ |= 4;
            this.label_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLabel() {
            this.bitField0_ &= -5;
            this.label_ = getDefaultInstance().getLabel();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLabelBytes(ByteString byteString) {
            this.label_ = byteString.toStringUtf8();
            this.bitField0_ |= 4;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public boolean hasDisplayName() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public String getDisplayName() {
            return this.displayName_;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
        public ByteString getDisplayNameBytes() {
            return ByteString.copyFromUtf8(this.displayName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayName(String str) {
            str.getClass();
            this.bitField0_ |= 8;
            this.displayName_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDisplayName() {
            this.bitField0_ &= -9;
            this.displayName_ = getDefaultInstance().getDisplayName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayNameBytes(ByteString byteString) {
            this.displayName_ = byteString.toStringUtf8();
            this.bitField0_ |= 8;
        }

        public static Classification parseFrom(ByteBuffer byteBuffer) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Classification parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Classification parseFrom(ByteString byteString) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Classification parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Classification parseFrom(byte[] bArr) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Classification parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Classification parseFrom(InputStream inputStream) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Classification parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Classification parseDelimitedFrom(InputStream inputStream) {
            return (Classification) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Classification parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Classification) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Classification parseFrom(CodedInputStream codedInputStream) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Classification parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Classification) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Classification classification) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(classification);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Classification, Builder> implements ClassificationOrBuilder {
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
                super(Classification.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public boolean hasIndex() {
                return ((Classification) this.instance).hasIndex();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public int getIndex() {
                return ((Classification) this.instance).getIndex();
            }

            public Builder setIndex(int i) {
                copyOnWrite();
                ((Classification) this.instance).setIndex(i);
                return this;
            }

            public Builder clearIndex() {
                copyOnWrite();
                ((Classification) this.instance).clearIndex();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public boolean hasScore() {
                return ((Classification) this.instance).hasScore();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public float getScore() {
                return ((Classification) this.instance).getScore();
            }

            public Builder setScore(float f) {
                copyOnWrite();
                ((Classification) this.instance).setScore(f);
                return this;
            }

            public Builder clearScore() {
                copyOnWrite();
                ((Classification) this.instance).clearScore();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public boolean hasLabel() {
                return ((Classification) this.instance).hasLabel();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public String getLabel() {
                return ((Classification) this.instance).getLabel();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public ByteString getLabelBytes() {
                return ((Classification) this.instance).getLabelBytes();
            }

            public Builder setLabel(String str) {
                copyOnWrite();
                ((Classification) this.instance).setLabel(str);
                return this;
            }

            public Builder clearLabel() {
                copyOnWrite();
                ((Classification) this.instance).clearLabel();
                return this;
            }

            public Builder setLabelBytes(ByteString byteString) {
                copyOnWrite();
                ((Classification) this.instance).setLabelBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public boolean hasDisplayName() {
                return ((Classification) this.instance).hasDisplayName();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public String getDisplayName() {
                return ((Classification) this.instance).getDisplayName();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationOrBuilder
            public ByteString getDisplayNameBytes() {
                return ((Classification) this.instance).getDisplayNameBytes();
            }

            public Builder setDisplayName(String str) {
                copyOnWrite();
                ((Classification) this.instance).setDisplayName(str);
                return this;
            }

            public Builder clearDisplayName() {
                copyOnWrite();
                ((Classification) this.instance).clearDisplayName();
                return this;
            }

            public Builder setDisplayNameBytes(ByteString byteString) {
                copyOnWrite();
                ((Classification) this.instance).setDisplayNameBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Classification();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001င\u0000\u0002ခ\u0001\u0003ဈ\u0002\u0004ဈ\u0003", new Object[]{"bitField0_", "index_", "score_", "label_", "displayName_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Classification> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Classification.class) {
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
            Classification classification = new Classification();
            DEFAULT_INSTANCE = classification;
            GeneratedMessageLite.registerDefaultInstance(Classification.class, classification);
        }

        public static Classification getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Classification> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.formats.proto.ClassificationProto$1, reason: invalid class name */
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

    public static final class ClassificationList extends GeneratedMessageLite<ClassificationList, Builder> implements ClassificationListOrBuilder {
        public static final int CLASSIFICATION_FIELD_NUMBER = 1;
        private static final ClassificationList DEFAULT_INSTANCE;
        private static volatile Parser<ClassificationList> PARSER;
        private Internal.ProtobufList<Classification> classification_ = GeneratedMessageLite.emptyProtobufList();

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

        private ClassificationList() {
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListOrBuilder
        public List<Classification> getClassificationList() {
            return this.classification_;
        }

        public List<? extends ClassificationOrBuilder> getClassificationOrBuilderList() {
            return this.classification_;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListOrBuilder
        public int getClassificationCount() {
            return this.classification_.size();
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListOrBuilder
        public Classification getClassification(int i) {
            return this.classification_.get(i);
        }

        public ClassificationOrBuilder getClassificationOrBuilder(int i) {
            return this.classification_.get(i);
        }

        private void ensureClassificationIsMutable() {
            Internal.ProtobufList<Classification> protobufList = this.classification_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.classification_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClassification(int i, Classification classification) {
            classification.getClass();
            ensureClassificationIsMutable();
            this.classification_.set(i, classification);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassification(Classification classification) {
            classification.getClass();
            ensureClassificationIsMutable();
            this.classification_.add(classification);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassification(int i, Classification classification) {
            classification.getClass();
            ensureClassificationIsMutable();
            this.classification_.add(i, classification);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllClassification(Iterable<? extends Classification> iterable) {
            ensureClassificationIsMutable();
            AbstractMessageLite.addAll(iterable, this.classification_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearClassification() {
            this.classification_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeClassification(int i) {
            ensureClassificationIsMutable();
            this.classification_.remove(i);
        }

        public static ClassificationList parseFrom(ByteBuffer byteBuffer) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ClassificationList parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ClassificationList parseFrom(ByteString byteString) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ClassificationList parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ClassificationList parseFrom(byte[] bArr) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ClassificationList parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ClassificationList parseFrom(InputStream inputStream) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassificationList parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassificationList parseDelimitedFrom(InputStream inputStream) {
            return (ClassificationList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassificationList parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassificationList parseFrom(CodedInputStream codedInputStream) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ClassificationList parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ClassificationList classificationList) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(classificationList);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ClassificationList, Builder> implements ClassificationListOrBuilder {
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
                super(ClassificationList.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListOrBuilder
            public List<Classification> getClassificationList() {
                return Collections.unmodifiableList(((ClassificationList) this.instance).getClassificationList());
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListOrBuilder
            public int getClassificationCount() {
                return ((ClassificationList) this.instance).getClassificationCount();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListOrBuilder
            public Classification getClassification(int i) {
                return ((ClassificationList) this.instance).getClassification(i);
            }

            public Builder setClassification(int i, Classification classification) {
                copyOnWrite();
                ((ClassificationList) this.instance).setClassification(i, classification);
                return this;
            }

            public Builder setClassification(int i, Classification.Builder builder) {
                copyOnWrite();
                ((ClassificationList) this.instance).setClassification(i, builder.build());
                return this;
            }

            public Builder addClassification(Classification classification) {
                copyOnWrite();
                ((ClassificationList) this.instance).addClassification(classification);
                return this;
            }

            public Builder addClassification(int i, Classification classification) {
                copyOnWrite();
                ((ClassificationList) this.instance).addClassification(i, classification);
                return this;
            }

            public Builder addClassification(Classification.Builder builder) {
                copyOnWrite();
                ((ClassificationList) this.instance).addClassification(builder.build());
                return this;
            }

            public Builder addClassification(int i, Classification.Builder builder) {
                copyOnWrite();
                ((ClassificationList) this.instance).addClassification(i, builder.build());
                return this;
            }

            public Builder addAllClassification(Iterable<? extends Classification> iterable) {
                copyOnWrite();
                ((ClassificationList) this.instance).addAllClassification(iterable);
                return this;
            }

            public Builder clearClassification() {
                copyOnWrite();
                ((ClassificationList) this.instance).clearClassification();
                return this;
            }

            public Builder removeClassification(int i) {
                copyOnWrite();
                ((ClassificationList) this.instance).removeClassification(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ClassificationList();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"classification_", Classification.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ClassificationList> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ClassificationList.class) {
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
            ClassificationList classificationList = new ClassificationList();
            DEFAULT_INSTANCE = classificationList;
            GeneratedMessageLite.registerDefaultInstance(ClassificationList.class, classificationList);
        }

        public static ClassificationList getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ClassificationList> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class ClassificationListCollection extends GeneratedMessageLite<ClassificationListCollection, Builder> implements ClassificationListCollectionOrBuilder {
        public static final int CLASSIFICATION_LIST_FIELD_NUMBER = 1;
        private static final ClassificationListCollection DEFAULT_INSTANCE;
        private static volatile Parser<ClassificationListCollection> PARSER;
        private Internal.ProtobufList<ClassificationList> classificationList_ = GeneratedMessageLite.emptyProtobufList();

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

        private ClassificationListCollection() {
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListCollectionOrBuilder
        public List<ClassificationList> getClassificationListList() {
            return this.classificationList_;
        }

        public List<? extends ClassificationListOrBuilder> getClassificationListOrBuilderList() {
            return this.classificationList_;
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListCollectionOrBuilder
        public int getClassificationListCount() {
            return this.classificationList_.size();
        }

        @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListCollectionOrBuilder
        public ClassificationList getClassificationList(int i) {
            return this.classificationList_.get(i);
        }

        public ClassificationListOrBuilder getClassificationListOrBuilder(int i) {
            return this.classificationList_.get(i);
        }

        private void ensureClassificationListIsMutable() {
            Internal.ProtobufList<ClassificationList> protobufList = this.classificationList_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.classificationList_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClassificationList(int i, ClassificationList classificationList) {
            classificationList.getClass();
            ensureClassificationListIsMutable();
            this.classificationList_.set(i, classificationList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassificationList(ClassificationList classificationList) {
            classificationList.getClass();
            ensureClassificationListIsMutable();
            this.classificationList_.add(classificationList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassificationList(int i, ClassificationList classificationList) {
            classificationList.getClass();
            ensureClassificationListIsMutable();
            this.classificationList_.add(i, classificationList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllClassificationList(Iterable<? extends ClassificationList> iterable) {
            ensureClassificationListIsMutable();
            AbstractMessageLite.addAll(iterable, this.classificationList_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearClassificationList() {
            this.classificationList_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeClassificationList(int i) {
            ensureClassificationListIsMutable();
            this.classificationList_.remove(i);
        }

        public static ClassificationListCollection parseFrom(ByteBuffer byteBuffer) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ClassificationListCollection parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ClassificationListCollection parseFrom(ByteString byteString) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ClassificationListCollection parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ClassificationListCollection parseFrom(byte[] bArr) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ClassificationListCollection parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ClassificationListCollection parseFrom(InputStream inputStream) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassificationListCollection parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassificationListCollection parseDelimitedFrom(InputStream inputStream) {
            return (ClassificationListCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassificationListCollection parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationListCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassificationListCollection parseFrom(CodedInputStream codedInputStream) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ClassificationListCollection parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassificationListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ClassificationListCollection classificationListCollection) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(classificationListCollection);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ClassificationListCollection, Builder> implements ClassificationListCollectionOrBuilder {
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
                super(ClassificationListCollection.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListCollectionOrBuilder
            public List<ClassificationList> getClassificationListList() {
                return Collections.unmodifiableList(((ClassificationListCollection) this.instance).getClassificationListList());
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListCollectionOrBuilder
            public int getClassificationListCount() {
                return ((ClassificationListCollection) this.instance).getClassificationListCount();
            }

            @Override // com.google.mediapipe.formats.proto.ClassificationProto.ClassificationListCollectionOrBuilder
            public ClassificationList getClassificationList(int i) {
                return ((ClassificationListCollection) this.instance).getClassificationList(i);
            }

            public Builder setClassificationList(int i, ClassificationList classificationList) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).setClassificationList(i, classificationList);
                return this;
            }

            public Builder setClassificationList(int i, ClassificationList.Builder builder) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).setClassificationList(i, builder.build());
                return this;
            }

            public Builder addClassificationList(ClassificationList classificationList) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).addClassificationList(classificationList);
                return this;
            }

            public Builder addClassificationList(int i, ClassificationList classificationList) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).addClassificationList(i, classificationList);
                return this;
            }

            public Builder addClassificationList(ClassificationList.Builder builder) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).addClassificationList(builder.build());
                return this;
            }

            public Builder addClassificationList(int i, ClassificationList.Builder builder) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).addClassificationList(i, builder.build());
                return this;
            }

            public Builder addAllClassificationList(Iterable<? extends ClassificationList> iterable) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).addAllClassificationList(iterable);
                return this;
            }

            public Builder clearClassificationList() {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).clearClassificationList();
                return this;
            }

            public Builder removeClassificationList(int i) {
                copyOnWrite();
                ((ClassificationListCollection) this.instance).removeClassificationList(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ClassificationListCollection();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"classificationList_", ClassificationList.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ClassificationListCollection> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ClassificationListCollection.class) {
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
            ClassificationListCollection classificationListCollection = new ClassificationListCollection();
            DEFAULT_INSTANCE = classificationListCollection;
            GeneratedMessageLite.registerDefaultInstance(ClassificationListCollection.class, classificationListCollection);
        }

        public static ClassificationListCollection getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ClassificationListCollection> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
