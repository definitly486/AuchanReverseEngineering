package com.google.mediapipe.tasks.components.containers.proto;

import com.google.mediapipe.formats.proto.ClassificationProto;
import com.google.mediapipe.formats.proto.LandmarkProto;
import com.google.mediapipe.formats.proto.RectProto;
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
public final class LandmarksDetectionResultProto {

    public interface LandmarksDetectionResultOrBuilder extends MessageLiteOrBuilder {
        ClassificationProto.ClassificationList getClassifications();

        LandmarkProto.NormalizedLandmarkList getLandmarks();

        RectProto.NormalizedRect getRect();

        LandmarkProto.LandmarkList getWorldLandmarks();

        boolean hasClassifications();

        boolean hasLandmarks();

        boolean hasRect();

        boolean hasWorldLandmarks();
    }

    public interface MultiLandmarksDetectionResultOrBuilder extends MessageLiteOrBuilder {
        ClassificationProto.ClassificationList getClassifications(int i);

        int getClassificationsCount();

        List<ClassificationProto.ClassificationList> getClassificationsList();

        LandmarkProto.NormalizedLandmarkList getLandmarks(int i);

        int getLandmarksCount();

        List<LandmarkProto.NormalizedLandmarkList> getLandmarksList();

        RectProto.NormalizedRect getRects(int i);

        int getRectsCount();

        List<RectProto.NormalizedRect> getRectsList();

        LandmarkProto.LandmarkList getWorldLandmarks(int i);

        int getWorldLandmarksCount();

        List<LandmarkProto.LandmarkList> getWorldLandmarksList();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private LandmarksDetectionResultProto() {
    }

    public static final class LandmarksDetectionResult extends GeneratedMessageLite<LandmarksDetectionResult, Builder> implements LandmarksDetectionResultOrBuilder {
        public static final int CLASSIFICATIONS_FIELD_NUMBER = 2;
        private static final LandmarksDetectionResult DEFAULT_INSTANCE;
        public static final int LANDMARKS_FIELD_NUMBER = 1;
        private static volatile Parser<LandmarksDetectionResult> PARSER = null;
        public static final int RECT_FIELD_NUMBER = 4;
        public static final int WORLD_LANDMARKS_FIELD_NUMBER = 3;
        private int bitField0_;
        private ClassificationProto.ClassificationList classifications_;
        private LandmarkProto.NormalizedLandmarkList landmarks_;
        private byte memoizedIsInitialized = 2;
        private RectProto.NormalizedRect rect_;
        private LandmarkProto.LandmarkList worldLandmarks_;

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

