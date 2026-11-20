package com.google.mediapipe.tasks.vision.handlandmarker;

import android.content.Context;
import android.os.ParcelFileDescriptor;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.ClassificationProto;
import com.google.mediapipe.formats.proto.LandmarkProto;
import com.google.mediapipe.framework.AndroidPacketGetter;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.PacketGetter;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
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
import com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda0;
import com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda1;
import com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda2;
import com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda3;
import com.google.mediapipe.tasks.vision.handdetector.proto.HandDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.handlandmarker.proto.HandLandmarkerGraphOptionsProto;
import com.google.mediapipe.tasks.vision.handlandmarker.proto.HandLandmarksDetectorGraphOptionsProto;
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

/* JADX INFO: loaded from: classes3.dex */
public final class HandLandmarker extends BaseVisionTaskApi {
    private static final int HANDEDNESS_OUT_STREAM_INDEX = 2;
    public static final Set<Connection> HAND_CONNECTIONS;
    public static final Set<Connection> HAND_INDEX_FINGER_CONNECTIONS;
    public static final Set<Connection> HAND_MIDDLE_FINGER_CONNECTIONS;
    public static final Set<Connection> HAND_PALM_CONNECTIONS;
    public static final Set<Connection> HAND_PINKY_FINGER_CONNECTIONS;
    public static final Set<Connection> HAND_RING_FINGER_CONNECTIONS;
    public static final Set<Connection> HAND_THUMB_CONNECTIONS;
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final int IMAGE_OUT_STREAM_INDEX = 3;
    private static final int LANDMARKS_OUT_STREAM_INDEX = 0;
    private static final String NORM_RECT_IN_STREAM_NAME = "norm_rect_in";
    private static final String TAG = "HandLandmarker";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.hand_landmarker.HandLandmarkerGraph";
    private static final int WORLD_LANDMARKS_OUT_STREAM_INDEX = 1;
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in", "NORM_RECT:norm_rect_in"));
    private static final List<String> OUTPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("LANDMARKS:hand_landmarks", "WORLD_LANDMARKS:world_hand_landmarks", "HANDEDNESS:handedness", "IMAGE:image_out"));

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
        HAND_PALM_CONNECTIONS = HandLandmarksConnections.HAND_PALM_CONNECTIONS;
        HAND_THUMB_CONNECTIONS = HandLandmarksConnections.HAND_THUMB_CONNECTIONS;
        HAND_INDEX_FINGER_CONNECTIONS = HandLandmarksConnections.HAND_INDEX_FINGER_CONNECTIONS;
        HAND_MIDDLE_FINGER_CONNECTIONS = HandLandmarksConnections.HAND_MIDDLE_FINGER_CONNECTIONS;
        HAND_RING_FINGER_CONNECTIONS = HandLandmarksConnections.HAND_RING_FINGER_CONNECTIONS;
        HAND_PINKY_FINGER_CONNECTIONS = HandLandmarksConnections.HAND_PINKY_FINGER_CONNECTIONS;
        HAND_CONNECTIONS = HandLandmarksConnections.HAND_CONNECTIONS;
    }

    public static HandLandmarker createFromFile(Context context, String str) {
        return createFromOptions(context, HandLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetPath(str).build()).build());
    }

    public static HandLandmarker createFromFile(Context context, File file) throws IOException {
        ParcelFileDescriptor parcelFileDescriptorOpen = ParcelFileDescriptor.open(file, 268435456);
        try {
            HandLandmarker handLandmarkerCreateFromOptions = createFromOptions(context, HandLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetFileDescriptor(Integer.valueOf(parcelFileDescriptorOpen.getFd())).build()).build());
            parcelFileDescriptorOpen.close();
            return handLandmarkerCreateFromOptions;
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

    public static HandLandmarker createFromBuffer(Context context, ByteBuffer byteBuffer) {
        return createFromOptions(context, HandLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetBuffer(byteBuffer).build()).build());
    }

    public static HandLandmarker createFromOptions(Context context, final HandLandmarkerOptions handLandmarkerOptions) {
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<HandLandmarkerResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.handlandmarker.HandLandmarker.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public HandLandmarkerResult convertToTaskResult(List<Packet> list) {
                if (list.get(0).isEmpty()) {
                    return HandLandmarkerResult.create(new ArrayList(), new ArrayList(), new ArrayList(), BaseVisionTaskApi.generateResultTimestampMs(handLandmarkerOptions.runningMode(), list.get(0)));
                }
                return HandLandmarkerResult.create(PacketGetter.getProtoVector(list.get(0), LandmarkProto.NormalizedLandmarkList.parser()), PacketGetter.getProtoVector(list.get(1), LandmarkProto.LandmarkList.parser()), PacketGetter.getProtoVector(list.get(2), ClassificationProto.ClassificationList.parser()), BaseVisionTaskApi.generateResultTimestampMs(handLandmarkerOptions.runningMode(), list.get(0)));
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(3))).build();
            }
        });
        handLandmarkerOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        handLandmarkerOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new HandLandmarker(TaskRunner.create(context, TaskInfo.builder().setTaskName(HandLandmarker.class.getSimpleName()).setTaskRunningModeName(handLandmarkerOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(OUTPUT_STREAMS).setTaskOptions(handLandmarkerOptions).setEnableFlowLimiting(handLandmarkerOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), handLandmarkerOptions.runningMode());
    }

    private HandLandmarker(TaskRunner taskRunner, RunningMode runningMode) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, NORM_RECT_IN_STREAM_NAME);
    }

    public HandLandmarkerResult detect(MPImage mPImage) {
        return detect(mPImage, ImageProcessingOptions.builder().build());
    }

    public HandLandmarkerResult detect(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (HandLandmarkerResult) processImageData(mPImage, imageProcessingOptions);
    }

    public HandLandmarkerResult detectForVideo(MPImage mPImage, long j) {
        return detectForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public HandLandmarkerResult detectForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (HandLandmarkerResult) processVideoData(mPImage, imageProcessingOptions, j);
    }

    public void detectAsync(MPImage mPImage, long j) {
        detectAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void detectAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        sendLiveStreamData(mPImage, imageProcessingOptions, j);
    }

    @AutoValue
    public static abstract class HandLandmarkerOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract Optional<ErrorListener> errorListener();

        abstract Optional<Float> minHandDetectionConfidence();

        abstract Optional<Float> minHandPresenceConfidence();

        abstract Optional<Float> minTrackingConfidence();

        abstract Optional<Integer> numHands();

        abstract Optional<OutputHandler.ResultListener<HandLandmarkerResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract HandLandmarkerOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setMinHandDetectionConfidence(Float f);

            public abstract Builder setMinHandPresenceConfidence(Float f);

            public abstract Builder setMinTrackingConfidence(Float f);

            public abstract Builder setNumHands(Integer num);

            public abstract Builder setResultListener(OutputHandler.ResultListener<HandLandmarkerResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public final HandLandmarkerOptions build() {
                HandLandmarkerOptions handLandmarkerOptionsAutoBuild = autoBuild();
                if (handLandmarkerOptionsAutoBuild.runningMode() == RunningMode.LIVE_STREAM) {
                    if (!handLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                        throw new IllegalArgumentException("The hand landmarker is in the live stream mode, a user-defined result listener must be provided in HandLandmarkerOptions.");
                    }
                } else if (handLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                    throw new IllegalArgumentException("The hand landmarker is in the image or the video mode, a user-defined result listener shouldn't be provided in HandLandmarkerOptions.");
                }
                return handLandmarkerOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            Builder numHands = new AutoValue_HandLandmarker_HandLandmarkerOptions.Builder().setRunningMode(RunningMode.IMAGE).setNumHands(1);
            Float fValueOf = Float.valueOf(0.5f);
            return numHands.setMinHandDetectionConfidence(fValueOf).setMinHandPresenceConfidence(fValueOf).setMinTrackingConfidence(fValueOf);
        }

        /* JADX WARN: Multi-variable type inference failed */
        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
            HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.Builder baseOptions = HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.newBuilder().setBaseOptions(BaseOptionsProto.BaseOptions.newBuilder().setUseStreamMode(runningMode() != RunningMode.IMAGE).mergeFrom(convertBaseOptionsToProto(baseOptions())).build());
            HandDetectorGraphOptionsProto.HandDetectorGraphOptions.Builder builderNewBuilder = HandDetectorGraphOptionsProto.HandDetectorGraphOptions.newBuilder();
            Optional<Integer> optionalNumHands = numHands();
            Objects.requireNonNull(builderNewBuilder);
            optionalNumHands.ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda0(builderNewBuilder));
            minHandDetectionConfidence().ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda1(builderNewBuilder));
            HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.Builder builderNewBuilder2 = HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.newBuilder();
            Optional<Float> optionalMinHandPresenceConfidence = minHandPresenceConfidence();
            Objects.requireNonNull(builderNewBuilder2);
            optionalMinHandPresenceConfidence.ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda2(builderNewBuilder2));
            Optional<Float> optionalMinTrackingConfidence = minTrackingConfidence();
            Objects.requireNonNull(baseOptions);
            optionalMinTrackingConfidence.ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda3(baseOptions));
            baseOptions.setHandDetectorGraphOptions(builderNewBuilder.build()).setHandLandmarksDetectorGraphOptions(builderNewBuilder2.build());
            return (CalculatorOptionsProto.CalculatorOptions) CalculatorOptionsProto.CalculatorOptions.newBuilder().setExtension(HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.ext, baseOptions.build()).build();
        }
    }

    private static void validateImageProcessingOptions(ImageProcessingOptions imageProcessingOptions) {
        if (imageProcessingOptions.regionOfInterest().isPresent()) {
            throw new IllegalArgumentException("HandLandmarker doesn't support region-of-interest.");
        }
    }
}
