package com.google.mediapipe.tasks.vision.gesturerecognizer;

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
import com.google.mediapipe.tasks.components.processors.ClassifierOptions;
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
import com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto;
import com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto;
import com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto;
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
import java.util.function.Consumer;

/* JADX INFO: loaded from: classes3.dex */
public final class GestureRecognizer extends BaseVisionTaskApi {
    private static final int HANDEDNESS_OUT_STREAM_INDEX = 2;
    private static final int HAND_GESTURES_OUT_STREAM_INDEX = 3;
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final int IMAGE_OUT_STREAM_INDEX = 4;
    private static final int LANDMARKS_OUT_STREAM_INDEX = 0;
    private static final String NORM_RECT_IN_STREAM_NAME = "norm_rect_in";
    private static final String TAG = "GestureRecognizer";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.gesture_recognizer.GestureRecognizerGraph";
    private static final int WORLD_LANDMARKS_OUT_STREAM_INDEX = 1;
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in", "NORM_RECT:norm_rect_in"));
    private static final List<String> OUTPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("LANDMARKS:hand_landmarks", "WORLD_LANDMARKS:world_hand_landmarks", "HANDEDNESS:handedness", "HAND_GESTURES:hand_gestures", "IMAGE:image_out"));

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
    }

    public static GestureRecognizer createFromFile(Context context, String str) {
        return createFromOptions(context, GestureRecognizerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetPath(str).build()).build());
    }

    public static GestureRecognizer createFromFile(Context context, File file) throws IOException {
        ParcelFileDescriptor parcelFileDescriptorOpen = ParcelFileDescriptor.open(file, 268435456);
        try {
            GestureRecognizer gestureRecognizerCreateFromOptions = createFromOptions(context, GestureRecognizerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetFileDescriptor(Integer.valueOf(parcelFileDescriptorOpen.getFd())).build()).build());
            parcelFileDescriptorOpen.close();
            return gestureRecognizerCreateFromOptions;
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

    public static GestureRecognizer createFromBuffer(Context context, ByteBuffer byteBuffer) {
        return createFromOptions(context, GestureRecognizerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetBuffer(byteBuffer).build()).build());
    }

    public static GestureRecognizer createFromOptions(Context context, final GestureRecognizerOptions gestureRecognizerOptions) {
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<GestureRecognizerResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public GestureRecognizerResult convertToTaskResult(List<Packet> list) {
                if (list.get(3).isEmpty()) {
                    return GestureRecognizerResult.create(new ArrayList(), new ArrayList(), new ArrayList(), new ArrayList(), BaseVisionTaskApi.generateResultTimestampMs(gestureRecognizerOptions.runningMode(), list.get(3)));
                }
                return GestureRecognizerResult.create(PacketGetter.getProtoVector(list.get(0), LandmarkProto.NormalizedLandmarkList.parser()), PacketGetter.getProtoVector(list.get(1), LandmarkProto.LandmarkList.parser()), PacketGetter.getProtoVector(list.get(2), ClassificationProto.ClassificationList.parser()), PacketGetter.getProtoVector(list.get(3), ClassificationProto.ClassificationList.parser()), BaseVisionTaskApi.generateResultTimestampMs(gestureRecognizerOptions.runningMode(), list.get(3)));
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(4))).build();
            }
        });
        gestureRecognizerOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        gestureRecognizerOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new GestureRecognizer(TaskRunner.create(context, TaskInfo.builder().setTaskName(GestureRecognizer.class.getSimpleName()).setTaskRunningModeName(gestureRecognizerOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(OUTPUT_STREAMS).setTaskOptions(gestureRecognizerOptions).setEnableFlowLimiting(gestureRecognizerOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), gestureRecognizerOptions.runningMode());
    }

    private GestureRecognizer(TaskRunner taskRunner, RunningMode runningMode) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, NORM_RECT_IN_STREAM_NAME);
    }

    public GestureRecognizerResult recognize(MPImage mPImage) {
        return recognize(mPImage, ImageProcessingOptions.builder().build());
    }

    public GestureRecognizerResult recognize(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (GestureRecognizerResult) processImageData(mPImage, imageProcessingOptions);
    }

    public GestureRecognizerResult recognizeForVideo(MPImage mPImage, long j) {
        return recognizeForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public GestureRecognizerResult recognizeForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (GestureRecognizerResult) processVideoData(mPImage, imageProcessingOptions, j);
    }

    public void recognizeAsync(MPImage mPImage, long j) {
        recognizeAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void recognizeAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        sendLiveStreamData(mPImage, imageProcessingOptions, j);
    }

    @AutoValue
    public static abstract class GestureRecognizerOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract Optional<ClassifierOptions> cannedGesturesClassifierOptions();

        abstract Optional<ClassifierOptions> customGesturesClassifierOptions();

        abstract Optional<ErrorListener> errorListener();

        abstract Optional<Float> minHandDetectionConfidence();

        abstract Optional<Float> minHandPresenceConfidence();

        abstract Optional<Float> minTrackingConfidence();

        abstract Optional<Integer> numHands();

        abstract Optional<OutputHandler.ResultListener<GestureRecognizerResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract GestureRecognizerOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setCannedGesturesClassifierOptions(ClassifierOptions classifierOptions);

            public abstract Builder setCustomGesturesClassifierOptions(ClassifierOptions classifierOptions);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setMinHandDetectionConfidence(Float f);

            public abstract Builder setMinHandPresenceConfidence(Float f);

            public abstract Builder setMinTrackingConfidence(Float f);

            public abstract Builder setNumHands(Integer num);

            public abstract Builder setResultListener(OutputHandler.ResultListener<GestureRecognizerResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public final GestureRecognizerOptions build() {
                GestureRecognizerOptions gestureRecognizerOptionsAutoBuild = autoBuild();
                if (gestureRecognizerOptionsAutoBuild.runningMode() == RunningMode.LIVE_STREAM) {
                    if (!gestureRecognizerOptionsAutoBuild.resultListener().isPresent()) {
                        throw new IllegalArgumentException("The gesture recognizer is in the live stream mode, a user-defined result listener must be provided in GestureRecognizerOptions.");
                    }
                } else if (gestureRecognizerOptionsAutoBuild.resultListener().isPresent()) {
                    throw new IllegalArgumentException("The gesture recognizer is in the image or the video mode, a user-defined result listener shouldn't be provided in GestureRecognizerOptions.");
                }
                return gestureRecognizerOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            Builder numHands = new AutoValue_GestureRecognizer_GestureRecognizerOptions.Builder().setRunningMode(RunningMode.IMAGE).setNumHands(1);
            Float fValueOf = Float.valueOf(0.5f);
            return numHands.setMinHandDetectionConfidence(fValueOf).setMinHandPresenceConfidence(fValueOf).setMinTrackingConfidence(fValueOf);
        }

        /* JADX WARN: Multi-variable type inference failed */
        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
            GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptions.Builder baseOptions = GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptions.newBuilder().setBaseOptions(BaseOptionsProto.BaseOptions.newBuilder().setUseStreamMode(runningMode() != RunningMode.IMAGE).mergeFrom(convertBaseOptionsToProto(baseOptions())).build());
            HandDetectorGraphOptionsProto.HandDetectorGraphOptions.Builder builderNewBuilder = HandDetectorGraphOptionsProto.HandDetectorGraphOptions.newBuilder();
            Optional<Integer> optionalNumHands = numHands();
            Objects.requireNonNull(builderNewBuilder);
            optionalNumHands.ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda0(builderNewBuilder));
            minHandDetectionConfidence().ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda1(builderNewBuilder));
            HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.Builder builderNewBuilder2 = HandLandmarksDetectorGraphOptionsProto.HandLandmarksDetectorGraphOptions.newBuilder();
            Optional<Float> optionalMinHandPresenceConfidence = minHandPresenceConfidence();
            Objects.requireNonNull(builderNewBuilder2);
            optionalMinHandPresenceConfidence.ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda2(builderNewBuilder2));
            HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.Builder builderNewBuilder3 = HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.newBuilder();
            Optional<Float> optionalMinTrackingConfidence = minTrackingConfidence();
            Objects.requireNonNull(builderNewBuilder3);
            optionalMinTrackingConfidence.ifPresent(new GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda3(builderNewBuilder3));
            builderNewBuilder3.setHandDetectorGraphOptions(builderNewBuilder.build()).setHandLandmarksDetectorGraphOptions(builderNewBuilder2.build());
            final HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions.Builder builderNewBuilder4 = HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions.newBuilder();
            cannedGesturesClassifierOptions().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda4
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    builderNewBuilder4.setCannedGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.newBuilder().setClassifierOptions(((ClassifierOptions) obj).convertToProto()).build());
                }
            });
            customGesturesClassifierOptions().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.gesturerecognizer.GestureRecognizer$GestureRecognizerOptions$$ExternalSyntheticLambda5
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    builderNewBuilder4.setCustomGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.newBuilder().setClassifierOptions(((ClassifierOptions) obj).convertToProto()).build());
                }
            });
            baseOptions.setHandLandmarkerGraphOptions(builderNewBuilder3.build()).setHandGestureRecognizerGraphOptions(builderNewBuilder4.build());
            return (CalculatorOptionsProto.CalculatorOptions) CalculatorOptionsProto.CalculatorOptions.newBuilder().setExtension(GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptions.ext, baseOptions.build()).build();
        }
    }

    private static void validateImageProcessingOptions(ImageProcessingOptions imageProcessingOptions) {
        if (imageProcessingOptions.regionOfInterest().isPresent()) {
            throw new IllegalArgumentException("GestureRecognizer doesn't support region-of-interest.");
        }
    }
}
