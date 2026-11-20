package com.google.mediapipe.tasks.vision.holisticlandmarker;

import android.content.Context;
import android.os.ParcelFileDescriptor;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.ClassificationProto;
import com.google.mediapipe.formats.proto.LandmarkProto;
import com.google.mediapipe.framework.AndroidPacketGetter;
import com.google.mediapipe.framework.MediaPipeException;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.PacketGetter;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
import com.google.mediapipe.framework.image.ByteBufferImageBuilder;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.BaseOptions;
import com.google.mediapipe.tasks.core.ErrorListener;
import com.google.mediapipe.tasks.core.OutputHandler;
import com.google.mediapipe.tasks.core.TaskInfo;
import com.google.mediapipe.tasks.core.TaskOptions;
import com.google.mediapipe.tasks.core.TaskResult;
import com.google.mediapipe.tasks.core.TaskRunner;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.mediapipe.tasks.vision.core.BaseVisionTaskApi;
import com.google.mediapipe.tasks.vision.core.ImageProcessingOptions;
import com.google.mediapipe.tasks.vision.core.RunningMode;
import com.google.mediapipe.tasks.vision.facedetector.FaceDetector$$ExternalSyntheticLambda0;
import com.google.mediapipe.tasks.vision.facedetector.FaceDetector$$ExternalSyntheticLambda1;
import com.google.mediapipe.tasks.vision.facedetector.proto.FaceDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda1;
import com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda2;
import com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarksDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda2;
import com.google.mediapipe.tasks.vision.handlandmarker.proto.HandLandmarksDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.holisticlandmarker.proto.HolisticLandmarkerGraphOptionsProto;
import com.google.mediapipe.tasks.vision.posedetector.proto.PoseDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarksDetectorGraphOptionsProto;
import com.google.protobuf.Any;
import java.io.File;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Objects;
import java.util.Optional;
import java.util.function.Consumer;

