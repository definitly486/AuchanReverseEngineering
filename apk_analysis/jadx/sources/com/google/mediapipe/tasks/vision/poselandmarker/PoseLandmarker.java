package com.google.mediapipe.tasks.vision.poselandmarker;

import android.content.Context;
import android.os.ParcelFileDescriptor;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.LandmarkProto;
import com.google.mediapipe.framework.AndroidPacketGetter;
import com.google.mediapipe.framework.MediaPipeException;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.PacketGetter;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
import com.google.mediapipe.framework.image.ByteBufferImageBuilder;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.components.containers.Connection;
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
import com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda0;
import com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda2;
import com.google.mediapipe.tasks.vision.posedetector.proto.PoseDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto;
import com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarksDetectorGraphOptionsProto;
import java.io.File;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Objects;
import java.util.Optional;
import java.util.Set;
import java.util.function.Consumer;

/* JADX INFO: loaded from: classes3.dex */
public final class PoseLandmarker extends BaseVisionTaskApi {
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final int IMAGE_OUT_STREAM_INDEX = 2;
    private static final int LANDMARKS_OUT_STREAM_INDEX = 0;
    private static final String NORM_RECT_IN_STREAM_NAME = "norm_rect_in";
    public static final Set<Connection> POSE_LANDMARKS;
    private static final String TAG = "PoseLandmarker";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.pose_landmarker.PoseLandmarkerGraph";
    private static final int WORLD_LANDMARKS_OUT_STREAM_INDEX = 1;
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in", "NORM_RECT:norm_rect_in"));
    private static int segmentationMasksOutStreamIndex = -1;

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
        POSE_LANDMARKS = PoseLandmarksConnections.POSE_LANDMARKS;
    }

    public static PoseLandmarker createFromFile(Context context, String str) {
        return createFromOptions(context, PoseLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetPath(str).build()).build());
    }

    public static PoseLandmarker createFromFile(Context context, File file) throws IOException {
        ParcelFileDescriptor parcelFileDescriptorOpen = ParcelFileDescriptor.open(file, 268435456);
        try {
            PoseLandmarker poseLandmarkerCreateFromOptions = createFromOptions(context, PoseLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetFileDescriptor(Integer.valueOf(parcelFileDescriptorOpen.getFd())).build()).build());
            parcelFileDescriptorOpen.close();
            return poseLandmarkerCreateFromOptions;
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

    public static PoseLandmarker createFromBuffer(Context context, ByteBuffer byteBuffer) {
        return createFromOptions(context, PoseLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetBuffer(byteBuffer).build()).build());
    }

    public static PoseLandmarker createFromOptions(Context context, final PoseLandmarkerOptions poseLandmarkerOptions) {
        ArrayList arrayList = new ArrayList();
        arrayList.add("NORM_LANDMARKS:pose_landmarks");
        arrayList.add("WORLD_LANDMARKS:world_landmarks");
        arrayList.add("IMAGE:image_out");
        if (poseLandmarkerOptions.outputSegmentationMasks()) {
            arrayList.add("SEGMENTATION_MASK:segmentation_masks");
            segmentationMasksOutStreamIndex = arrayList.size() - 1;
        }
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<PoseLandmarkerResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public PoseLandmarkerResult convertToTaskResult(List<Packet> list) {
                if (list.get(0).isEmpty()) {
                    return PoseLandmarkerResult.create(new ArrayList(), new ArrayList(), Optional.empty(), BaseVisionTaskApi.generateResultTimestampMs(poseLandmarkerOptions.runningMode(), list.get(0)));
                }
                Optional optionalEmpty = Optional.empty();
                if (poseLandmarkerOptions.outputSegmentationMasks()) {
                    optionalEmpty = PoseLandmarker.getSegmentationMasks(list);
                }
                return PoseLandmarkerResult.create(PacketGetter.getProtoVector(list.get(0), LandmarkProto.NormalizedLandmarkList.parser()), PacketGetter.getProtoVector(list.get(1), LandmarkProto.LandmarkList.parser()), optionalEmpty, BaseVisionTaskApi.generateResultTimestampMs(poseLandmarkerOptions.runningMode(), list.get(0)));
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(2))).build();
            }
        });
        poseLandmarkerOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        poseLandmarkerOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new PoseLandmarker(TaskRunner.create(context, TaskInfo.builder().setTaskName(PoseLandmarker.class.getSimpleName()).setTaskRunningModeName(poseLandmarkerOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(arrayList).setTaskOptions(poseLandmarkerOptions).setEnableFlowLimiting(poseLandmarkerOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), poseLandmarkerOptions.runningMode());
    }

    private PoseLandmarker(TaskRunner taskRunner, RunningMode runningMode) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, NORM_RECT_IN_STREAM_NAME);
    }

    public PoseLandmarkerResult detect(MPImage mPImage) {
        return detect(mPImage, ImageProcessingOptions.builder().build());
    }

    public PoseLandmarkerResult detect(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (PoseLandmarkerResult) processImageData(mPImage, imageProcessingOptions);
    }

    public PoseLandmarkerResult detectForVideo(MPImage mPImage, long j) {
        return detectForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public PoseLandmarkerResult detectForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (PoseLandmarkerResult) processVideoData(mPImage, imageProcessingOptions, j);
    }

    public void detectAsync(MPImage mPImage, long j) {
        detectAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void detectAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        sendLiveStreamData(mPImage, imageProcessingOptions, j);
    }

    @AutoValue
    public static abstract class PoseLandmarkerOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract Optional<ErrorListener> errorListener();

        abstract Optional<Float> minPoseDetectionConfidence();

        abstract Optional<Float> minPosePresenceConfidence();

        abstract Optional<Float> minTrackingConfidence();

        abstract Optional<Integer> numPoses();

        abstract boolean outputSegmentationMasks();

        abstract Optional<OutputHandler.ResultListener<PoseLandmarkerResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract PoseLandmarkerOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setMinPoseDetectionConfidence(Float f);

            public abstract Builder setMinPosePresenceConfidence(Float f);

            public abstract Builder setMinTrackingConfidence(Float f);

            public abstract Builder setNumPoses(Integer num);

            public abstract Builder setOutputSegmentationMasks(boolean z);

            public abstract Builder setResultListener(OutputHandler.ResultListener<PoseLandmarkerResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public final PoseLandmarkerOptions build() {
                PoseLandmarkerOptions poseLandmarkerOptionsAutoBuild = autoBuild();
                if (poseLandmarkerOptionsAutoBuild.runningMode() == RunningMode.LIVE_STREAM) {
                    if (!poseLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                        throw new IllegalArgumentException("The pose landmarker is in the live stream mode, a user-defined result listener must be provided in PoseLandmarkerOptions.");
                    }
                } else if (poseLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                    throw new IllegalArgumentException("The pose landmarker is in the image or the video mode, a user-defined result listener shouldn't be provided in PoseLandmarkerOptions.");
                }
                return poseLandmarkerOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            Builder numPoses = new AutoValue_PoseLandmarker_PoseLandmarkerOptions.Builder().setRunningMode(RunningMode.IMAGE).setNumPoses(1);
            Float fValueOf = Float.valueOf(0.5f);
            return numPoses.setMinPoseDetectionConfidence(fValueOf).setMinPosePresenceConfidence(fValueOf).setMinTrackingConfidence(fValueOf).setOutputSegmentationMasks(false);
        }

        /* JADX WARN: Multi-variable type inference failed */
        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
            final PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptions.Builder baseOptions = PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptions.newBuilder().setBaseOptions(BaseOptionsProto.BaseOptions.newBuilder().setUseStreamMode(runningMode() != RunningMode.IMAGE).mergeFrom(convertBaseOptionsToProto(baseOptions())).build());
            final PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.Builder builderNewBuilder = PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.newBuilder();
            Optional<Integer> optionalNumPoses = numPoses();
            Objects.requireNonNull(builderNewBuilder);
            optionalNumPoses.ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker$PoseLandmarkerOptions$$ExternalSyntheticLambda0
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    builderNewBuilder.setNumPoses(((Integer) obj).intValue());
                }
            });
            minPoseDetectionConfidence().ifPresent(new HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda0(builderNewBuilder));
            PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.Builder builderNewBuilder2 = PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.newBuilder();
            Optional<Float> optionalMinPosePresenceConfidence = minPosePresenceConfidence();
            Objects.requireNonNull(builderNewBuilder2);
            optionalMinPosePresenceConfidence.ifPresent(new HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda2(builderNewBuilder2));
            Optional<Float> optionalMinTrackingConfidence = minTrackingConfidence();
            Objects.requireNonNull(baseOptions);
            optionalMinTrackingConfidence.ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.poselandmarker.PoseLandmarker$PoseLandmarkerOptions$$ExternalSyntheticLambda1
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    baseOptions.setMinTrackingConfidence(((Float) obj).floatValue());
                }
            });
            baseOptions.setPoseDetectorGraphOptions(builderNewBuilder.build()).setPoseLandmarksDetectorGraphOptions(builderNewBuilder2.build());
            return (CalculatorOptionsProto.CalculatorOptions) CalculatorOptionsProto.CalculatorOptions.newBuilder().setExtension(PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptions.ext, baseOptions.build()).build();
        }
    }

    private static void validateImageProcessingOptions(ImageProcessingOptions imageProcessingOptions) {
        if (imageProcessingOptions.regionOfInterest().isPresent()) {
            throw new IllegalArgumentException("PoseLandmarker doesn't support region-of-interest.");
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static Optional<List<MPImage>> getSegmentationMasks(List<Packet> list) {
        Optional<List<MPImage>> optionalOf = Optional.of(new ArrayList());
        int imageWidthFromImageList = PacketGetter.getImageWidthFromImageList(list.get(segmentationMasksOutStreamIndex));
        int imageHeightFromImageList = PacketGetter.getImageHeightFromImageList(list.get(segmentationMasksOutStreamIndex));
        int imageListSize = PacketGetter.getImageListSize(list.get(segmentationMasksOutStreamIndex));
        ByteBuffer[] byteBufferArr = new ByteBuffer[imageListSize];
        for (int i = 0; i < imageListSize; i++) {
            byteBufferArr[i] = ByteBuffer.allocateDirect(imageWidthFromImageList * imageHeightFromImageList * 4);
        }
        if (!PacketGetter.getImageList(list.get(segmentationMasksOutStreamIndex), byteBufferArr, true)) {
            throw new MediaPipeException(MediaPipeException.StatusCode.INTERNAL.ordinal(), "There is an error getting segmented masks.");
        }
        for (int i2 = 0; i2 < imageListSize; i2++) {
            optionalOf.get().add(new ByteBufferImageBuilder(byteBufferArr[i2], imageWidthFromImageList, imageHeightFromImageList, 10).build());
        }
        return optionalOf;
    }
}
