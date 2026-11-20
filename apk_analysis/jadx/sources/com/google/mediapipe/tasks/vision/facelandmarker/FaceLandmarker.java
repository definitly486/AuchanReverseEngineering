package com.google.mediapipe.tasks.vision.facelandmarker;

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
import com.google.mediapipe.tasks.vision.facedetector.proto.FaceDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.facegeometry.proto.FaceGeometryProto;
import com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto;
import com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarksDetectorGraphOptionsProto;
import java.io.File;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Objects;
import java.util.Optional;
import java.util.Set;
import java.util.function.Consumer;

/* JADX INFO: loaded from: classes3.dex */
public final class FaceLandmarker extends BaseVisionTaskApi {
    public static final Set<Connection> FACE_LANDMARKS_CONNECTORS;
    public static final Set<Connection> FACE_LANDMARKS_FACE_OVAL;
    public static final Set<Connection> FACE_LANDMARKS_LEFT_EYE;
    public static final Set<Connection> FACE_LANDMARKS_LEFT_EYE_BROW;
    public static final Set<Connection> FACE_LANDMARKS_LEFT_IRIS;
    public static final Set<Connection> FACE_LANDMARKS_LIPS;
    public static final Set<Connection> FACE_LANDMARKS_RIGHT_EYE;
    public static final Set<Connection> FACE_LANDMARKS_RIGHT_EYE_BROW;
    public static final Set<Connection> FACE_LANDMARKS_RIGHT_IRIS;
    public static final Set<Connection> FACE_LANDMARKS_TESSELATION;
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final int IMAGE_OUT_STREAM_INDEX = 1;
    private static final int LANDMARKS_OUT_STREAM_INDEX = 0;
    private static final String NORM_RECT_IN_STREAM_NAME = "norm_rect_in";
    private static final String TAG = "FaceLandmarker";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.face_landmarker.FaceLandmarkerGraph";
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in", "NORM_RECT:norm_rect_in"));
    private static int blendshapesOutStreamIndex = -1;
    private static int faceGeometryOutStreamIndex = -1;

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
        FACE_LANDMARKS_LIPS = FaceLandmarksConnections.FACE_LANDMARKS_LIPS;
        FACE_LANDMARKS_LEFT_EYE = FaceLandmarksConnections.FACE_LANDMARKS_LEFT_EYE;
        FACE_LANDMARKS_LEFT_EYE_BROW = FaceLandmarksConnections.FACE_LANDMARKS_LEFT_EYE_BROW;
        FACE_LANDMARKS_LEFT_IRIS = FaceLandmarksConnections.FACE_LANDMARKS_LEFT_IRIS;
        FACE_LANDMARKS_RIGHT_EYE = FaceLandmarksConnections.FACE_LANDMARKS_RIGHT_EYE;
        FACE_LANDMARKS_RIGHT_EYE_BROW = FaceLandmarksConnections.FACE_LANDMARKS_RIGHT_EYE_BROW;
        FACE_LANDMARKS_RIGHT_IRIS = FaceLandmarksConnections.FACE_LANDMARKS_RIGHT_IRIS;
        FACE_LANDMARKS_FACE_OVAL = FaceLandmarksConnections.FACE_LANDMARKS_FACE_OVAL;
        FACE_LANDMARKS_CONNECTORS = FaceLandmarksConnections.FACE_LANDMARKS_CONNECTORS;
        FACE_LANDMARKS_TESSELATION = FaceLandmarksConnections.FACE_LANDMARKS_TESSELATION;
    }

    public static FaceLandmarker createFromFile(Context context, String str) {
        return createFromOptions(context, FaceLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetPath(str).build()).build());
    }

    public static FaceLandmarker createFromFile(Context context, File file) throws IOException {
        ParcelFileDescriptor parcelFileDescriptorOpen = ParcelFileDescriptor.open(file, 268435456);
        try {
            FaceLandmarker faceLandmarkerCreateFromOptions = createFromOptions(context, FaceLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetFileDescriptor(Integer.valueOf(parcelFileDescriptorOpen.getFd())).build()).build());
            parcelFileDescriptorOpen.close();
            return faceLandmarkerCreateFromOptions;
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

    public static FaceLandmarker createFromBuffer(Context context, ByteBuffer byteBuffer) {
        return createFromOptions(context, FaceLandmarkerOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetBuffer(byteBuffer).build()).build());
    }

    public static FaceLandmarker createFromOptions(Context context, final FaceLandmarkerOptions faceLandmarkerOptions) {
        ArrayList arrayList = new ArrayList();
        arrayList.add("NORM_LANDMARKS:face_landmarks");
        arrayList.add("IMAGE:image_out");
        if (faceLandmarkerOptions.outputFaceBlendshapes()) {
            arrayList.add("BLENDSHAPES:face_blendshapes");
            blendshapesOutStreamIndex = arrayList.size() - 1;
        }
        if (faceLandmarkerOptions.outputFacialTransformationMatrixes()) {
            arrayList.add("FACE_GEOMETRY:face_geometry");
            faceGeometryOutStreamIndex = arrayList.size() - 1;
        }
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<FaceLandmarkerResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public FaceLandmarkerResult convertToTaskResult(List<Packet> list) {
                if (list.get(0).isEmpty()) {
                    return FaceLandmarkerResult.create(new ArrayList(), Optional.empty(), Optional.empty(), BaseVisionTaskApi.generateResultTimestampMs(faceLandmarkerOptions.runningMode(), list.get(0)));
                }
                Optional optionalEmpty = Optional.empty();
                if (faceLandmarkerOptions.outputFaceBlendshapes()) {
                    optionalEmpty = Optional.of(PacketGetter.getProtoVector(list.get(FaceLandmarker.blendshapesOutStreamIndex), ClassificationProto.ClassificationList.parser()));
                }
                Optional optionalEmpty2 = Optional.empty();
                if (faceLandmarkerOptions.outputFacialTransformationMatrixes()) {
                    List protoVector = PacketGetter.getProtoVector(list.get(FaceLandmarker.faceGeometryOutStreamIndex), FaceGeometryProto.FaceGeometry.parser());
                    Optional optionalOf = Optional.of(new ArrayList());
                    Iterator it = protoVector.iterator();
                    while (it.hasNext()) {
                        ((List) optionalOf.get()).add(((FaceGeometryProto.FaceGeometry) it.next()).getPoseTransformMatrix());
                    }
                    optionalEmpty2 = optionalOf;
                }
                return FaceLandmarkerResult.create(PacketGetter.getProtoVector(list.get(0), LandmarkProto.NormalizedLandmarkList.parser()), optionalEmpty, optionalEmpty2, BaseVisionTaskApi.generateResultTimestampMs(faceLandmarkerOptions.runningMode(), list.get(0)));
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(1))).build();
            }
        });
        faceLandmarkerOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        faceLandmarkerOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new FaceLandmarker(TaskRunner.create(context, TaskInfo.builder().setTaskName(FaceLandmarker.class.getSimpleName()).setTaskRunningModeName(faceLandmarkerOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(arrayList).setTaskOptions(faceLandmarkerOptions).setEnableFlowLimiting(faceLandmarkerOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), faceLandmarkerOptions.runningMode());
    }

    private FaceLandmarker(TaskRunner taskRunner, RunningMode runningMode) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, NORM_RECT_IN_STREAM_NAME);
    }

    public FaceLandmarkerResult detect(MPImage mPImage) {
        return detect(mPImage, ImageProcessingOptions.builder().build());
    }

    public FaceLandmarkerResult detect(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (FaceLandmarkerResult) processImageData(mPImage, imageProcessingOptions);
    }

    public FaceLandmarkerResult detectForVideo(MPImage mPImage, long j) {
        return detectForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public FaceLandmarkerResult detectForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        return (FaceLandmarkerResult) processVideoData(mPImage, imageProcessingOptions, j);
    }

    public void detectAsync(MPImage mPImage, long j) {
        detectAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void detectAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        validateImageProcessingOptions(imageProcessingOptions);
        sendLiveStreamData(mPImage, imageProcessingOptions, j);
    }

    @AutoValue
    public static abstract class FaceLandmarkerOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract Optional<ErrorListener> errorListener();

        abstract Optional<Float> minFaceDetectionConfidence();

        abstract Optional<Float> minFacePresenceConfidence();

        abstract Optional<Float> minTrackingConfidence();

        abstract Optional<Integer> numFaces();

        abstract boolean outputFaceBlendshapes();

        abstract boolean outputFacialTransformationMatrixes();

        abstract Optional<OutputHandler.ResultListener<FaceLandmarkerResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract FaceLandmarkerOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setMinFaceDetectionConfidence(Float f);

            public abstract Builder setMinFacePresenceConfidence(Float f);

            public abstract Builder setMinTrackingConfidence(Float f);

            public abstract Builder setNumFaces(Integer num);

            public abstract Builder setOutputFaceBlendshapes(boolean z);

            public abstract Builder setOutputFacialTransformationMatrixes(boolean z);

            public abstract Builder setResultListener(OutputHandler.ResultListener<FaceLandmarkerResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public final FaceLandmarkerOptions build() {
                FaceLandmarkerOptions faceLandmarkerOptionsAutoBuild = autoBuild();
                if (faceLandmarkerOptionsAutoBuild.runningMode() == RunningMode.LIVE_STREAM) {
                    if (!faceLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                        throw new IllegalArgumentException("The face landmarker is in the live stream mode, a user-defined result listener must be provided in FaceLandmarkerOptions.");
                    }
                } else if (faceLandmarkerOptionsAutoBuild.resultListener().isPresent()) {
                    throw new IllegalArgumentException("The face landmarker is in the image or the video mode, a user-defined result listener shouldn't be provided in FaceLandmarkerOptions.");
                }
                return faceLandmarkerOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            Builder numFaces = new AutoValue_FaceLandmarker_FaceLandmarkerOptions.Builder().setRunningMode(RunningMode.IMAGE).setNumFaces(1);
            Float fValueOf = Float.valueOf(0.5f);
            return numFaces.setMinFaceDetectionConfidence(fValueOf).setMinFacePresenceConfidence(fValueOf).setMinTrackingConfidence(fValueOf).setOutputFaceBlendshapes(false).setOutputFacialTransformationMatrixes(false);
        }

        /* JADX WARN: Multi-variable type inference failed */
        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
            final FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptions.Builder baseOptions = FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptions.newBuilder().setBaseOptions(BaseOptionsProto.BaseOptions.newBuilder().setUseStreamMode(runningMode() != RunningMode.IMAGE).mergeFrom(convertBaseOptionsToProto(baseOptions())).build());
            final FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.Builder builderNewBuilder = FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.newBuilder();
            Optional<Integer> optionalNumFaces = numFaces();
            Objects.requireNonNull(builderNewBuilder);
            optionalNumFaces.ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda0
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    builderNewBuilder.setNumFaces(((Integer) obj).intValue());
                }
            });
            minFaceDetectionConfidence().ifPresent(new FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda1(builderNewBuilder));
            FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.Builder builderNewBuilder2 = FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.newBuilder();
            Optional<Float> optionalMinFacePresenceConfidence = minFacePresenceConfidence();
            Objects.requireNonNull(builderNewBuilder2);
            optionalMinFacePresenceConfidence.ifPresent(new FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda2(builderNewBuilder2));
            Optional<Float> optionalMinTrackingConfidence = minTrackingConfidence();
            Objects.requireNonNull(baseOptions);
            optionalMinTrackingConfidence.ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.vision.facelandmarker.FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda3
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    baseOptions.setMinTrackingConfidence(((Float) obj).floatValue());
                }
            });
            baseOptions.setFaceDetectorGraphOptions(builderNewBuilder.build()).setFaceLandmarksDetectorGraphOptions(builderNewBuilder2.build());
            return (CalculatorOptionsProto.CalculatorOptions) CalculatorOptionsProto.CalculatorOptions.newBuilder().setExtension(FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptions.ext, baseOptions.build()).build();
        }
    }

    private static void validateImageProcessingOptions(ImageProcessingOptions imageProcessingOptions) {
        if (imageProcessingOptions.regionOfInterest().isPresent()) {
            throw new IllegalArgumentException("FaceLandmarker doesn't support region-of-interest.");
        }
    }
}
