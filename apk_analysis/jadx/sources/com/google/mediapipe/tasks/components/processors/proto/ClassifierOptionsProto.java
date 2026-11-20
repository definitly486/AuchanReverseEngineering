package com.google.mediapipe.tasks.components.processors.proto;

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
public final class ClassifierOptionsProto {

    public interface ClassifierOptionsOrBuilder extends MessageLiteOrBuilder {
        String getCategoryAllowlist(int i);

        ByteString getCategoryAllowlistBytes(int i);

        int getCategoryAllowlistCount();

        List<String> getCategoryAllowlistList();

        String getCategoryDenylist(int i);

        ByteString getCategoryDenylistBytes(int i);

        int getCategoryDenylistCount();

        List<String> getCategoryDenylistList();

        String getDisplayNamesLocale();

        ByteString getDisplayNamesLocaleBytes();

        int getMaxResults();

        float getScoreThreshold();

        boolean hasDisplayNamesLocale();

        boolean hasMaxResults();

        boolean hasScoreThreshold();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private ClassifierOptionsProto() {
    }

    public static final class ClassifierOptions extends GeneratedMessageLite<ClassifierOptions, Builder> implements ClassifierOptionsOrBuilder {
        public static final int CATEGORY_ALLOWLIST_FIELD_NUMBER = 4;
        public static final int CATEGORY_DENYLIST_FIELD_NUMBER = 5;
        private static final ClassifierOptions DEFAULT_INSTANCE;
        public static final int DISPLAY_NAMES_LOCALE_FIELD_NUMBER = 1;
        public static final int MAX_RESULTS_FIELD_NUMBER = 2;
        private static volatile Parser<ClassifierOptions> PARSER = null;
        public static final int SCORE_THRESHOLD_FIELD_NUMBER = 3;
        private int bitField0_;
        private float scoreThreshold_;
        private String displayNamesLocale_ = "en";
        private int maxResults_ = -1;
        private Internal.ProtobufList<String> categoryAllowlist_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> categoryDenylist_ = GeneratedMessageLite.emptyProtobufList();

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