/* JADX INFO: loaded from: classes3.dex */
public final class HolisticLandmarker extends BaseVisionTaskApi {
    private static final boolean DEFAULT_OUTPUT_FACE_BLENDSHAPES = false;
    private static final boolean DEFAULT_OUTPUT_SEGMENTATION_MASKS = false;
    private static final float DEFAULT_PRESENCE_THRESHOLD = 0.5f;
    private static final float DEFAULT_SUPPRESION_THRESHOLD = 0.3f;
    private static final String FACE_BLENDSHAPES_STREAM = "extra_blendshapes";
    private static final int FACE_LANDMARKS_OUT_STREAM_INDEX = 0;
    private static final String FACE_LANDMARKS_STREAM = "face_landmarks";
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final int IMAGE_OUT_STREAM_INDEX = 7;
    private static final String IMAGE_OUT_STREAM_NAME = "image_out";
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in"));
    private static final int LEFT_HAND_LANDMARKS_OUT_STREAM_INDEX = 3;
    private static final String LEFT_HAND_LANDMARKS_STREAM = "left_hand_landmarks";
    private static final int LEFT_HAND_WORLD_LANDMARKS_OUT_STREAM_INDEX = 4;
    private static final String LEFT_HAND_WORLD_LANDMARKS_STREAM = "left_hand_world_landmarks";
    private static final int POSE_LANDMARKS_OUT_STREAM_INDEX = 1;
    private static final String POSE_LANDMARKS_STREAM = "pose_landmarks";
    private static final String POSE_SEGMENTATION_MASK_STREAM = "pose_segmentation_mask";
    private static final int POSE_WORLD_LANDMARKS_OUT_STREAM_INDEX = 2;
    private static final String POSE_WORLD_LANDMARKS_STREAM = "pose_world_landmarks";
    private static final int RIGHT_HAND_LANDMARKS_OUT_STREAM_INDEX = 5;
    private static final String RIGHT_HAND_LANDMARKS_STREAM = "right_hand_landmarks";
    private static final int RIGHT_HAND_WORLD_LANDMARKS_OUT_STREAM_INDEX = 6;
    private static final String RIGHT_HAND_WORLD_LANDMARKS_STREAM = "right_hand_world_landmarks";
    private static final String TAG = "HolisticLandmarker";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.holistic_landmarker.HolisticLandmarkerGraph";

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
    }

    public static HolisticLandmarker createFromFile(Context context, String str) {
        return createFromOptions(context, HolisticLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetPath(str).build()).build());
    }

    public static HolisticLandmarker createFromFile(Context context, File file) throws IOException {
        ParcelFileDescriptor parcelFileDescriptorOpen = ParcelFileDescriptor.open(file, 268435456);
        try {
            HolisticLandmarker holisticLandmarkerCreateFromOptions = createFromOptions(context, HolisticLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetFileDescriptor(Integer.valueOf(parcelFileDescriptorOpen.getFd())).build()).build());
            parcelFileDescriptorOpen.close();
            return holisticLandmarkerCreateFromOptions;
        } catch (Throwable th) {
            if (parcelFileDescriptorOpen != null) {
                try {
                    parcelFileDescriptorOpen.close();
                } catch (Throwable th2) {
                    th.addSuppressed(th2);
                }
            }
            throw th;
        }
    }

    public static HolisticLandmarker createFromBuffer(Context context, ByteBuffer byteBuffer) {
        return createFromOptions(context, HolisticLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetBuffer(byteBuffer).build()).build());
    }

    public static HolisticLandmarker createFromOptions(Context context, final HolisticLandmarkerOptions holisticLandmarkerOptions) {
        ArrayList arrayList = new ArrayList();
        arrayList.add("FACE_LANDMARKS:face_landmarks");
        arrayList.add("POSE_LANDMARKS:pose_landmarks");
        arrayList.add("POSE_WORLD_LANDMARKS:pose_world_landmarks");
        arrayList.add("LEFT_HAND_LANDMARKS:left_hand_landmarks");
        arrayList.add("LEFT_HAND_WORLD_LANDMARKS:left_hand_world_landmarks");
        arrayList.add("RIGHT_HAND_LANDMARKS:right_hand_landmarks");
        arrayList.add("RIGHT_HAND_WORLD_LANDMARKS:right_hand_world_landmarks");
        arrayList.add("IMAGE:image_out");
        final int[] iArr = {-1};
        if (holisticLandmarkerOptions.outputFaceBlendshapes()) {
            arrayList.add("FACE_BLENDSHAPES:extra_blendshapes");
            iArr[0] = arrayList.size() - 1;
        }
        final int[] iArr2 = {-1};
        if (holisticLandmarkerOptions.outputPoseSegmentationMasks()) {
            arrayList.add("POSE_SEGMENTATION_MASK:pose_segmentation_mask");
            iArr2[0] = arrayList.size() - 1;
        }
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<HolisticLandmarkerResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarker.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public HolisticLandmarkerResult convertToTaskResult(List<Packet> list) {
                Optional optionalEmpty;
                Optional optionalEmpty2;
                LandmarkProto.NormalizedLandmarkList normalizedLandmarkList = HolisticLandmarker.getNormalizedLandmarkList(list.get(0));
                if (holisticLandmarkerOptions.outputFaceBlendshapes()) {
                    optionalEmpty = Optional.of((ClassificationProto.ClassificationList) PacketGetter.getProto(list.get(iArr[0]), ClassificationProto.ClassificationList.parser()));
                } else {
                    optionalEmpty = Optional.empty();
                }
                Optional optional = optionalEmpty;
                LandmarkProto.NormalizedLandmarkList normalizedLandmarkList2 = HolisticLandmarker.getNormalizedLandmarkList(list.get(1));
                LandmarkProto.LandmarkList landmarkList = HolisticLandmarker.getLandmarkList(list.get(2));
                if (holisticLandmarkerOptions.outputPoseSegmentationMasks()) {
                    optionalEmpty2 = Optional.of(HolisticLandmarker.getSegmentationMask(list, iArr2[0]));
                } else {
                    optionalEmpty2 = Optional.empty();
                }
                return HolisticLandmarkerResult.create(normalizedLandmarkList, optional, normalizedLandmarkList2, landmarkList, optionalEmpty2, HolisticLandmarker.getNormalizedLandmarkList(list.get(3)), HolisticLandmarker.getLandmarkList(list.get(4)), HolisticLandmarker.getNormalizedLandmarkList(list.get(5)), HolisticLandmarker.getLandmarkList(list.get(6)), BaseVisionTaskApi.generateResultTimestampMs(holisticLandmarkerOptions.runningMode(), list.get(0)));
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(7))).build();
            }
        });
        holisticLandmarkerOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        holisticLandmarkerOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new HolisticLandmarker(TaskRunner.create(context, TaskInfo.builder().setTaskName(HolisticLandmarker.class.getSimpleName()).setTaskRunningModeName(holisticLandmarkerOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(arrayList).setTaskOptions(holisticLandmarkerOptions).setEnableFlowLimiting(holisticLandmarkerOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), holisticLandmarkerOptions.runningMode());
    }

    private HolisticLandmarker(TaskRunner taskRunner, RunningMode runningMode) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, "");
    }

    public HolisticLandmarkerResult detect(MPImage mPImage) {
        return detect(mPImage, ImageProcessingOptions.builder().build());
    }

    public HolisticLandmarkerResult detect(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (HolisticLandmarkerResult) processImageData(mPImage, imageProcessingOptions);
    }

    public HolisticLandmarkerResult detectForVideo(MPImage mPImage, long j) {
        return detectForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public HolisticLandmarkerResult detectForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (HolisticLandmarkerResult) processVideoData(mPImage, imageProcessingOptions, j);
    }

    public void detectAsync(MPImage mPImage, long j) {
        detectAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void detectAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        sendLiveStreamData(mPImage, imageProcessingOptions, j);
    }

    @AutoValue
    public static abstract class HolisticLandmarkerOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract Optional<ErrorListener> errorListener();

        abstract Optional<Float> minFaceDetectionConfidence();

        abstract Optional<Float> minFacePresenceConfidence();

        abstract Optional<Float> minFaceSuppressionThreshold();

        abstract Optional<Float> minHandLandmarksConfidence();

        abstract Optional<Float> minPoseDetectionConfidence();

        abstract Optional<Float> minPosePresenceConfidence();

        abstract Optional<Float> minPoseSuppressionThreshold();

        abstract boolean outputFaceBlendshapes();

        abstract boolean outputPoseSegmentationMasks();

        abstract Optional<OutputHandler.ResultListener<HolisticLandmarkerResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract HolisticLandmarkerOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setMinFaceDetectionConfidence(Float f);

            public abstract Builder setMinFacePresenceConfidence(Float f);

            public abstract Builder setMinFaceSuppressionThreshold(Float f);

            public abstract Builder setMinHandLandmarksConfidence(Float f);

            public abstract Builder setMinPoseDetectionConfidence(Float f);

            public abstract Builder setMinPosePresenceConfidence(Float f);

            public abstract Builder setMinPoseSuppressionThreshold(Float f);

            public abstract Builder setOutputFaceBlendshapes(boolean z);

            public abstract Builder setOutputPoseSegmentationMasks(boolean z);

            public abstract Builder setResultListener(OutputHandler.ResultListener<HolisticLandmarkerResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public final HolisticLandmarkerOptions build() {
                HolisticLandmarkerOptions holisticLandmarkerOptionsAutoBuild = autoBuild();
                if (holisticLandmarkerOptionsAutoBuild.runningMode() == RunningMode.LIVE_STREAM) {
                    if (!holisticLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                        throw new IllegalArgumentException("The holistic landmarker is in the live stream mode, a user-defined result listener must be provided in HolisticLandmarkerOptions.");
                    }
                } else if (holisticLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                    throw new IllegalArgumentException("The holistic landmarker is in the image or the video mode, a user-defined result listener shouldn't be provided in HolisticLandmarkerOptions.");
                }
                return holisticLandmarkerOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            Builder runningMode = new AutoValue_HolisticLandmarker_HolisticLandmarkerOptions.Builder().setRunningMode(RunningMode.IMAGE);
            Float fValueOf = Float.valueOf(HolisticLandmarker.DEFAULT_PRESENCE_THRESHOLD);
            Builder minFaceDetectionConfidence = runningMode.setMinFaceDetectionConfidence(fValueOf);
            Float fValueOf2 = Float.valueOf(HolisticLandmarker.DEFAULT_SUPPRESION_THRESHOLD);
            return minFaceDetectionConfidence.setMinFaceSuppressionThreshold(fValueOf2).setMinFacePresenceConfidence(fValueOf).setMinPoseDetectionConfidence(fValueOf).setMinPoseSuppressionThreshold(fValueOf2).setMinPosePresenceConfidence(fValueOf).setMinHandLandmarksConfidence(fValueOf).setOutputFaceBlendshapes(false).setOutputPoseSegmentationMasks(false);
        }

        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public Any convertToAnyProto() {
            HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptions.Builder baseOptions = HolisticLandmarkerGraphOptionsProto.HolisticLandmarkerGraphOptions.newBuilder().setBaseOptions(BaseOptionsProto.BaseOptions.newBuilder().setUseStreamMode(runningMode() != RunningMode.IMAGE).mergeFrom(convertBaseOptionsToProto(baseOptions())).build());
            HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.Builder builderNewBuilder = HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.newBuilder();
            final FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.Builder builderNewBuilder2 = FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.newBuilder();
            FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.Builder builderNewBuilder3 = FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.newBuilder();
            final PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.Builder builderNewBuilder4 = PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.newBuilder();
            PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.Builder builderNewBuilder5 = PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.newBuilder();
            Optional<Float> optionalMinHandLandmarksConfidence = minHandLandmarksConfidence();
            Objects.requireNonNull(builderNewBuilder);
            optionalMinHandLandmarksConfidence.ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda2(builderNewBuilder));
            Optional<Float> optionalMinPoseDetectionConfidence = minPoseDetectionConfidence();
            Objects.requireNonNull(builderNewBuilder4);
            optionalMinPoseDetectionConfidence.ifPresent(new HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda0(builderNewBuilder4));
            minPoseSuppressionThreshold().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda1
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    builderNewBuilder4.setMinSuppressionThreshold(((Float) obj).floatValue());
                }
            });
            Optional<Float> optionalMinPosePresenceConfidence = minPosePresenceConfidence();
            Objects.requireNonNull(builderNewBuilder5);
            optionalMinPosePresenceConfidence.ifPresent(new HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda2(builderNewBuilder5));
            Optional<Float> optionalMinFaceDetectionConfidence = minFaceDetectionConfidence();
            Objects.requireNonNull(builderNewBuilder2);
            optionalMinFaceDetectionConfidence.ifPresent(new FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda1(builderNewBuilder2));
            minFaceSuppressionThreshold().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda3
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    builderNewBuilder2.setMinSuppressionThreshold(((Float) obj).floatValue());
                }
            });
            Optional<Float> optionalMinFacePresenceConfidence = minFacePresenceConfidence();
            Objects.requireNonNull(builderNewBuilder3);
            optionalMinFacePresenceConfidence.ifPresent(new FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda2(builderNewBuilder3));
            baseOptions.setHandLandmarksDetectorGraphOptions(builderNewBuilder.build()).setFaceDetectorGraphOptions(builderNewBuilder2.build()).setFaceLandmarksDetectorGraphOptions(builderNewBuilder3.build()).setPoseDetectorGraphOptions(builderNewBuilder4.build()).setPoseLandmarksDetectorGraphOptions(builderNewBuilder5.build());
            return Any.newBuilder().setTypeUrl("type.googleapis.com/mediapipe.tasks.vision.holistic_landmarker.proto.HolisticLandmarkerGraphOptions").setValue(baseOptions.build().toByteString()).build();
        }
    }

    private static void validateImageProcessingOptions(ImageProcessingOptions imageProcessingOptions) {
        if (imageProcessingOptions.regionOfInterest().isPresent()) {
            throw new IllegalArgumentException("HolisticLandmarker doesn't support region-of-interest.");
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static MPImage getSegmentationMask(List<Packet> list, int i) {
        int imageWidth = PacketGetter.getImageWidth(list.get(i));
        int imageHeight = PacketGetter.getImageHeight(list.get(i));
        ByteBuffer byteBufferAllocateDirect = ByteBuffer.allocateDirect(imageWidth * imageHeight * 4);
        if (!PacketGetter.getImageData(list.get(i), byteBufferAllocateDirect)) {
            throw new MediaPipeException(MediaPipeException.StatusCode.INTERNAL.ordinal(), "There was an error getting the sefmentation mask.");
        }
        return new ByteBufferImageBuilder(byteBufferAllocateDirect, imageWidth, imageHeight, 10).build();
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static LandmarkProto.NormalizedLandmarkList getNormalizedLandmarkList(Packet packet) {
        if (packet.isEmpty()) {
            return LandmarkProto.NormalizedLandmarkList.getDefaultInstance();
        }
        return (LandmarkProto.NormalizedLandmarkList) PacketGetter.getProto(packet, LandmarkProto.NormalizedLandmarkList.parser());
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static LandmarkProto.LandmarkList getLandmarkList(Packet packet) {
        if (packet.isEmpty()) {
            return LandmarkProto.LandmarkList.getDefaultInstance();
        }
        return (LandmarkProto.LandmarkList) PacketGetter.getProto(packet, LandmarkProto.LandmarkList.parser());
    }
}