        private LandmarksDetectionResult() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public boolean hasLandmarks() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public LandmarkProto.NormalizedLandmarkList getLandmarks() {
            LandmarkProto.NormalizedLandmarkList normalizedLandmarkList = this.landmarks_;
            return normalizedLandmarkList == null ? LandmarkProto.NormalizedLandmarkList.getDefaultInstance() : normalizedLandmarkList;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLandmarks(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            this.landmarks_ = normalizedLandmarkList;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeLandmarks(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            LandmarkProto.NormalizedLandmarkList normalizedLandmarkList2 = this.landmarks_;
            if (normalizedLandmarkList2 != null && normalizedLandmarkList2 != LandmarkProto.NormalizedLandmarkList.getDefaultInstance()) {
                this.landmarks_ = LandmarkProto.NormalizedLandmarkList.newBuilder(this.landmarks_).mergeFrom(normalizedLandmarkList).buildPartial();
            } else {
                this.landmarks_ = normalizedLandmarkList;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLandmarks() {
            this.landmarks_ = null;
            this.bitField0_ &= -2;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public boolean hasClassifications() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public ClassificationProto.ClassificationList getClassifications() {
            ClassificationProto.ClassificationList classificationList = this.classifications_;
            return classificationList == null ? ClassificationProto.ClassificationList.getDefaultInstance() : classificationList;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClassifications(ClassificationProto.ClassificationList classificationList) {
            classificationList.getClass();
            this.classifications_ = classificationList;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeClassifications(ClassificationProto.ClassificationList classificationList) {
            classificationList.getClass();
            ClassificationProto.ClassificationList classificationList2 = this.classifications_;
            if (classificationList2 != null && classificationList2 != ClassificationProto.ClassificationList.getDefaultInstance()) {
                this.classifications_ = ClassificationProto.ClassificationList.newBuilder(this.classifications_).mergeFrom(classificationList).buildPartial();
            } else {
                this.classifications_ = classificationList;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearClassifications() {
            this.classifications_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public boolean hasWorldLandmarks() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public LandmarkProto.LandmarkList getWorldLandmarks() {
            LandmarkProto.LandmarkList landmarkList = this.worldLandmarks_;
            return landmarkList == null ? LandmarkProto.LandmarkList.getDefaultInstance() : landmarkList;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setWorldLandmarks(LandmarkProto.LandmarkList landmarkList) {
            landmarkList.getClass();
            this.worldLandmarks_ = landmarkList;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeWorldLandmarks(LandmarkProto.LandmarkList landmarkList) {
            landmarkList.getClass();
            LandmarkProto.LandmarkList landmarkList2 = this.worldLandmarks_;
            if (landmarkList2 != null && landmarkList2 != LandmarkProto.LandmarkList.getDefaultInstance()) {
                this.worldLandmarks_ = LandmarkProto.LandmarkList.newBuilder(this.worldLandmarks_).mergeFrom(landmarkList).buildPartial();
            } else {
                this.worldLandmarks_ = landmarkList;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearWorldLandmarks() {
            this.worldLandmarks_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public boolean hasRect() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
        public RectProto.NormalizedRect getRect() {
            RectProto.NormalizedRect normalizedRect = this.rect_;
            return normalizedRect == null ? RectProto.NormalizedRect.getDefaultInstance() : normalizedRect;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRect(RectProto.NormalizedRect normalizedRect) {
            normalizedRect.getClass();
            this.rect_ = normalizedRect;
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeRect(RectProto.NormalizedRect normalizedRect) {
            normalizedRect.getClass();
            RectProto.NormalizedRect normalizedRect2 = this.rect_;
            if (normalizedRect2 != null && normalizedRect2 != RectProto.NormalizedRect.getDefaultInstance()) {
                this.rect_ = RectProto.NormalizedRect.newBuilder(this.rect_).mergeFrom(normalizedRect).buildPartial();
            } else {
                this.rect_ = normalizedRect;
            }
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRect() {
            this.rect_ = null;
            this.bitField0_ &= -9;
        }

        public static LandmarksDetectionResult parseFrom(ByteBuffer byteBuffer) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static LandmarksDetectionResult parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static LandmarksDetectionResult parseFrom(ByteString byteString) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static LandmarksDetectionResult parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static LandmarksDetectionResult parseFrom(byte[] bArr) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static LandmarksDetectionResult parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static LandmarksDetectionResult parseFrom(InputStream inputStream) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LandmarksDetectionResult parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LandmarksDetectionResult parseDelimitedFrom(InputStream inputStream) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LandmarksDetectionResult parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LandmarksDetectionResult parseFrom(CodedInputStream codedInputStream) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static LandmarksDetectionResult parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(LandmarksDetectionResult landmarksDetectionResult) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(landmarksDetectionResult);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<LandmarksDetectionResult, Builder> implements LandmarksDetectionResultOrBuilder {
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
                super(LandmarksDetectionResult.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public boolean hasLandmarks() {
                return ((LandmarksDetectionResult) this.instance).hasLandmarks();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public LandmarkProto.NormalizedLandmarkList getLandmarks() {
                return ((LandmarksDetectionResult) this.instance).getLandmarks();
            }

            public Builder setLandmarks(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setLandmarks(normalizedLandmarkList);
                return this;
            }

            public Builder setLandmarks(LandmarkProto.NormalizedLandmarkList.Builder builder) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setLandmarks(builder.build());
                return this;
            }

            public Builder mergeLandmarks(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).mergeLandmarks(normalizedLandmarkList);
                return this;
            }

            public Builder clearLandmarks() {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).clearLandmarks();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public boolean hasClassifications() {
                return ((LandmarksDetectionResult) this.instance).hasClassifications();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public ClassificationProto.ClassificationList getClassifications() {
                return ((LandmarksDetectionResult) this.instance).getClassifications();
            }

            public Builder setClassifications(ClassificationProto.ClassificationList classificationList) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setClassifications(classificationList);
                return this;
            }

            public Builder setClassifications(ClassificationProto.ClassificationList.Builder builder) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setClassifications(builder.build());
                return this;
            }

            public Builder mergeClassifications(ClassificationProto.ClassificationList classificationList) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).mergeClassifications(classificationList);
                return this;
            }

            public Builder clearClassifications() {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).clearClassifications();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public boolean hasWorldLandmarks() {
                return ((LandmarksDetectionResult) this.instance).hasWorldLandmarks();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public LandmarkProto.LandmarkList getWorldLandmarks() {
                return ((LandmarksDetectionResult) this.instance).getWorldLandmarks();
            }

            public Builder setWorldLandmarks(LandmarkProto.LandmarkList landmarkList) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setWorldLandmarks(landmarkList);
                return this;
            }

            public Builder setWorldLandmarks(LandmarkProto.LandmarkList.Builder builder) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setWorldLandmarks(builder.build());
                return this;
            }

            public Builder mergeWorldLandmarks(LandmarkProto.LandmarkList landmarkList) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).mergeWorldLandmarks(landmarkList);
                return this;
            }

            public Builder clearWorldLandmarks() {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).clearWorldLandmarks();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public boolean hasRect() {
                return ((LandmarksDetectionResult) this.instance).hasRect();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.LandmarksDetectionResultOrBuilder
            public RectProto.NormalizedRect getRect() {
                return ((LandmarksDetectionResult) this.instance).getRect();
            }

            public Builder setRect(RectProto.NormalizedRect normalizedRect) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setRect(normalizedRect);
                return this;
            }

            public Builder setRect(RectProto.NormalizedRect.Builder builder) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).setRect(builder.build());
                return this;
            }

            public Builder mergeRect(RectProto.NormalizedRect normalizedRect) {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).mergeRect(normalizedRect);
                return this;
            }

            public Builder clearRect() {
                copyOnWrite();
                ((LandmarksDetectionResult) this.instance).clearRect();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new LandmarksDetectionResult();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0001\u0001ဉ\u0000\u0002ဉ\u0001\u0003ဉ\u0002\u0004ᐉ\u0003", new Object[]{"bitField0_", "landmarks_", "classifications_", "worldLandmarks_", "rect_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<LandmarksDetectionResult> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (LandmarksDetectionResult.class) {
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
            LandmarksDetectionResult landmarksDetectionResult = new LandmarksDetectionResult();
            DEFAULT_INSTANCE = landmarksDetectionResult;
            GeneratedMessageLite.registerDefaultInstance(LandmarksDetectionResult.class, landmarksDetectionResult);
        }

        public static LandmarksDetectionResult getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<LandmarksDetectionResult> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto$1, reason: invalid class name */
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

    public static final class MultiLandmarksDetectionResult extends GeneratedMessageLite<MultiLandmarksDetectionResult, Builder> implements MultiLandmarksDetectionResultOrBuilder {
        public static final int CLASSIFICATIONS_FIELD_NUMBER = 2;
        private static final MultiLandmarksDetectionResult DEFAULT_INSTANCE;
        public static final int LANDMARKS_FIELD_NUMBER = 1;
        private static volatile Parser<MultiLandmarksDetectionResult> PARSER = null;
        public static final int RECTS_FIELD_NUMBER = 4;
        public static final int WORLD_LANDMARKS_FIELD_NUMBER = 3;
        private byte memoizedIsInitialized = 2;
        private Internal.ProtobufList<LandmarkProto.NormalizedLandmarkList> landmarks_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<ClassificationProto.ClassificationList> classifications_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<LandmarkProto.LandmarkList> worldLandmarks_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<RectProto.NormalizedRect> rects_ = GeneratedMessageLite.emptyProtobufList();

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

        private MultiLandmarksDetectionResult() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public List<LandmarkProto.NormalizedLandmarkList> getLandmarksList() {
            return this.landmarks_;
        }

        public List<? extends LandmarkProto.NormalizedLandmarkListOrBuilder> getLandmarksOrBuilderList() {
            return this.landmarks_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public int getLandmarksCount() {
            return this.landmarks_.size();
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public LandmarkProto.NormalizedLandmarkList getLandmarks(int i) {
            return this.landmarks_.get(i);
        }

        public LandmarkProto.NormalizedLandmarkListOrBuilder getLandmarksOrBuilder(int i) {
            return this.landmarks_.get(i);
        }

        private void ensureLandmarksIsMutable() {
            Internal.ProtobufList<LandmarkProto.NormalizedLandmarkList> protobufList = this.landmarks_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.landmarks_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLandmarks(int i, LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            ensureLandmarksIsMutable();
            this.landmarks_.set(i, normalizedLandmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmarks(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            ensureLandmarksIsMutable();
            this.landmarks_.add(normalizedLandmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmarks(int i, LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            ensureLandmarksIsMutable();
            this.landmarks_.add(i, normalizedLandmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllLandmarks(Iterable<? extends LandmarkProto.NormalizedLandmarkList> iterable) {
            ensureLandmarksIsMutable();
            AbstractMessageLite.addAll(iterable, this.landmarks_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLandmarks() {
            this.landmarks_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeLandmarks(int i) {
            ensureLandmarksIsMutable();
            this.landmarks_.remove(i);
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public List<ClassificationProto.ClassificationList> getClassificationsList() {
            return this.classifications_;
        }

        public List<? extends ClassificationProto.ClassificationListOrBuilder> getClassificationsOrBuilderList() {
            return this.classifications_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public int getClassificationsCount() {
            return this.classifications_.size();
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public ClassificationProto.ClassificationList getClassifications(int i) {
            return this.classifications_.get(i);
        }

        public ClassificationProto.ClassificationListOrBuilder getClassificationsOrBuilder(int i) {
            return this.classifications_.get(i);
        }

        private void ensureClassificationsIsMutable() {
            Internal.ProtobufList<ClassificationProto.ClassificationList> protobufList = this.classifications_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.classifications_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClassifications(int i, ClassificationProto.ClassificationList classificationList) {
            classificationList.getClass();
            ensureClassificationsIsMutable();
            this.classifications_.set(i, classificationList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassifications(ClassificationProto.ClassificationList classificationList) {
            classificationList.getClass();
            ensureClassificationsIsMutable();
            this.classifications_.add(classificationList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addClassifications(int i, ClassificationProto.ClassificationList classificationList) {
            classificationList.getClass();
            ensureClassificationsIsMutable();
            this.classifications_.add(i, classificationList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllClassifications(Iterable<? extends ClassificationProto.ClassificationList> iterable) {
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

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public List<LandmarkProto.LandmarkList> getWorldLandmarksList() {
            return this.worldLandmarks_;
        }

        public List<? extends LandmarkProto.LandmarkListOrBuilder> getWorldLandmarksOrBuilderList() {
            return this.worldLandmarks_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public int getWorldLandmarksCount() {
            return this.worldLandmarks_.size();
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public LandmarkProto.LandmarkList getWorldLandmarks(int i) {
            return this.worldLandmarks_.get(i);
        }

        public LandmarkProto.LandmarkListOrBuilder getWorldLandmarksOrBuilder(int i) {
            return this.worldLandmarks_.get(i);
        }

        private void ensureWorldLandmarksIsMutable() {
            Internal.ProtobufList<LandmarkProto.LandmarkList> protobufList = this.worldLandmarks_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.worldLandmarks_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setWorldLandmarks(int i, LandmarkProto.LandmarkList landmarkList) {
            landmarkList.getClass();
            ensureWorldLandmarksIsMutable();
            this.worldLandmarks_.set(i, landmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addWorldLandmarks(LandmarkProto.LandmarkList landmarkList) {
            landmarkList.getClass();
            ensureWorldLandmarksIsMutable();
            this.worldLandmarks_.add(landmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addWorldLandmarks(int i, LandmarkProto.LandmarkList landmarkList) {
            landmarkList.getClass();
            ensureWorldLandmarksIsMutable();
            this.worldLandmarks_.add(i, landmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllWorldLandmarks(Iterable<? extends LandmarkProto.LandmarkList> iterable) {
            ensureWorldLandmarksIsMutable();
            AbstractMessageLite.addAll(iterable, this.worldLandmarks_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearWorldLandmarks() {
            this.worldLandmarks_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeWorldLandmarks(int i) {
            ensureWorldLandmarksIsMutable();
            this.worldLandmarks_.remove(i);
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public List<RectProto.NormalizedRect> getRectsList() {
            return this.rects_;
        }

        public List<? extends RectProto.NormalizedRectOrBuilder> getRectsOrBuilderList() {
            return this.rects_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public int getRectsCount() {
            return this.rects_.size();
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
        public RectProto.NormalizedRect getRects(int i) {
            return this.rects_.get(i);
        }

        public RectProto.NormalizedRectOrBuilder getRectsOrBuilder(int i) {
            return this.rects_.get(i);
        }

        private void ensureRectsIsMutable() {
            Internal.ProtobufList<RectProto.NormalizedRect> protobufList = this.rects_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.rects_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRects(int i, RectProto.NormalizedRect normalizedRect) {
            normalizedRect.getClass();
            ensureRectsIsMutable();
            this.rects_.set(i, normalizedRect);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addRects(RectProto.NormalizedRect normalizedRect) {
            normalizedRect.getClass();
            ensureRectsIsMutable();
            this.rects_.add(normalizedRect);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addRects(int i, RectProto.NormalizedRect normalizedRect) {
            normalizedRect.getClass();
            ensureRectsIsMutable();
            this.rects_.add(i, normalizedRect);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllRects(Iterable<? extends RectProto.NormalizedRect> iterable) {
            ensureRectsIsMutable();
            AbstractMessageLite.addAll(iterable, this.rects_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRects() {
            this.rects_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeRects(int i) {
            ensureRectsIsMutable();
            this.rects_.remove(i);
        }

        public static MultiLandmarksDetectionResult parseFrom(ByteBuffer byteBuffer) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static MultiLandmarksDetectionResult parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static MultiLandmarksDetectionResult parseFrom(ByteString byteString) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static MultiLandmarksDetectionResult parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static MultiLandmarksDetectionResult parseFrom(byte[] bArr) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static MultiLandmarksDetectionResult parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static MultiLandmarksDetectionResult parseFrom(InputStream inputStream) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static MultiLandmarksDetectionResult parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static MultiLandmarksDetectionResult parseDelimitedFrom(InputStream inputStream) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static MultiLandmarksDetectionResult parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static MultiLandmarksDetectionResult parseFrom(CodedInputStream codedInputStream) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static MultiLandmarksDetectionResult parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (MultiLandmarksDetectionResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(MultiLandmarksDetectionResult multiLandmarksDetectionResult) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(multiLandmarksDetectionResult);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<MultiLandmarksDetectionResult, Builder> implements MultiLandmarksDetectionResultOrBuilder {
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
                super(MultiLandmarksDetectionResult.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public List<LandmarkProto.NormalizedLandmarkList> getLandmarksList() {
                return Collections.unmodifiableList(((MultiLandmarksDetectionResult) this.instance).getLandmarksList());
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public int getLandmarksCount() {
                return ((MultiLandmarksDetectionResult) this.instance).getLandmarksCount();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public LandmarkProto.NormalizedLandmarkList getLandmarks(int i) {
                return ((MultiLandmarksDetectionResult) this.instance).getLandmarks(i);
            }

            public Builder setLandmarks(int i, LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setLandmarks(i, normalizedLandmarkList);
                return this;
            }

            public Builder setLandmarks(int i, LandmarkProto.NormalizedLandmarkList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setLandmarks(i, builder.build());
                return this;
            }

            public Builder addLandmarks(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addLandmarks(normalizedLandmarkList);
                return this;
            }

            public Builder addLandmarks(int i, LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addLandmarks(i, normalizedLandmarkList);
                return this;
            }

            public Builder addLandmarks(LandmarkProto.NormalizedLandmarkList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addLandmarks(builder.build());
                return this;
            }

            public Builder addLandmarks(int i, LandmarkProto.NormalizedLandmarkList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addLandmarks(i, builder.build());
                return this;
            }

            public Builder addAllLandmarks(Iterable<? extends LandmarkProto.NormalizedLandmarkList> iterable) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addAllLandmarks(iterable);
                return this;
            }

            public Builder clearLandmarks() {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).clearLandmarks();
                return this;
            }

            public Builder removeLandmarks(int i) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).removeLandmarks(i);
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public List<ClassificationProto.ClassificationList> getClassificationsList() {
                return Collections.unmodifiableList(((MultiLandmarksDetectionResult) this.instance).getClassificationsList());
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public int getClassificationsCount() {
                return ((MultiLandmarksDetectionResult) this.instance).getClassificationsCount();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public ClassificationProto.ClassificationList getClassifications(int i) {
                return ((MultiLandmarksDetectionResult) this.instance).getClassifications(i);
            }

            public Builder setClassifications(int i, ClassificationProto.ClassificationList classificationList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setClassifications(i, classificationList);
                return this;
            }

            public Builder setClassifications(int i, ClassificationProto.ClassificationList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setClassifications(i, builder.build());
                return this;
            }

            public Builder addClassifications(ClassificationProto.ClassificationList classificationList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addClassifications(classificationList);
                return this;
            }

            public Builder addClassifications(int i, ClassificationProto.ClassificationList classificationList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addClassifications(i, classificationList);
                return this;
            }

            public Builder addClassifications(ClassificationProto.ClassificationList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addClassifications(builder.build());
                return this;
            }

            public Builder addClassifications(int i, ClassificationProto.ClassificationList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addClassifications(i, builder.build());
                return this;
            }

            public Builder addAllClassifications(Iterable<? extends ClassificationProto.ClassificationList> iterable) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addAllClassifications(iterable);
                return this;
            }

            public Builder clearClassifications() {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).clearClassifications();
                return this;
            }

            public Builder removeClassifications(int i) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).removeClassifications(i);
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public List<LandmarkProto.LandmarkList> getWorldLandmarksList() {
                return Collections.unmodifiableList(((MultiLandmarksDetectionResult) this.instance).getWorldLandmarksList());
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public int getWorldLandmarksCount() {
                return ((MultiLandmarksDetectionResult) this.instance).getWorldLandmarksCount();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public LandmarkProto.LandmarkList getWorldLandmarks(int i) {
                return ((MultiLandmarksDetectionResult) this.instance).getWorldLandmarks(i);
            }

            public Builder setWorldLandmarks(int i, LandmarkProto.LandmarkList landmarkList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setWorldLandmarks(i, landmarkList);
                return this;
            }

            public Builder setWorldLandmarks(int i, LandmarkProto.LandmarkList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setWorldLandmarks(i, builder.build());
                return this;
            }

            public Builder addWorldLandmarks(LandmarkProto.LandmarkList landmarkList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addWorldLandmarks(landmarkList);
                return this;
            }

            public Builder addWorldLandmarks(int i, LandmarkProto.LandmarkList landmarkList) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addWorldLandmarks(i, landmarkList);
                return this;
            }

            public Builder addWorldLandmarks(LandmarkProto.LandmarkList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addWorldLandmarks(builder.build());
                return this;
            }

            public Builder addWorldLandmarks(int i, LandmarkProto.LandmarkList.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addWorldLandmarks(i, builder.build());
                return this;
            }

            public Builder addAllWorldLandmarks(Iterable<? extends LandmarkProto.LandmarkList> iterable) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addAllWorldLandmarks(iterable);
                return this;
            }

            public Builder clearWorldLandmarks() {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).clearWorldLandmarks();
                return this;
            }

            public Builder removeWorldLandmarks(int i) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).removeWorldLandmarks(i);
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public List<RectProto.NormalizedRect> getRectsList() {
                return Collections.unmodifiableList(((MultiLandmarksDetectionResult) this.instance).getRectsList());
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public int getRectsCount() {
                return ((MultiLandmarksDetectionResult) this.instance).getRectsCount();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.LandmarksDetectionResultProto.MultiLandmarksDetectionResultOrBuilder
            public RectProto.NormalizedRect getRects(int i) {
                return ((MultiLandmarksDetectionResult) this.instance).getRects(i);
            }

            public Builder setRects(int i, RectProto.NormalizedRect normalizedRect) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setRects(i, normalizedRect);
                return this;
            }

            public Builder setRects(int i, RectProto.NormalizedRect.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).setRects(i, builder.build());
                return this;
            }

            public Builder addRects(RectProto.NormalizedRect normalizedRect) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addRects(normalizedRect);
                return this;
            }

            public Builder addRects(int i, RectProto.NormalizedRect normalizedRect) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addRects(i, normalizedRect);
                return this;
            }

            public Builder addRects(RectProto.NormalizedRect.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addRects(builder.build());
                return this;
            }

            public Builder addRects(int i, RectProto.NormalizedRect.Builder builder) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addRects(i, builder.build());
                return this;
            }

            public Builder addAllRects(Iterable<? extends RectProto.NormalizedRect> iterable) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).addAllRects(iterable);
                return this;
            }

            public Builder clearRects() {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).clearRects();
                return this;
            }

            public Builder removeRects(int i) {
                copyOnWrite();
                ((MultiLandmarksDetectionResult) this.instance).removeRects(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new MultiLandmarksDetectionResult();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0000\u0001\u0004\u0004\u0000\u0004\u0001\u0001\u001b\u0002\u001b\u0003\u001b\u0004Л", new Object[]{"landmarks_", LandmarkProto.NormalizedLandmarkList.class, "classifications_", ClassificationProto.ClassificationList.class, "worldLandmarks_", LandmarkProto.LandmarkList.class, "rects_", RectProto.NormalizedRect.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<MultiLandmarksDetectionResult> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (MultiLandmarksDetectionResult.class) {
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
            MultiLandmarksDetectionResult multiLandmarksDetectionResult = new MultiLandmarksDetectionResult();
            DEFAULT_INSTANCE = multiLandmarksDetectionResult;
            GeneratedMessageLite.registerDefaultInstance(MultiLandmarksDetectionResult.class, multiLandmarksDetectionResult);
        }

        public static MultiLandmarksDetectionResult getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<MultiLandmarksDetectionResult> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
