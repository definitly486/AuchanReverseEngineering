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
public final class DetectionProto {

    public interface DetectionListOrBuilder extends MessageLiteOrBuilder {
        Detection getDetection(int i);

        int getDetectionCount();

        List<Detection> getDetectionList();
    }

    public interface DetectionOrBuilder extends MessageLiteOrBuilder {
        Detection.AssociatedDetection getAssociatedDetections(int i);

        int getAssociatedDetectionsCount();

        List<Detection.AssociatedDetection> getAssociatedDetectionsList();

        long getDetectionId();

        String getDisplayName(int i);

        ByteString getDisplayNameBytes(int i);

        int getDisplayNameCount();

        List<String> getDisplayNameList();

        String getFeatureTag();

        ByteString getFeatureTagBytes();

        String getLabel(int i);

        ByteString getLabelBytes(int i);

        int getLabelCount();

        int getLabelId(int i);

        int getLabelIdCount();

        List<Integer> getLabelIdList();

        List<String> getLabelList();

        LocationDataProto.LocationData getLocationData();

        float getScore(int i);

        int getScoreCount();

        List<Float> getScoreList();

        long getTimestampUsec();

        String getTrackId();

        ByteString getTrackIdBytes();

        boolean hasDetectionId();

        boolean hasFeatureTag();

        boolean hasLocationData();

        boolean hasTimestampUsec();

        boolean hasTrackId();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private DetectionProto() {
    }

    public static final class Detection extends GeneratedMessageLite<Detection, Builder> implements DetectionOrBuilder {
        public static final int ASSOCIATED_DETECTIONS_FIELD_NUMBER = 8;
        private static final Detection DEFAULT_INSTANCE;
        public static final int DETECTION_ID_FIELD_NUMBER = 7;
        public static final int DISPLAY_NAME_FIELD_NUMBER = 9;
        public static final int FEATURE_TAG_FIELD_NUMBER = 5;
        public static final int LABEL_FIELD_NUMBER = 1;
        public static final int LABEL_ID_FIELD_NUMBER = 2;
        public static final int LOCATION_DATA_FIELD_NUMBER = 4;
        private static volatile Parser<Detection> PARSER = null;
        public static final int SCORE_FIELD_NUMBER = 3;
        public static final int TIMESTAMP_USEC_FIELD_NUMBER = 10;
        public static final int TRACK_ID_FIELD_NUMBER = 6;
        private int bitField0_;
        private long detectionId_;
        private LocationDataProto.LocationData locationData_;
        private long timestampUsec_;
        private int labelIdMemoizedSerializedSize = -1;
        private int scoreMemoizedSerializedSize = -1;
        private byte memoizedIsInitialized = 2;
        private Internal.ProtobufList<String> label_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.IntList labelId_ = GeneratedMessageLite.emptyIntList();
        private Internal.FloatList score_ = GeneratedMessageLite.emptyFloatList();
        private String featureTag_ = "";
        private String trackId_ = "";
        private Internal.ProtobufList<AssociatedDetection> associatedDetections_ = GeneratedMessageLite.emptyProtobufList();
        private Internal.ProtobufList<String> displayName_ = GeneratedMessageLite.emptyProtobufList();

        public interface AssociatedDetectionOrBuilder extends MessageLiteOrBuilder {
            float getConfidence();

            int getId();

            boolean hasConfidence();

            boolean hasId();
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

        private Detection() {
        }

        public static final class AssociatedDetection extends GeneratedMessageLite<AssociatedDetection, Builder> implements AssociatedDetectionOrBuilder {
            public static final int CONFIDENCE_FIELD_NUMBER = 2;
            private static final AssociatedDetection DEFAULT_INSTANCE;
            public static final int ID_FIELD_NUMBER = 1;
            private static volatile Parser<AssociatedDetection> PARSER;
            private int bitField0_;
            private float confidence_;
            private int id_;

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

