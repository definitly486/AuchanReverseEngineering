package com.google.mediapipe.tasks.vision.objectdetector.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.Internal;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import com.google.protobuf.WireFormat;
import java.io.InputStream;
import java.nio.ByteBuffer;
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class ObjectDetectorOptionsProto {

    public interface ObjectDetectorOptionsOrBuilder extends MessageLiteOrBuilder {
        BaseOptionsProto.BaseOptions getBaseOptions();

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

        float getMinSuppressionThreshold();

        boolean getMulticlassNms();

        float getScoreThreshold();

        boolean hasBaseOptions();

        boolean hasDisplayNamesLocale();

        boolean hasMaxResults();

        boolean hasMinSuppressionThreshold();

        boolean hasMulticlassNms();

        boolean hasScoreThreshold();
    }

    private ObjectDetectorOptionsProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) ObjectDetectorOptions.ext);
    }

    public static final class ObjectDetectorOptions extends GeneratedMessageLite<ObjectDetectorOptions, Builder> implements ObjectDetectorOptionsOrBuilder {
        public static final int BASE_OPTIONS_FIELD_NUMBER = 1;
        public static final int CATEGORY_ALLOWLIST_FIELD_NUMBER = 5;
        public static final int CATEGORY_DENYLIST_FIELD_NUMBER = 6;
        private static final ObjectDetectorOptions DEFAULT_INSTANCE;
        public static final int DISPLAY_NAMES_LOCALE_FIELD_NUMBER = 2;
        public static final int EXT_FIELD_NUMBER = 443442058;
        public static final int MAX_RESULTS_FIELD_NUMBER = 3;
        public static final int MIN_SUPPRESSION_THRESHOLD_FIELD_NUMBER = 8;
        public static final int MULTICLASS_NMS_FIELD_NUMBER = 7;
        private static volatile Parser<ObjectDetectorOptions> PARSER = null;
        public static final int SCORE_THRESHOLD_FIELD_NUMBER = 4;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, ObjectDetectorOptions> ext;
        private BaseOptionsProto.BaseOptions baseOptions_;
        private int bitField0_;
        private boolean multiclassNms_;
        private float scoreThreshold_;
        private String displayNamesLocale_ = "en";
        private int maxResults_ = -1;
        private Internal.ProtobufList<String> categoryAllowlist_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> categoryDenylist_ = GeneratedMessageLite.emptyProtobufList();
        private float minSuppressionThreshold_ = 0.3f;

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

        private ObjectDetectorOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public boolean hasBaseOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public BaseOptionsProto.BaseOptions getBaseOptions() {
            BaseOptionsProto.BaseOptions baseOptions = this.baseOptions_;
            return baseOptions == null ? BaseOptionsProto.BaseOptions.getDefaultInstance() : baseOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
            baseOptions.getClass();
            this.baseOptions_ = baseOptions;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
            baseOptions.getClass();
            BaseOptionsProto.BaseOptions baseOptions2 = this.baseOptions_;
            if (baseOptions2 != null && baseOptions2 != BaseOptionsProto.BaseOptions.getDefaultInstance()) {
                this.baseOptions_ = BaseOptionsProto.BaseOptions.newBuilder(this.baseOptions_).mergeFrom(baseOptions).buildPartial();
            } else {
                this.baseOptions_ = baseOptions;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearBaseOptions() {
            this.baseOptions_ = null;
            this.bitField0_ &= -2;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public boolean hasDisplayNamesLocale() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public String getDisplayNamesLocale() {
            return this.displayNamesLocale_;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public ByteString getDisplayNamesLocaleBytes() {
            return ByteString.copyFromUtf8(this.displayNamesLocale_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayNamesLocale(String str) {
            str.getClass();
            this.bitField0_ |= 2;
            this.displayNamesLocale_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDisplayNamesLocale() {
            this.bitField0_ &= -3;
            this.displayNamesLocale_ = getDefaultInstance().getDisplayNamesLocale();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayNamesLocaleBytes(ByteString byteString) {
            this.displayNamesLocale_ = byteString.toStringUtf8();
            this.bitField0_ |= 2;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public boolean hasMaxResults() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public int getMaxResults() {
            return this.maxResults_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMaxResults(int i) {
            this.bitField0_ |= 4;
            this.maxResults_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMaxResults() {
            this.bitField0_ &= -5;
            this.maxResults_ = -1;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public boolean hasScoreThreshold() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public float getScoreThreshold() {
            return this.scoreThreshold_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setScoreThreshold(float f) {
            this.bitField0_ |= 8;
            this.scoreThreshold_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearScoreThreshold() {
            this.bitField0_ &= -9;
            this.scoreThreshold_ = 0.0f;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public List<String> getCategoryAllowlistList() {
            return this.categoryAllowlist_;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public int getCategoryAllowlistCount() {
            return this.categoryAllowlist_.size();
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public String getCategoryAllowlist(int i) {
            return this.categoryAllowlist_.get(i);
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public List<String> getCategoryDenylistList() {
            return this.categoryDenylist_;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public int getCategoryDenylistCount() {
            return this.categoryDenylist_.size();
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public String getCategoryDenylist(int i) {
            return this.categoryDenylist_.get(i);
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public boolean hasMulticlassNms() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public boolean getMulticlassNms() {
            return this.multiclassNms_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMulticlassNms(boolean z) {
            this.bitField0_ |= 16;
            this.multiclassNms_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMulticlassNms() {
            this.bitField0_ &= -17;
            this.multiclassNms_ = false;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public boolean hasMinSuppressionThreshold() {
            return (this.bitField0_ & 32) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
        public float getMinSuppressionThreshold() {
            return this.minSuppressionThreshold_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMinSuppressionThreshold(float f) {
            this.bitField0_ |= 32;
            this.minSuppressionThreshold_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMinSuppressionThreshold() {
            this.bitField0_ &= -33;
            this.minSuppressionThreshold_ = 0.3f;
        }

        public static ObjectDetectorOptions parseFrom(ByteBuffer byteBuffer) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ObjectDetectorOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ObjectDetectorOptions parseFrom(ByteString byteString) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ObjectDetectorOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ObjectDetectorOptions parseFrom(byte[] bArr) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ObjectDetectorOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ObjectDetectorOptions parseFrom(InputStream inputStream) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ObjectDetectorOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ObjectDetectorOptions parseDelimitedFrom(InputStream inputStream) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ObjectDetectorOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ObjectDetectorOptions parseFrom(CodedInputStream codedInputStream) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ObjectDetectorOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ObjectDetectorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ObjectDetectorOptions objectDetectorOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(objectDetectorOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ObjectDetectorOptions, Builder> implements ObjectDetectorOptionsOrBuilder {
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
                super(ObjectDetectorOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public boolean hasBaseOptions() {
                return ((ObjectDetectorOptions) this.instance).hasBaseOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public BaseOptionsProto.BaseOptions getBaseOptions() {
                return ((ObjectDetectorOptions) this.instance).getBaseOptions();
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setBaseOptions(baseOptions);
                return this;
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions.Builder builder) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setBaseOptions(builder.build());
                return this;
            }

            public Builder mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).mergeBaseOptions(baseOptions);
                return this;
            }

            public Builder clearBaseOptions() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearBaseOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public boolean hasDisplayNamesLocale() {
                return ((ObjectDetectorOptions) this.instance).hasDisplayNamesLocale();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public String getDisplayNamesLocale() {
                return ((ObjectDetectorOptions) this.instance).getDisplayNamesLocale();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public ByteString getDisplayNamesLocaleBytes() {
                return ((ObjectDetectorOptions) this.instance).getDisplayNamesLocaleBytes();
            }

            public Builder setDisplayNamesLocale(String str) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setDisplayNamesLocale(str);
                return this;
            }

            public Builder clearDisplayNamesLocale() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearDisplayNamesLocale();
                return this;
            }

            public Builder setDisplayNamesLocaleBytes(ByteString byteString) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setDisplayNamesLocaleBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public boolean hasMaxResults() {
                return ((ObjectDetectorOptions) this.instance).hasMaxResults();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public int getMaxResults() {
                return ((ObjectDetectorOptions) this.instance).getMaxResults();
            }

            public Builder setMaxResults(int i) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setMaxResults(i);
                return this;
            }

            public Builder clearMaxResults() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearMaxResults();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public boolean hasScoreThreshold() {
                return ((ObjectDetectorOptions) this.instance).hasScoreThreshold();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public float getScoreThreshold() {
                return ((ObjectDetectorOptions) this.instance).getScoreThreshold();
            }

            public Builder setScoreThreshold(float f) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setScoreThreshold(f);
                return this;
            }

            public Builder clearScoreThreshold() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearScoreThreshold();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public List<String> getCategoryAllowlistList() {
                return Collections.unmodifiableList(((ObjectDetectorOptions) this.instance).getCategoryAllowlistList());
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public int getCategoryAllowlistCount() {
                return ((ObjectDetectorOptions) this.instance).getCategoryAllowlistCount();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public String getCategoryAllowlist(int i) {
                return ((ObjectDetectorOptions) this.instance).getCategoryAllowlist(i);
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public ByteString getCategoryAllowlistBytes(int i) {
                return ((ObjectDetectorOptions) this.instance).getCategoryAllowlistBytes(i);
            }

            public Builder setCategoryAllowlist(int i, String str) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setCategoryAllowlist(i, str);
                return this;
            }

            public Builder addCategoryAllowlist(String str) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).addCategoryAllowlist(str);
                return this;
            }

            public Builder addAllCategoryAllowlist(Iterable<String> iterable) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).addAllCategoryAllowlist(iterable);
                return this;
            }

            public Builder clearCategoryAllowlist() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearCategoryAllowlist();
                return this;
            }

            public Builder addCategoryAllowlistBytes(ByteString byteString) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).addCategoryAllowlistBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public List<String> getCategoryDenylistList() {
                return Collections.unmodifiableList(((ObjectDetectorOptions) this.instance).getCategoryDenylistList());
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public int getCategoryDenylistCount() {
                return ((ObjectDetectorOptions) this.instance).getCategoryDenylistCount();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public String getCategoryDenylist(int i) {
                return ((ObjectDetectorOptions) this.instance).getCategoryDenylist(i);
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public ByteString getCategoryDenylistBytes(int i) {
                return ((ObjectDetectorOptions) this.instance).getCategoryDenylistBytes(i);
            }

            public Builder setCategoryDenylist(int i, String str) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setCategoryDenylist(i, str);
                return this;
            }

            public Builder addCategoryDenylist(String str) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).addCategoryDenylist(str);
                return this;
            }

            public Builder addAllCategoryDenylist(Iterable<String> iterable) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).addAllCategoryDenylist(iterable);
                return this;
            }

            public Builder clearCategoryDenylist() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearCategoryDenylist();
                return this;
            }

            public Builder addCategoryDenylistBytes(ByteString byteString) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).addCategoryDenylistBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public boolean hasMulticlassNms() {
                return ((ObjectDetectorOptions) this.instance).hasMulticlassNms();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public boolean getMulticlassNms() {
                return ((ObjectDetectorOptions) this.instance).getMulticlassNms();
            }

            public Builder setMulticlassNms(boolean z) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setMulticlassNms(z);
                return this;
            }

            public Builder clearMulticlassNms() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearMulticlassNms();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public boolean hasMinSuppressionThreshold() {
                return ((ObjectDetectorOptions) this.instance).hasMinSuppressionThreshold();
            }

            @Override // com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto.ObjectDetectorOptionsOrBuilder
            public float getMinSuppressionThreshold() {
                return ((ObjectDetectorOptions) this.instance).getMinSuppressionThreshold();
            }

            public Builder setMinSuppressionThreshold(float f) {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).setMinSuppressionThreshold(f);
                return this;
            }

            public Builder clearMinSuppressionThreshold() {
                copyOnWrite();
                ((ObjectDetectorOptions) this.instance).clearMinSuppressionThreshold();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ObjectDetectorOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\b\u0000\u0001\u0001\b\b\u0000\u0002\u0000\u0001ဉ\u0000\u0002ဈ\u0001\u0003င\u0002\u0004ခ\u0003\u0005\u001a\u0006\u001a\u0007ဇ\u0004\bခ\u0005", new Object[]{"bitField0_", "baseOptions_", "displayNamesLocale_", "maxResults_", "scoreThreshold_", "categoryAllowlist_", "categoryDenylist_", "multiclassNms_", "minSuppressionThreshold_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ObjectDetectorOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ObjectDetectorOptions.class) {
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
            ObjectDetectorOptions objectDetectorOptions = new ObjectDetectorOptions();
            DEFAULT_INSTANCE = objectDetectorOptions;
            GeneratedMessageLite.registerDefaultInstance(ObjectDetectorOptions.class, objectDetectorOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, ObjectDetectorOptions.class);
        }

        public static ObjectDetectorOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ObjectDetectorOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.objectdetector.proto.ObjectDetectorOptionsProto$1, reason: invalid class name */
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