        private ClassifierOptions() {
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public boolean hasDisplayNamesLocale() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public String getDisplayNamesLocale() {
            return this.displayNamesLocale_;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public ByteString getDisplayNamesLocaleBytes() {
            return ByteString.copyFromUtf8(this.displayNamesLocale_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayNamesLocale(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.displayNamesLocale_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDisplayNamesLocale() {
            this.bitField0_ &= -2;
            this.displayNamesLocale_ = getDefaultInstance().getDisplayNamesLocale();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayNamesLocaleBytes(ByteString byteString) {
            this.displayNamesLocale_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public boolean hasMaxResults() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public int getMaxResults() {
            return this.maxResults_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMaxResults(int i) {
            this.bitField0_ |= 2;
            this.maxResults_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMaxResults() {
            this.bitField0_ &= -3;
            this.maxResults_ = -1;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public boolean hasScoreThreshold() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public float getScoreThreshold() {
            return this.scoreThreshold_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setScoreThreshold(float f) {
            this.bitField0_ |= 4;
            this.scoreThreshold_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearScoreThreshold() {
            this.bitField0_ &= -5;
            this.scoreThreshold_ = 0.0f;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public List<String> getCategoryAllowlistList() {
            return this.categoryAllowlist_;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public int getCategoryAllowlistCount() {
            return this.categoryAllowlist_.size();
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public String getCategoryAllowlist(int i) {
            return this.categoryAllowlist_.get(i);
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public ByteString getCategoryAllowlistBytes(int i) {
            return ByteString.copyFromUtf8(this.categoryAllowlist_.get(i));
        }

        private void ensureCategoryAllowlistIsMutable() {
            Internal.ProtobufList<String> protobufList = this.categoryAllowlist_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.categoryAllowlist_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCategoryAllowlist(int i, String str) {
            str.getClass();
            ensureCategoryAllowlistIsMutable();
            this.categoryAllowlist_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addCategoryAllowlist(String str) {
            str.getClass();
            ensureCategoryAllowlistIsMutable();
            this.categoryAllowlist_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllCategoryAllowlist(Iterable<String> iterable) {
            ensureCategoryAllowlistIsMutable();
            AbstractMessageLite.addAll(iterable, this.categoryAllowlist_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCategoryAllowlist() {
            this.categoryAllowlist_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addCategoryAllowlistBytes(ByteString byteString) {
            ensureCategoryAllowlistIsMutable();
            this.categoryAllowlist_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public List<String> getCategoryDenylistList() {
            return this.categoryDenylist_;
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public int getCategoryDenylistCount() {
            return this.categoryDenylist_.size();
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public String getCategoryDenylist(int i) {
            return this.categoryDenylist_.get(i);
        }

        @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
        public ByteString getCategoryDenylistBytes(int i) {
            return ByteString.copyFromUtf8(this.categoryDenylist_.get(i));
        }

        private void ensureCategoryDenylistIsMutable() {
            Internal.ProtobufList<String> protobufList = this.categoryDenylist_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.categoryDenylist_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCategoryDenylist(int i, String str) {
            str.getClass();
            ensureCategoryDenylistIsMutable();
            this.categoryDenylist_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addCategoryDenylist(String str) {
            str.getClass();
            ensureCategoryDenylistIsMutable();
            this.categoryDenylist_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllCategoryDenylist(Iterable<String> iterable) {
            ensureCategoryDenylistIsMutable();
            AbstractMessageLite.addAll(iterable, this.categoryDenylist_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCategoryDenylist() {
            this.categoryDenylist_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addCategoryDenylistBytes(ByteString byteString) {
            ensureCategoryDenylistIsMutable();
            this.categoryDenylist_.add(byteString.toStringUtf8());
        }

        public static ClassifierOptions parseFrom(ByteBuffer byteBuffer) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ClassifierOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ClassifierOptions parseFrom(ByteString byteString) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ClassifierOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ClassifierOptions parseFrom(byte[] bArr) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ClassifierOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ClassifierOptions parseFrom(InputStream inputStream) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassifierOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassifierOptions parseDelimitedFrom(InputStream inputStream) {
            return (ClassifierOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ClassifierOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassifierOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ClassifierOptions parseFrom(CodedInputStream codedInputStream) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ClassifierOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ClassifierOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ClassifierOptions classifierOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(classifierOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ClassifierOptions, Builder> implements ClassifierOptionsOrBuilder {
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
                super(ClassifierOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public boolean hasDisplayNamesLocale() {
                return ((ClassifierOptions) this.instance).hasDisplayNamesLocale();
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public String getDisplayNamesLocale() {
                return ((ClassifierOptions) this.instance).getDisplayNamesLocale();
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public ByteString getDisplayNamesLocaleBytes() {
                return ((ClassifierOptions) this.instance).getDisplayNamesLocaleBytes();
            }

            public Builder setDisplayNamesLocale(String str) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).setDisplayNamesLocale(str);
                return this;
            }

            public Builder clearDisplayNamesLocale() {
                copyOnWrite();
                ((ClassifierOptions) this.instance).clearDisplayNamesLocale();
                return this;
            }

            public Builder setDisplayNamesLocaleBytes(ByteString byteString) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).setDisplayNamesLocaleBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public boolean hasMaxResults() {
                return ((ClassifierOptions) this.instance).hasMaxResults();
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public int getMaxResults() {
                return ((ClassifierOptions) this.instance).getMaxResults();
            }

            public Builder setMaxResults(int i) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).setMaxResults(i);
                return this;
            }

            public Builder clearMaxResults() {
                copyOnWrite();
                ((ClassifierOptions) this.instance).clearMaxResults();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public boolean hasScoreThreshold() {
                return ((ClassifierOptions) this.instance).hasScoreThreshold();
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public float getScoreThreshold() {
                return ((ClassifierOptions) this.instance).getScoreThreshold();
            }

            public Builder setScoreThreshold(float f) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).setScoreThreshold(f);
                return this;
            }

            public Builder clearScoreThreshold() {
                copyOnWrite();
                ((ClassifierOptions) this.instance).clearScoreThreshold();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public List<String> getCategoryAllowlistList() {
                return Collections.unmodifiableList(((ClassifierOptions) this.instance).getCategoryAllowlistList());
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public int getCategoryAllowlistCount() {
                return ((ClassifierOptions) this.instance).getCategoryAllowlistCount();
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public String getCategoryAllowlist(int i) {
                return ((ClassifierOptions) this.instance).getCategoryAllowlist(i);
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public ByteString getCategoryAllowlistBytes(int i) {
                return ((ClassifierOptions) this.instance).getCategoryAllowlistBytes(i);
            }

            public Builder setCategoryAllowlist(int i, String str) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).setCategoryAllowlist(i, str);
                return this;
            }

            public Builder addCategoryAllowlist(String str) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).addCategoryAllowlist(str);
                return this;
            }

            public Builder addAllCategoryAllowlist(Iterable<String> iterable) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).addAllCategoryAllowlist(iterable);
                return this;
            }

            public Builder clearCategoryAllowlist() {
                copyOnWrite();
                ((ClassifierOptions) this.instance).clearCategoryAllowlist();
                return this;
            }

            public Builder addCategoryAllowlistBytes(ByteString byteString) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).addCategoryAllowlistBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public List<String> getCategoryDenylistList() {
                return Collections.unmodifiableList(((ClassifierOptions) this.instance).getCategoryDenylistList());
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public int getCategoryDenylistCount() {
                return ((ClassifierOptions) this.instance).getCategoryDenylistCount();
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public String getCategoryDenylist(int i) {
                return ((ClassifierOptions) this.instance).getCategoryDenylist(i);
            }

            @Override // com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto.ClassifierOptionsOrBuilder
            public ByteString getCategoryDenylistBytes(int i) {
                return ((ClassifierOptions) this.instance).getCategoryDenylistBytes(i);
            }

            public Builder setCategoryDenylist(int i, String str) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).setCategoryDenylist(i, str);
                return this;
            }

            public Builder addCategoryDenylist(String str) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).addCategoryDenylist(str);
                return this;
            }

            public Builder addAllCategoryDenylist(Iterable<String> iterable) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).addAllCategoryDenylist(iterable);
                return this;
            }

            public Builder clearCategoryDenylist() {
                copyOnWrite();
                ((ClassifierOptions) this.instance).clearCategoryDenylist();
                return this;
            }

            public Builder addCategoryDenylistBytes(ByteString byteString) {
                copyOnWrite();
                ((ClassifierOptions) this.instance).addCategoryDenylistBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ClassifierOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0005\u0000\u0001\u0001\u0005\u0005\u0000\u0002\u0000\u0001ဈ\u0000\u0002င\u0001\u0003ခ\u0002\u0004\u001a\u0005\u001a", new Object[]{"bitField0_", "displayNamesLocale_", "maxResults_", "scoreThreshold_", "categoryAllowlist_", "categoryDenylist_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ClassifierOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ClassifierOptions.class) {
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
            ClassifierOptions classifierOptions = new ClassifierOptions();
            DEFAULT_INSTANCE = classifierOptions;
            GeneratedMessageLite.registerDefaultInstance(ClassifierOptions.class, classifierOptions);
        }

        public static ClassifierOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ClassifierOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto$1, reason: invalid class name */
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
