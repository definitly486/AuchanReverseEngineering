package com.google.mediapipe.tasks.vision.holisticlandmarker.proto;

import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.mediapipe.tasks.vision.facedetector.proto.FaceDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarksDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.handlandmarker.proto.HandLandmarksDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.handlandmarker.proto.HandRoiRefinementGraphOptionsProto;
import com.google.mediapipe.tasks.vision.posedetector.proto.PoseDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarksDetectorGraphOptionsProto;
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
public final class HolisticLandmarkerGraphOptionsProto {

    public interface HolisticLandmarkerGraphOptionsOrBuilder extends MessageLiteOrBuilder {
        BaseOptionsProto.BaseOptions getBaseOptions();

        FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions getFaceDetectorGraphOptions();

        FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions getFaceLandmarksDetectorGraphOptions();

        HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions getHandLandmarksDetectorGraphOptions();

        HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions getHandRoiRefinementGraphOptions();

        PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions getPoseDetectorGraphOptions();

        PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions getPoseLandmarksDetectorGraphOptions();

        boolean hasBaseOptions();

        boolean hasFaceDetectorGraphOptions();

        boolean hasFaceLandmarksDetectorGraphOptions();

        boolean hasHandLandmarksDetectorGraphOptions();

        boolean hasHandRoiRefinementGraphOptions();

        boolean hasPoseDetectorGraphOptions();

        boolean hasPoseLandmarksDetectorGraphOptions();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private HolisticLandmarkerGraphOptionsProto() {
    }

    public static final class HolisticLandmarkerGraphOptions extends GeneratedMessageLite<HolisticLandmarkerGraphOptions, Builder> implements HolisticLandmarkerGraphOptionsOrBuilder {
        public static final int BASE_OPTIONS_FIELD_NUMBER = 1;
        private static final HolisticLandmarkerGraphOptions DEFAULT_INSTANCE;
        public static final int FACE_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 4;
        public static final int FACE_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 5;
        public static final int HAND_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 2;
        public static final int HAND_ROI_REFINEMENT_GRAPH_OPTIONS_FIELD_NUMBER = 3;
        private static volatile Parser<HolisticLandmarkerGraphOptions> PARSER = null;
        public static final int POSE_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 6;
        public static final int POSE_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 7;
        private BaseOptionsProto.BaseOptions baseOptions_;
        private int bitField0_;
        private FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions_;
        private FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions_;
        private HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions handLandmarksDetectorGraphOptions_;
        private HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions handRoiRefinementGraphOptions_;
        private PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions_;
        private PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions_;

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

        private HolisticLandmarkerGraphOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public boolean hasBaseOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public boolean hasHandLandmarksDetectorGraphOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions getHandLandmarksDetectorGraphOptions() {
            HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions handLandmarksDetectorGraphOptions = this.handLandmarksDetectorGraphOptions_;
            return handLandmarksDetectorGraphOptions == null ? HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.getDefaultInstance() : handLandmarksDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHandLandmarksDetectorGraphOptions(HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions handLandmarksDetectorGraphOptions) {
            handLandmarksDetectorGraphOptions.getClass();
            this.handLandmarksDetectorGraphOptions_ = handLandmarksDetectorGraphOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeHandLandmarksDetectorGraphOptions(HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions handLandmarksDetectorGraphOptions) {
            handLandmarksDetectorGraphOptions.getClass();
            HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions handLandmarksDetectorGraphOptions2 = this.handLandmarksDetectorGraphOptions_;
            if (handLandmarksDetectorGraphOptions2 != null && handLandmarksDetectorGraphOptions2 != HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.getDefaultInstance()) {
                this.handLandmarksDetectorGraphOptions_ = HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.newBuilder(this.handLandmarksDetectorGraphOptions_).mergeFrom(handLandmarksDetectorGraphOptions).buildPartial();
            } else {
                this.handLandmarksDetectorGraphOptions_ = handLandmarksDetectorGraphOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHandLandmarksDetectorGraphOptions() {
            this.handLandmarksDetectorGraphOptions_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public boolean hasHandRoiRefinementGraphOptions() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions getHandRoiRefinementGraphOptions() {
            HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions handRoiRefinementGraphOptions = this.handRoiRefinementGraphOptions_;
            return handRoiRefinementGraphOptions == null ? HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions.getDefaultInstance() : handRoiRefinementGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHandRoiRefinementGraphOptions(HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions handRoiRefinementGraphOptions) {
            handRoiRefinementGraphOptions.getClass();
            this.handRoiRefinementGraphOptions_ = handRoiRefinementGraphOptions;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeHandRoiRefinementGraphOptions(HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions handRoiRefinementGraphOptions) {
            handRoiRefinementGraphOptions.getClass();
            HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions handRoiRefinementGraphOptions2 = this.handRoiRefinementGraphOptions_;
            if (handRoiRefinementGraphOptions2 != null && handRoiRefinementGraphOptions2 != HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions.getDefaultInstance()) {
                this.handRoiRefinementGraphOptions_ = HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions.newBuilder(this.handRoiRefinementGraphOptions_).mergeFrom(handRoiRefinementGraphOptions).buildPartial();
            } else {
                this.handRoiRefinementGraphOptions_ = handRoiRefinementGraphOptions;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHandRoiRefinementGraphOptions() {
            this.handRoiRefinementGraphOptions_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public boolean hasFaceDetectorGraphOptions() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions getFaceDetectorGraphOptions() {
            FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions = this.faceDetectorGraphOptions_;
            return faceDetectorGraphOptions == null ? FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.getDefaultInstance() : faceDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
            faceDetectorGraphOptions.getClass();
            this.faceDetectorGraphOptions_ = faceDetectorGraphOptions;
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
            faceDetectorGraphOptions.getClass();
            FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions2 = this.faceDetectorGraphOptions_;
            if (faceDetectorGraphOptions2 != null && faceDetectorGraphOptions2 != FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.getDefaultInstance()) {
                this.faceDetectorGraphOptions_ = FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.newBuilder(this.faceDetectorGraphOptions_).mergeFrom(faceDetectorGraphOptions).buildPartial();
            } else {
                this.faceDetectorGraphOptions_ = faceDetectorGraphOptions;
            }
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFaceDetectorGraphOptions() {
            this.faceDetectorGraphOptions_ = null;
            this.bitField0_ &= -9;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public boolean hasFaceLandmarksDetectorGraphOptions() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions getFaceLandmarksDetectorGraphOptions() {
            FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions = this.faceLandmarksDetectorGraphOptions_;
            return faceLandmarksDetectorGraphOptions == null ? FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.getDefaultInstance() : faceLandmarksDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
            faceLandmarksDetectorGraphOptions.getClass();
            this.faceLandmarksDetectorGraphOptions_ = faceLandmarksDetectorGraphOptions;
            this.bitField0_ |= 16;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
            faceLandmarksDetectorGraphOptions.getClass();
            FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions2 = this.faceLandmarksDetectorGraphOptions_;
            if (faceLandmarksDetectorGraphOptions2 != null && faceLandmarksDetectorGraphOptions2 != FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.getDefaultInstance()) {
                this.faceLandmarksDetectorGraphOptions_ = FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.newBuilder(this.faceLandmarksDetectorGraphOptions_).mergeFrom(faceLandmarksDetectorGraphOptions).buildPartial();
            } else {
                this.faceLandmarksDetectorGraphOptions_ = faceLandmarksDetectorGraphOptions;
            }
            this.bitField0_ |= 16;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFaceLandmarksDetectorGraphOptions() {
            this.faceLandmarksDetectorGraphOptions_ = null;
            this.bitField0_ &= -17;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public boolean hasPoseDetectorGraphOptions() {
            return (this.bitField0_ & 32) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions getPoseDetectorGraphOptions() {
            PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions = this.poseDetectorGraphOptions_;
            return poseDetectorGraphOptions == null ? PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.getDefaultInstance() : poseDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
            poseDetectorGraphOptions.getClass();
            this.poseDetectorGraphOptions_ = poseDetectorGraphOptions;
            this.bitField0_ |= 32;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergePoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
            poseDetectorGraphOptions.getClass();
            PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions2 = this.poseDetectorGraphOptions_;
            if (poseDetectorGraphOptions2 != null && poseDetectorGraphOptions2 != PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.getDefaultInstance()) {
                this.poseDetectorGraphOptions_ = PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.newBuilder(this.poseDetectorGraphOptions_).mergeFrom(poseDetectorGraphOptions).buildPartial();
            } else {
                this.poseDetectorGraphOptions_ = poseDetectorGraphOptions;
            }
            this.bitField0_ |= 32;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPoseDetectorGraphOptions() {
            this.poseDetectorGraphOptions_ = null;
            this.bitField0_ &= -33;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public boolean hasPoseLandmarksDetectorGraphOptions() {
            return (this.bitField0_ & 64) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
        public PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions getPoseLandmarksDetectorGraphOptions() {
            PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions = this.poseLandmarksDetectorGraphOptions_;
            return poseLandmarksDetectorGraphOptions == null ? PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.getDefaultInstance() : poseLandmarksDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
            poseLandmarksDetectorGraphOptions.getClass();
            this.poseLandmarksDetectorGraphOptions_ = poseLandmarksDetectorGraphOptions;
            this.bitField0_ |= 64;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergePoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
            poseLandmarksDetectorGraphOptions.getClass();
            PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions2 = this.poseLandmarksDetectorGraphOptions_;
            if (poseLandmarksDetectorGraphOptions2 != null && poseLandmarksDetectorGraphOptions2 != PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.getDefaultInstance()) {
                this.poseLandmarksDetectorGraphOptions_ = PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.newBuilder(this.poseLandmarksDetectorGraphOptions_).mergeFrom(poseLandmarksDetectorGraphOptions).buildPartial();
            } else {
                this.poseLandmarksDetectorGraphOptions_ = poseLandmarksDetectorGraphOptions;
            }
            this.bitField0_ |= 64;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPoseLandmarksDetectorGraphOptions() {
            this.poseLandmarksDetectorGraphOptions_ = null;
            this.bitField0_ &= -65;
        }

        public static HolisticLandmarkerGraphOptions parseFrom(ByteBuffer byteBuffer) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(ByteString byteString) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(byte[] bArr) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(InputStream inputStream) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static HolisticLandmarkerGraphOptions parseDelimitedFrom(InputStream inputStream) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static HolisticLandmarkerGraphOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(CodedInputStream codedInputStream) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static HolisticLandmarkerGraphOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (HolisticLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(HolisticLandmarkerGraphOptions holisticLandmarkerGraphOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(holisticLandmarkerGraphOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<HolisticLandmarkerGraphOptions, Builder> implements HolisticLandmarkerGraphOptionsOrBuilder {
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
                super(HolisticLandmarkerGraphOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public boolean hasBaseOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).hasBaseOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public BaseOptionsProto.BaseOptions getBaseOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).getBaseOptions();
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setBaseOptions(baseOptions);
                return this;
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions.Builder builder) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setBaseOptions(builder.build());
                return this;
            }

            public Builder mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).mergeBaseOptions(baseOptions);
                return this;
            }

            public Builder clearBaseOptions() {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).clearBaseOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public boolean hasHandLandmarksDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).hasHandLandmarksDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions getHandLandmarksDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).getHandLandmarksDetectorGraphOptions();
            }

            public Builder setHandLandmarksDetectorGraphOptions(HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions handLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setHandLandmarksDetectorGraphOptions(handLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder setHandLandmarksDetectorGraphOptions(HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setHandLandmarksDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergeHandLandmarksDetectorGraphOptions(HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions handLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).mergeHandLandmarksDetectorGraphOptions(handLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder clearHandLandmarksDetectorGraphOptions() {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).clearHandLandmarksDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public boolean hasHandRoiRefinementGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).hasHandRoiRefinementGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions getHandRoiRefinementGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).getHandRoiRefinementGraphOptions();
            }

            public Builder setHandRoiRefinementGraphOptions(HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions handRoiRefinementGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setHandRoiRefinementGraphOptions(handRoiRefinementGraphOptions);
                return this;
            }

            public Builder setHandRoiRefinementGraphOptions(HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions.Builder builder) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setHandRoiRefinementGraphOptions(builder.build());
                return this;
            }

            public Builder mergeHandRoiRefinementGraphOptions(HandRoiRefinementGraphOptionsProto.HandRoiRefinementGraphOptions handRoiRefinementGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).mergeHandRoiRefinementGraphOptions(handRoiRefinementGraphOptions);
                return this;
            }

            public Builder clearHandRoiRefinementGraphOptions() {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).clearHandRoiRefinementGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public boolean hasFaceDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).hasFaceDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions getFaceDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).getFaceDetectorGraphOptions();
            }

            public Builder setFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setFaceDetectorGraphOptions(faceDetectorGraphOptions);
                return this;
            }

            public Builder setFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setFaceDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergeFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).mergeFaceDetectorGraphOptions(faceDetectorGraphOptions);
                return this;
            }

            public Builder clearFaceDetectorGraphOptions() {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).clearFaceDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public boolean hasFaceLandmarksDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).hasFaceLandmarksDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions getFaceLandmarksDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).getFaceLandmarksDetectorGraphOptions();
            }

            public Builder setFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setFaceLandmarksDetectorGraphOptions(faceLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder setFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setFaceLandmarksDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergeFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).mergeFaceLandmarksDetectorGraphOptions(faceLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder clearFaceLandmarksDetectorGraphOptions() {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).clearFaceLandmarksDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public boolean hasPoseDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).hasPoseDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions getPoseDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).getPoseDetectorGraphOptions();
            }

            public Builder setPoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setPoseDetectorGraphOptions(poseDetectorGraphOptions);
                return this;
            }

            public Builder setPoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setPoseDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergePoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).mergePoseDetectorGraphOptions(poseDetectorGraphOptions);
                return this;
            }