            private AssociatedDetection() {
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
            public boolean hasId() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
            public int getId() {
                return this.id_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setId(int i) {
                this.bitField0_ |= 1;
                this.id_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearId() {
                this.bitField0_ &= -2;
                this.id_ = 0;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
            public boolean hasConfidence() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
            public float getConfidence() {
                return this.confidence_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setConfidence(float f) {
                this.bitField0_ |= 2;
                this.confidence_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearConfidence() {
                this.bitField0_ &= -3;
                this.confidence_ = 0.0f;
            }

            public static AssociatedDetection parseFrom(ByteBuffer byteBuffer) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static AssociatedDetection parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static AssociatedDetection parseFrom(ByteString byteString) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static AssociatedDetection parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static AssociatedDetection parseFrom(byte[] bArr) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static AssociatedDetection parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static AssociatedDetection parseFrom(InputStream inputStream) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static AssociatedDetection parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static AssociatedDetection parseDelimitedFrom(InputStream inputStream) {
                return (AssociatedDetection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static AssociatedDetection parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (AssociatedDetection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static AssociatedDetection parseFrom(CodedInputStream codedInputStream) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static AssociatedDetection parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (AssociatedDetection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(AssociatedDetection associatedDetection) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(associatedDetection);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<AssociatedDetection, Builder> implements AssociatedDetectionOrBuilder {
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
                    super(AssociatedDetection.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
                public boolean hasId() {
                    return ((AssociatedDetection) this.instance).hasId();
                }

                @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
                public int getId() {
                    return ((AssociatedDetection) this.instance).getId();
                }

                public Builder setId(int i) {
                    copyOnWrite();
                    ((AssociatedDetection) this.instance).setId(i);
                    return this;
                }

                public Builder clearId() {
                    copyOnWrite();
                    ((AssociatedDetection) this.instance).clearId();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
                public boolean hasConfidence() {
                    return ((AssociatedDetection) this.instance).hasConfidence();
                }

                @Override // com.google.mediapipe.formats.proto.DetectionProto.Detection.AssociatedDetectionOrBuilder
                public float getConfidence() {
                    return ((AssociatedDetection) this.instance).getConfidence();
                }

                public Builder setConfidence(float f) {
                    copyOnWrite();
                    ((AssociatedDetection) this.instance).setConfidence(f);
                    return this;
                }

                public Builder clearConfidence() {
                    copyOnWrite();
                    ((AssociatedDetection) this.instance).clearConfidence();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new AssociatedDetection();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001င\u0000\u0002ခ\u0001", new Object[]{"bitField0_", "id_", "confidence_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<AssociatedDetection> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (AssociatedDetection.class) {
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
                AssociatedDetection associatedDetection = new AssociatedDetection();
                DEFAULT_INSTANCE = associatedDetection;
                GeneratedMessageLite.registerDefaultInstance(AssociatedDetection.class, associatedDetection);
            }

            public static AssociatedDetection getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<AssociatedDetection> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public List<String> getLabelList() {
            return this.label_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public int getLabelCount() {
            return this.label_.size();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public String getLabel(int i) {
            return this.label_.get(i);
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public ByteString getLabelBytes(int i) {
            return ByteString.copyFromUtf8(this.label_.get(i));
        }

        private void ensureLabelIsMutable() {
            Internal.ProtobufList<String> protobufList = this.label_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.label_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLabel(int i, String str) {
            str.getClass();
            ensureLabelIsMutable();
            this.label_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLabel(String str) {
            str.getClass();
            ensureLabelIsMutable();
            this.label_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllLabel(Iterable<String> iterable) {
            ensureLabelIsMutable();
            AbstractMessageLite.addAll(iterable, this.label_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLabel() {
            this.label_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLabelBytes(ByteString byteString) {
            ensureLabelIsMutable();
            this.label_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public List<Integer> getLabelIdList() {
            return this.labelId_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public int getLabelIdCount() {
            return this.labelId_.size();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public int getLabelId(int i) {
            return this.labelId_.getInt(i);
        }

        private void ensureLabelIdIsMutable() {
            Internal.IntList intList = this.labelId_;
            if (intList.isModifiable()) {
                return;
            }
            this.labelId_ = GeneratedMessageLite.mutableCopy(intList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLabelId(int i, int i2) {
            ensureLabelIdIsMutable();
            this.labelId_.setInt(i, i2);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLabelId(int i) {
            ensureLabelIdIsMutable();
            this.labelId_.addInt(i);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllLabelId(Iterable<? extends Integer> iterable) {
            ensureLabelIdIsMutable();
            AbstractMessageLite.addAll(iterable, this.labelId_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLabelId() {
            this.labelId_ = GeneratedMessageLite.emptyIntList();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public List<Float> getScoreList() {
            return this.score_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public int getScoreCount() {
            return this.score_.size();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public float getScore(int i) {
            return this.score_.getFloat(i);
        }

        private void ensureScoreIsMutable() {
            Internal.FloatList floatList = this.score_;
            if (floatList.isModifiable()) {
                return;
            }
            this.score_ = GeneratedMessageLite.mutableCopy(floatList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setScore(int i, float f) {
            ensureScoreIsMutable();
            this.score_.setFloat(i, f);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addScore(float f) {
            ensureScoreIsMutable();
            this.score_.addFloat(f);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllScore(Iterable<? extends Float> iterable) {
            ensureScoreIsMutable();
            AbstractMessageLite.addAll(iterable, this.score_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearScore() {
            this.score_ = GeneratedMessageLite.emptyFloatList();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public boolean hasLocationData() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public LocationDataProto.LocationData getLocationData() {
            LocationDataProto.LocationData locationData = this.locationData_;
            return locationData == null ? LocationDataProto.LocationData.getDefaultInstance() : locationData;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLocationData(LocationDataProto.LocationData locationData) {
            locationData.getClass();
            this.locationData_ = locationData;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeLocationData(LocationDataProto.LocationData locationData) {
            locationData.getClass();
            LocationDataProto.LocationData locationData2 = this.locationData_;
            if (locationData2 != null && locationData2 != LocationDataProto.LocationData.getDefaultInstance()) {
                this.locationData_ = LocationDataProto.LocationData.newBuilder(this.locationData_).mergeFrom(locationData).buildPartial();
            } else {
                this.locationData_ = locationData;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLocationData() {
            this.locationData_ = null;
            this.bitField0_ &= -2;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public boolean hasFeatureTag() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public String getFeatureTag() {
            return this.featureTag_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public ByteString getFeatureTagBytes() {
            return ByteString.copyFromUtf8(this.featureTag_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFeatureTag(String str) {
            str.getClass();
            this.bitField0_ |= 2;
            this.featureTag_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFeatureTag() {
            this.bitField0_ &= -3;
            this.featureTag_ = getDefaultInstance().getFeatureTag();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFeatureTagBytes(ByteString byteString) {
            this.featureTag_ = byteString.toStringUtf8();
            this.bitField0_ |= 2;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public boolean hasTrackId() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public String getTrackId() {
            return this.trackId_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public ByteString getTrackIdBytes() {
            return ByteString.copyFromUtf8(this.trackId_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTrackId(String str) {
            str.getClass();
            this.bitField0_ |= 4;
            this.trackId_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTrackId() {
            this.bitField0_ &= -5;
            this.trackId_ = getDefaultInstance().getTrackId();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTrackIdBytes(ByteString byteString) {
            this.trackId_ = byteString.toStringUtf8();
            this.bitField0_ |= 4;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public boolean hasDetectionId() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public long getDetectionId() {
            return this.detectionId_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDetectionId(long j) {
            this.bitField0_ |= 8;
            this.detectionId_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDetectionId() {
            this.bitField0_ &= -9;
            this.detectionId_ = 0L;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public List<AssociatedDetection> getAssociatedDetectionsList() {
            return this.associatedDetections_;
        }

        public List<? extends AssociatedDetectionOrBuilder> getAssociatedDetectionsOrBuilderList() {
            return this.associatedDetections_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public int getAssociatedDetectionsCount() {
            return this.associatedDetections_.size();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public AssociatedDetection getAssociatedDetections(int i) {
            return this.associatedDetections_.get(i);
        }

        public AssociatedDetectionOrBuilder getAssociatedDetectionsOrBuilder(int i) {
            return this.associatedDetections_.get(i);
        }

        private void ensureAssociatedDetectionsIsMutable() {
            Internal.ProtobufList<AssociatedDetection> protobufList = this.associatedDetections_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.associatedDetections_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setAssociatedDetections(int i, AssociatedDetection associatedDetection) {
            associatedDetection.getClass();
            ensureAssociatedDetectionsIsMutable();
            this.associatedDetections_.set(i, associatedDetection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAssociatedDetections(AssociatedDetection associatedDetection) {
            associatedDetection.getClass();
            ensureAssociatedDetectionsIsMutable();
            this.associatedDetections_.add(associatedDetection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAssociatedDetections(int i, AssociatedDetection associatedDetection) {
            associatedDetection.getClass();
            ensureAssociatedDetectionsIsMutable();
            this.associatedDetections_.add(i, associatedDetection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllAssociatedDetections(Iterable<? extends AssociatedDetection> iterable) {
            ensureAssociatedDetectionsIsMutable();
            AbstractMessageLite.addAll(iterable, this.associatedDetections_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearAssociatedDetections() {
            this.associatedDetections_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeAssociatedDetections(int i) {
            ensureAssociatedDetectionsIsMutable();
            this.associatedDetections_.remove(i);
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public List<String> getDisplayNameList() {
            return this.displayName_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public int getDisplayNameCount() {
            return this.displayName_.size();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public String getDisplayName(int i) {
            return this.displayName_.get(i);
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public ByteString getDisplayNameBytes(int i) {
            return ByteString.copyFromUtf8(this.displayName_.get(i));
        }

        private void ensureDisplayNameIsMutable() {
            Internal.ProtobufList<String> protobufList = this.displayName_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.displayName_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayName(int i, String str) {
            str.getClass();
            ensureDisplayNameIsMutable();
            this.displayName_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addDisplayName(String str) {
            str.getClass();
            ensureDisplayNameIsMutable();
            this.displayName_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllDisplayName(Iterable<String> iterable) {
            ensureDisplayNameIsMutable();
            AbstractMessageLite.addAll(iterable, this.displayName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDisplayName() {
            this.displayName_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addDisplayNameBytes(ByteString byteString) {
            ensureDisplayNameIsMutable();
            this.displayName_.add(byteString.toStringUtf8());
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public boolean hasTimestampUsec() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
        public long getTimestampUsec() {
            return this.timestampUsec_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTimestampUsec(long j) {
            this.bitField0_ |= 16;
            this.timestampUsec_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTimestampUsec() {
            this.bitField0_ &= -17;
            this.timestampUsec_ = 0L;
        }

        public static Detection parseFrom(ByteBuffer byteBuffer) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Detection parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Detection parseFrom(ByteString byteString) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Detection parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Detection parseFrom(byte[] bArr) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Detection parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Detection parseFrom(InputStream inputStream) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Detection parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Detection parseDelimitedFrom(InputStream inputStream) {
            return (Detection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Detection parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Detection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Detection parseFrom(CodedInputStream codedInputStream) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Detection parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Detection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Detection detection) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(detection);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Detection, Builder> implements DetectionOrBuilder {
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
                super(Detection.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public List<String> getLabelList() {
                return Collections.unmodifiableList(((Detection) this.instance).getLabelList());
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public int getLabelCount() {
                return ((Detection) this.instance).getLabelCount();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public String getLabel(int i) {
                return ((Detection) this.instance).getLabel(i);
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public ByteString getLabelBytes(int i) {
                return ((Detection) this.instance).getLabelBytes(i);
            }

            public Builder setLabel(int i, String str) {
                copyOnWrite();
                ((Detection) this.instance).setLabel(i, str);
                return this;
            }

            public Builder addLabel(String str) {
                copyOnWrite();
                ((Detection) this.instance).addLabel(str);
                return this;
            }

            public Builder addAllLabel(Iterable<String> iterable) {
                copyOnWrite();
                ((Detection) this.instance).addAllLabel(iterable);
                return this;
            }

            public Builder clearLabel() {
                copyOnWrite();
                ((Detection) this.instance).clearLabel();
                return this;
            }

            public Builder addLabelBytes(ByteString byteString) {
                copyOnWrite();
                ((Detection) this.instance).addLabelBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public List<Integer> getLabelIdList() {
                return Collections.unmodifiableList(((Detection) this.instance).getLabelIdList());
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public int getLabelIdCount() {
                return ((Detection) this.instance).getLabelIdCount();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public int getLabelId(int i) {
                return ((Detection) this.instance).getLabelId(i);
            }

            public Builder setLabelId(int i, int i2) {
                copyOnWrite();
                ((Detection) this.instance).setLabelId(i, i2);
                return this;
            }

            public Builder addLabelId(int i) {
                copyOnWrite();
                ((Detection) this.instance).addLabelId(i);
                return this;
            }

            public Builder addAllLabelId(Iterable<? extends Integer> iterable) {
                copyOnWrite();
                ((Detection) this.instance).addAllLabelId(iterable);
                return this;
            }

            public Builder clearLabelId() {
                copyOnWrite();
                ((Detection) this.instance).clearLabelId();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public List<Float> getScoreList() {
                return Collections.unmodifiableList(((Detection) this.instance).getScoreList());
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public int getScoreCount() {
                return ((Detection) this.instance).getScoreCount();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public float getScore(int i) {
                return ((Detection) this.instance).getScore(i);
            }

            public Builder setScore(int i, float f) {
                copyOnWrite();
                ((Detection) this.instance).setScore(i, f);
                return this;
            }

            public Builder addScore(float f) {
                copyOnWrite();
                ((Detection) this.instance).addScore(f);
                return this;
            }

            public Builder addAllScore(Iterable<? extends Float> iterable) {
                copyOnWrite();
                ((Detection) this.instance).addAllScore(iterable);
                return this;
            }

            public Builder clearScore() {
                copyOnWrite();
                ((Detection) this.instance).clearScore();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public boolean hasLocationData() {
                return ((Detection) this.instance).hasLocationData();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public LocationDataProto.LocationData getLocationData() {
                return ((Detection) this.instance).getLocationData();
            }

            public Builder setLocationData(LocationDataProto.LocationData locationData) {
                copyOnWrite();
                ((Detection) this.instance).setLocationData(locationData);
                return this;
            }

            public Builder setLocationData(LocationDataProto.LocationData.Builder builder) {
                copyOnWrite();
                ((Detection) this.instance).setLocationData(builder.build());
                return this;
            }

            public Builder mergeLocationData(LocationDataProto.LocationData locationData) {
                copyOnWrite();
                ((Detection) this.instance).mergeLocationData(locationData);
                return this;
            }

            public Builder clearLocationData() {
                copyOnWrite();
                ((Detection) this.instance).clearLocationData();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public boolean hasFeatureTag() {
                return ((Detection) this.instance).hasFeatureTag();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public String getFeatureTag() {
                return ((Detection) this.instance).getFeatureTag();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public ByteString getFeatureTagBytes() {
                return ((Detection) this.instance).getFeatureTagBytes();
            }

            public Builder setFeatureTag(String str) {
                copyOnWrite();
                ((Detection) this.instance).setFeatureTag(str);
                return this;
            }

            public Builder clearFeatureTag() {
                copyOnWrite();
                ((Detection) this.instance).clearFeatureTag();
                return this;
            }

            public Builder setFeatureTagBytes(ByteString byteString) {
                copyOnWrite();
                ((Detection) this.instance).setFeatureTagBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public boolean hasTrackId() {
                return ((Detection) this.instance).hasTrackId();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public String getTrackId() {
                return ((Detection) this.instance).getTrackId();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public ByteString getTrackIdBytes() {
                return ((Detection) this.instance).getTrackIdBytes();
            }

            public Builder setTrackId(String str) {
                copyOnWrite();
                ((Detection) this.instance).setTrackId(str);
                return this;
            }

            public Builder clearTrackId() {
                copyOnWrite();
                ((Detection) this.instance).clearTrackId();
                return this;
            }

            public Builder setTrackIdBytes(ByteString byteString) {
                copyOnWrite();
                ((Detection) this.instance).setTrackIdBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public boolean hasDetectionId() {
                return ((Detection) this.instance).hasDetectionId();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public long getDetectionId() {
                return ((Detection) this.instance).getDetectionId();
            }

            public Builder setDetectionId(long j) {
                copyOnWrite();
                ((Detection) this.instance).setDetectionId(j);
                return this;
            }

            public Builder clearDetectionId() {
                copyOnWrite();
                ((Detection) this.instance).clearDetectionId();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public List<AssociatedDetection> getAssociatedDetectionsList() {
                return Collections.unmodifiableList(((Detection) this.instance).getAssociatedDetectionsList());
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public int getAssociatedDetectionsCount() {
                return ((Detection) this.instance).getAssociatedDetectionsCount();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public AssociatedDetection getAssociatedDetections(int i) {
                return ((Detection) this.instance).getAssociatedDetections(i);
            }

            public Builder setAssociatedDetections(int i, AssociatedDetection associatedDetection) {
                copyOnWrite();
                ((Detection) this.instance).setAssociatedDetections(i, associatedDetection);
                return this;
            }

            public Builder setAssociatedDetections(int i, AssociatedDetection.Builder builder) {
                copyOnWrite();
                ((Detection) this.instance).setAssociatedDetections(i, builder.build());
                return this;
            }

            public Builder addAssociatedDetections(AssociatedDetection associatedDetection) {
                copyOnWrite();
                ((Detection) this.instance).addAssociatedDetections(associatedDetection);
                return this;
            }

            public Builder addAssociatedDetections(int i, AssociatedDetection associatedDetection) {
                copyOnWrite();
                ((Detection) this.instance).addAssociatedDetections(i, associatedDetection);
                return this;
            }

            public Builder addAssociatedDetections(AssociatedDetection.Builder builder) {
                copyOnWrite();
                ((Detection) this.instance).addAssociatedDetections(builder.build());
                return this;
            }

            public Builder addAssociatedDetections(int i, AssociatedDetection.Builder builder) {
                copyOnWrite();
                ((Detection) this.instance).addAssociatedDetections(i, builder.build());
                return this;
            }

            public Builder addAllAssociatedDetections(Iterable<? extends AssociatedDetection> iterable) {
                copyOnWrite();
                ((Detection) this.instance).addAllAssociatedDetections(iterable);
                return this;
            }

            public Builder clearAssociatedDetections() {
                copyOnWrite();
                ((Detection) this.instance).clearAssociatedDetections();
                return this;
            }

            public Builder removeAssociatedDetections(int i) {
                copyOnWrite();
                ((Detection) this.instance).removeAssociatedDetections(i);
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public List<String> getDisplayNameList() {
                return Collections.unmodifiableList(((Detection) this.instance).getDisplayNameList());
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public int getDisplayNameCount() {
                return ((Detection) this.instance).getDisplayNameCount();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public String getDisplayName(int i) {
                return ((Detection) this.instance).getDisplayName(i);
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public ByteString getDisplayNameBytes(int i) {
                return ((Detection) this.instance).getDisplayNameBytes(i);
            }

            public Builder setDisplayName(int i, String str) {
                copyOnWrite();
                ((Detection) this.instance).setDisplayName(i, str);
                return this;
            }

            public Builder addDisplayName(String str) {
                copyOnWrite();
                ((Detection) this.instance).addDisplayName(str);
                return this;
            }

            public Builder addAllDisplayName(Iterable<String> iterable) {
                copyOnWrite();
                ((Detection) this.instance).addAllDisplayName(iterable);
                return this;
            }

            public Builder clearDisplayName() {
                copyOnWrite();
                ((Detection) this.instance).clearDisplayName();
                return this;
            }

            public Builder addDisplayNameBytes(ByteString byteString) {
                copyOnWrite();
                ((Detection) this.instance).addDisplayNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public boolean hasTimestampUsec() {
                return ((Detection) this.instance).hasTimestampUsec();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionOrBuilder
            public long getTimestampUsec() {
                return ((Detection) this.instance).getTimestampUsec();
            }

            public Builder setTimestampUsec(long j) {
                copyOnWrite();
                ((Detection) this.instance).setTimestampUsec(j);
                return this;
            }

            public Builder clearTimestampUsec() {
                copyOnWrite();
                ((Detection) this.instance).clearTimestampUsec();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Detection();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\n\u0000\u0001\u0001\n\n\u0000\u0005\u0001\u0001\u001a\u0002'\u0003$\u0004ᐉ\u0000\u0005ဈ\u0001\u0006ဈ\u0002\u0007ဂ\u0003\b\u001b\t\u001a\nဂ\u0004", new Object[]{"bitField0_", "label_", "labelId_", "score_", "locationData_", "featureTag_", "trackId_", "detectionId_", "associatedDetections_", AssociatedDetection.class, "displayName_", "timestampUsec_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Detection> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Detection.class) {
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
            Detection detection = new Detection();
            DEFAULT_INSTANCE = detection;
            GeneratedMessageLite.registerDefaultInstance(Detection.class, detection);
        }

        public static Detection getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Detection> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.formats.proto.DetectionProto$1, reason: invalid class name */
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

    public static final class DetectionList extends GeneratedMessageLite<DetectionList, Builder> implements DetectionListOrBuilder {
        private static final DetectionList DEFAULT_INSTANCE;
        public static final int DETECTION_FIELD_NUMBER = 1;
        private static volatile Parser<DetectionList> PARSER;
        private byte memoizedIsInitialized = 2;
        private Internal.ProtobufList<Detection> detection_ = GeneratedMessageLite.emptyProtobufList();

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

        private DetectionList() {
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionListOrBuilder
        public List<Detection> getDetectionList() {
            return this.detection_;
        }

        public List<? extends DetectionOrBuilder> getDetectionOrBuilderList() {
            return this.detection_;
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionListOrBuilder
        public int getDetectionCount() {
            return this.detection_.size();
        }

        @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionListOrBuilder
        public Detection getDetection(int i) {
            return this.detection_.get(i);
        }

        public DetectionOrBuilder getDetectionOrBuilder(int i) {
            return this.detection_.get(i);
        }

        private void ensureDetectionIsMutable() {
            Internal.ProtobufList<Detection> protobufList = this.detection_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.detection_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDetection(int i, Detection detection) {
            detection.getClass();
            ensureDetectionIsMutable();
            this.detection_.set(i, detection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addDetection(Detection detection) {
            detection.getClass();
            ensureDetectionIsMutable();
            this.detection_.add(detection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addDetection(int i, Detection detection) {
            detection.getClass();
            ensureDetectionIsMutable();
            this.detection_.add(i, detection);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllDetection(Iterable<? extends Detection> iterable) {
            ensureDetectionIsMutable();
            AbstractMessageLite.addAll(iterable, this.detection_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDetection() {
            this.detection_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeDetection(int i) {
            ensureDetectionIsMutable();
            this.detection_.remove(i);
        }

        public static DetectionList parseFrom(ByteBuffer byteBuffer) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static DetectionList parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static DetectionList parseFrom(ByteString byteString) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static DetectionList parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static DetectionList parseFrom(byte[] bArr) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static DetectionList parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static DetectionList parseFrom(InputStream inputStream) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static DetectionList parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static DetectionList parseDelimitedFrom(InputStream inputStream) {
            return (DetectionList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static DetectionList parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (DetectionList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static DetectionList parseFrom(CodedInputStream codedInputStream) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static DetectionList parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (DetectionList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(DetectionList detectionList) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(detectionList);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<DetectionList, Builder> implements DetectionListOrBuilder {
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
                super(DetectionList.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionListOrBuilder
            public List<Detection> getDetectionList() {
                return Collections.unmodifiableList(((DetectionList) this.instance).getDetectionList());
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionListOrBuilder
            public int getDetectionCount() {
                return ((DetectionList) this.instance).getDetectionCount();
            }

            @Override // com.google.mediapipe.formats.proto.DetectionProto.DetectionListOrBuilder
            public Detection getDetection(int i) {
                return ((DetectionList) this.instance).getDetection(i);
            }

            public Builder setDetection(int i, Detection detection) {
                copyOnWrite();
                ((DetectionList) this.instance).setDetection(i, detection);
                return this;
            }

            public Builder setDetection(int i, Detection.Builder builder) {
                copyOnWrite();
                ((DetectionList) this.instance).setDetection(i, builder.build());
                return this;
            }

            public Builder addDetection(Detection detection) {
                copyOnWrite();
                ((DetectionList) this.instance).addDetection(detection);
                return this;
            }

            public Builder addDetection(int i, Detection detection) {
                copyOnWrite();
                ((DetectionList) this.instance).addDetection(i, detection);
                return this;
            }

            public Builder addDetection(Detection.Builder builder) {
                copyOnWrite();
                ((DetectionList) this.instance).addDetection(builder.build());
                return this;
            }

            public Builder addDetection(int i, Detection.Builder builder) {
                copyOnWrite();
                ((DetectionList) this.instance).addDetection(i, builder.build());
                return this;
            }

            public Builder addAllDetection(Iterable<? extends Detection> iterable) {
                copyOnWrite();
                ((DetectionList) this.instance).addAllDetection(iterable);
                return this;
            }

            public Builder clearDetection() {
                copyOnWrite();
                ((DetectionList) this.instance).clearDetection();
                return this;
            }

            public Builder removeDetection(int i) {
                copyOnWrite();
                ((DetectionList) this.instance).removeDetection(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new DetectionList();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0001\u0001Л", new Object[]{"detection_", Detection.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<DetectionList> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (DetectionList.class) {
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
            DetectionList detectionList = new DetectionList();
            DEFAULT_INSTANCE = detectionList;
            GeneratedMessageLite.registerDefaultInstance(DetectionList.class, detectionList);
        }

        public static DetectionList getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<DetectionList> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
