package com.google.mediapipe.tasks.vision.imageembedder;

import android.content.Context;
import android.os.ParcelFileDescriptor;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.framework.AndroidPacketGetter;
import com.google.mediapipe.framework.MediaPipeException;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.PacketGetter;
import com.google.mediapipe.framework.ProtoUtil;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.components.containers.Embedding;
import com.google.mediapipe.tasks.components.containers.EmbeddingResult;
import com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto;
import com.google.mediapipe.tasks.components.processors.proto.EmbedderOptionsProto;
import com.google.mediapipe.tasks.components.utils.CosineSimilarity;
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
import com.google.mediapipe.tasks.vision.imageembedder.proto.ImageEmbedderGraphOptionsProto;
import java.io.File;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
public final class ImageEmbedder extends BaseVisionTaskApi {
    private static final int EMBEDDINGS_OUT_STREAM_INDEX = 0;
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final int IMAGE_OUT_STREAM_INDEX = 1;
    private static final String NORM_RECT_IN_STREAM_NAME = "norm_rect_in";
    private static final String TAG = "ImageEmbedder";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.image_embedder.ImageEmbedderGraph";
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in", "NORM_RECT:norm_rect_in"));
    private static final List<String> OUTPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("EMBEDDINGS:embeddings_out", "IMAGE:image_out"));

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
        ProtoUtil.registerTypeName(EmbeddingsProto.EmbeddingResult.class, "mediapipe.tasks.components.containers.proto.EmbeddingResult");
    }

    public static ImageEmbedder createFromFile(Context context, String str) {
        return createFromOptions(context, ImageEmbedderOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetPath(str).build()).build());
    }

    public static ImageEmbedder createFromFile(Context context, File file) throws IOException {
        ParcelFileDescriptor parcelFileDescriptorOpen = ParcelFileDescriptor.open(file, 268435456);
        try {
            ImageEmbedder imageEmbedderCreateFromOptions = createFromOptions(context, ImageEmbedderOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetFileDescriptor(Integer.valueOf(parcelFileDescriptorOpen.getFd())).build()).build());
            parcelFileDescriptorOpen.close();
            return imageEmbedderCreateFromOptions;
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

    public static ImageEmbedder createFromBuffer(Context context, ByteBuffer byteBuffer) {
        return createFromOptions(context, ImageEmbedderOptions.builder().setBaseOptions(BaseOptions.builder().setModelAssetBuffer(byteBuffer).build()).build());
    }

    public static ImageEmbedder createFromOptions(Context context, final ImageEmbedderOptions imageEmbedderOptions) {
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<ImageEmbedderResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.imageembedder.ImageEmbedder.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public ImageEmbedderResult convertToTaskResult(List<Packet> list) {
                try {
                    return ImageEmbedderResult.create(EmbeddingResult.createFromProto((EmbeddingsProto.EmbeddingResult) PacketGetter.getProto(list.get(0), EmbeddingsProto.EmbeddingResult.getDefaultInstance())), BaseVisionTaskApi.generateResultTimestampMs(imageEmbedderOptions.runningMode(), list.get(0)));
                } catch (IOException e) {
                    throw new MediaPipeException(MediaPipeException.StatusCode.INTERNAL.ordinal(), e.getMessage());
                }
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(1))).build();
            }
        });
        imageEmbedderOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        imageEmbedderOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new ImageEmbedder(TaskRunner.create(context, TaskInfo.builder().setTaskName(ImageEmbedder.class.getSimpleName()).setTaskRunningModeName(imageEmbedderOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(OUTPUT_STREAMS).setTaskOptions(imageEmbedderOptions).setEnableFlowLimiting(imageEmbedderOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), imageEmbedderOptions.runningMode());
    }

    private ImageEmbedder(TaskRunner taskRunner, RunningMode runningMode) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, NORM_RECT_IN_STREAM_NAME);
    }

    public ImageEmbedderResult embed(MPImage mPImage) {
        return embed(mPImage, ImageProcessingOptions.builder().build());
    }

    public ImageEmbedderResult embed(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        return (ImageEmbedderResult) processImageData(mPImage, imageProcessingOptions);
    }

    public ImageEmbedderResult embedForVideo(MPImage mPImage, long j) {
        return embedForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public ImageEmbedderResult embedForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        return (ImageEmbedderResult) processVideoData(mPImage, imageProcessingOptions, j);
    }

    public void embedAsync(MPImage mPImage, long j) {
        embedAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void embedAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        sendLiveStreamData(mPImage, imageProcessingOptions, j);
    }

    public static double cosineSimilarity(Embedding embedding, Embedding embedding2) {
        return CosineSimilarity.compute(embedding, embedding2);
    }

    @AutoValue
    public static abstract class ImageEmbedderOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract Optional<ErrorListener> errorListener();

        abstract boolean l2Normalize();

        abstract boolean quantize();

        abstract Optional<OutputHandler.ResultListener<ImageEmbedderResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract ImageEmbedderOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setL2Normalize(boolean z);

            public abstract Builder setQuantize(boolean z);

            public abstract Builder setResultListener(OutputHandler.ResultListener<ImageEmbedderResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public final ImageEmbedderOptions build() {
                ImageEmbedderOptions imageEmbedderOptionsAutoBuild = autoBuild();
                if (imageEmbedderOptionsAutoBuild.runningMode() == RunningMode.LIVE_STREAM) {
                    if (!imageEmbedderOptionsAutoBuild.resultListener().isPresent()) {
                        throw new IllegalArgumentException("The image embedder is in the live stream mode, a user-defined result listener must be provided in the ImageEmbedderOptions.");
                    }
                } else if (imageEmbedderOptionsAutoBuild.resultListener().isPresent()) {
                    throw new IllegalArgumentException("The image embedder is in the image or video mode, a user-defined result listener shouldn't be provided in ImageEmbedderOptions.");
                }
                return imageEmbedderOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            return new AutoValue_ImageEmbedder_ImageEmbedderOptions.Builder().setRunningMode(RunningMode.IMAGE).setL2Normalize(false).setQuantize(false);
        }

        /* JADX WARN: Multi-variable type inference failed */
        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
            BaseOptionsProto.BaseOptions.Builder builderNewBuilder = BaseOptionsProto.BaseOptions.newBuilder();
            builderNewBuilder.setUseStreamMode(runningMode() != RunningMode.IMAGE);
            builderNewBuilder.mergeFrom(convertBaseOptionsToProto(baseOptions()));
            EmbedderOptionsProto.EmbedderOptions.Builder builderNewBuilder2 = EmbedderOptionsProto.EmbedderOptions.newBuilder();
            builderNewBuilder2.setL2Normalize(l2Normalize());
            builderNewBuilder2.setQuantize(quantize());
            return (CalculatorOptionsProto.CalculatorOptions) CalculatorOptionsProto.CalculatorOptions.newBuilder().setExtension(ImageEmbedderGraphOptionsProto.ImageEmbedderGraphOptions.ext, ImageEmbedderGraphOptionsProto.ImageEmbedderGraphOptions.newBuilder().setBaseOptions(builderNewBuilder).setEmbedderOptions(builderNewBuilder2).build()).build();
        }
    }
}