            public Builder clearPoseDetectorGraphOptions() {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).clearPoseDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public boolean hasPoseLandmarksDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).hasPoseLandmarksDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptionsOrBuilder
            public PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions getPoseLandmarksDetectorGraphOptions() {
                return ((HolisticLandmarkerGraphOptions) this.instance).getPoseLandmarksDetectorGraphOptions();
            }

            public Builder setPoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setPoseLandmarksDetectorGraphOptions(poseLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder setPoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).setPoseLandmarksDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergePoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).mergePoseLandmarksDetectorGraphOptions(poseLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder clearPoseLandmarksDetectorGraphOptions() {
                copyOnWrite();
                ((HolisticLandmarkerGraphOptions) this.instance).clearPoseLandmarksDetectorGraphOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new HolisticLandmarkerGraphOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0007\u0000\u0001\u0001\u0007\u0007\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001\u0003ဉ\u0002\u0004ဉ\u0003\u0005ဉ\u0004\u0006ဉ\u0005\u0007ဉ\u0006", new Object[]{"bitField0_", "baseOptions_", "handLandmarksDetectorGraphOptions_", "handRoiRefinementGraphOptions_", "faceDetectorGraphOptions_", "faceLandmarksDetectorGraphOptions_", "poseDetectorGraphOptions_", "poseLandmarksDetectorGraphOptions_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<HolisticLandmarkerGraphOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (HolisticLandmarkerGraphOptions.class) {
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
            HolisticLandmarkerGraphOptions holisticLandmarkerGraphOptions = new HolisticLandmarkerGraphOptions();
            DEFAULT_INSTANCE = holisticLandmarkerGraphOptions;
            GeneratedMessageLite.registerDefaultInstance(HolisticLandmarkerGraphOptions.class, holisticLandmarkerGraphOptions);
        }

        public static HolisticLandmarkerGraphOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<HolisticLandmarkerGraphOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto$1, reason: invalid class name */
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
