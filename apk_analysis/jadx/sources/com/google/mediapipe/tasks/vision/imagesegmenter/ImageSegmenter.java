package com.google.mediapipe.tasks.vision.imagesegmenter;

import android.content.Context;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.framework.AndroidPacketGetter;
import com.google.mediapipe.framework.MediaPipeException;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.PacketGetter;
import com.google.mediapipe.framework.image.BitmapImageBuilder;
import com.google.mediapipe.framework.image.ByteBufferImageBuilder;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.proto.CalculatorProto;
import com.google.mediapipe.tasks.TensorsToSegmentationCalculatorOptionsProto;
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
import com.google.mediapipe.tasks.vision.imagesegmenter.proto.ImageSegmenterGraphOptionsProto;
import com.google.mediapipe.tasks.vision.imagesegmenter.proto.SegmenterOptionsProto;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.function.BiFunction;

/* JADX INFO: loaded from: classes3.dex */
public final class ImageSegmenter extends BaseVisionTaskApi {
    private static final String IMAGE_IN_STREAM_NAME = "image_in";
    private static final List<String> INPUT_STREAMS = Collections.unmodifiableList(Arrays.asList("IMAGE:image_in", "NORM_RECT:norm_rect_in", "OUTPUT_SIZE:output_size_in"));
    private static final String NORM_RECT_IN_STREAM_NAME = "norm_rect_in";
    private static final String OUTPUT_SIZE_IN_STREAM_NAME = "output_size_in";
    private static final String TAG = "ImageSegmenter";
    private static final String TASK_GRAPH_NAME = "mediapipe.tasks.vision.image_segmenter.ImageSegmenterGraph";
    private static final String TENSORS_TO_SEGMENTATION_CALCULATOR_NAME = "mediapipe.tasks.TensorsToSegmentationCalculator";
    private boolean hasResultListener;
    private List<String> labels;

    static {
        System.loadLibrary("mediapipe_tasks_vision_jni");
    }

    public static ImageSegmenter createFromOptions(Context context, final ImageSegmenterOptions imageSegmenterOptions) {
        if (!imageSegmenterOptions.outputConfidenceMasks() && !imageSegmenterOptions.outputCategoryMask()) {
            throw new IllegalArgumentException("At least one of `outputConfidenceMasks` and `outputCategoryMask` must be set.");
        }
        ArrayList arrayList = new ArrayList();
        BiFunction biFunction = new BiFunction() { // from class: com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter$$ExternalSyntheticLambda0
            @Override // java.util.function.BiFunction
            public final Object apply(Object obj, Object obj2) {
                return ImageSegmenter.m441$r8$lambda$ktl_g1CgiKOzS4I5kH2KhxyFJ8((List) obj, (String) obj2);
            }
        };
        final int iIntValue = imageSegmenterOptions.outputConfidenceMasks() ? ((Integer) biFunction.apply(arrayList, "CONFIDENCE_MASKS:confidence_masks")).intValue() : -1;
        final int iIntValue2 = imageSegmenterOptions.outputCategoryMask() ? ((Integer) biFunction.apply(arrayList, "CATEGORY_MASK:category_mask")).intValue() : -1;
        final int iIntValue3 = ((Integer) biFunction.apply(arrayList, "QUALITY_SCORES:quality_scores")).intValue();
        final int iIntValue4 = ((Integer) biFunction.apply(arrayList, "IMAGE:image_out")).intValue();
        OutputHandler outputHandler = new OutputHandler();
        outputHandler.setOutputPacketConverter(new OutputHandler.OutputPacketConverter<ImageSegmenterResult, MPImage>() { // from class: com.google.mediapipe.tasks.vision.imagesegmenter.ImageSegmenter.1
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ MPImage convertToTaskInput(List list) {
                return convertToTaskInput((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public /* bridge */ /* synthetic */ TaskResult convertToTaskResult(List list) {
                return convertToTaskResult((List<Packet>) list);
            }

            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public ImageSegmenterResult convertToTaskResult(List<Packet> list) {
                ByteBuffer imageDataDirectly;
                if (list.get(iIntValue4).isEmpty()) {
                    return ImageSegmenterResult.create(Optional.empty(), Optional.empty(), new ArrayList(), list.get(iIntValue4).getTimestamp());
                }
                boolean zIsPresent = imageSegmenterOptions.resultListener().isPresent();
                boolean z = !zIsPresent;
                Optional optionalEmpty = Optional.empty();
                if (imageSegmenterOptions.outputConfidenceMasks()) {
                    int imageWidthFromImageList = PacketGetter.getImageWidthFromImageList(list.get(iIntValue));
                    int imageHeightFromImageList = PacketGetter.getImageHeightFromImageList(list.get(iIntValue));
                    Optional optionalOf = Optional.of(new ArrayList());
                    int imageListSize = PacketGetter.getImageListSize(list.get(iIntValue));
                    ByteBuffer[] byteBufferArr = new ByteBuffer[imageListSize];
                    if (!zIsPresent) {
                        for (int i = 0; i < imageListSize; i++) {
                            byteBufferArr[i] = ByteBuffer.allocateDirect(imageWidthFromImageList * imageHeightFromImageList * 4);
                        }
                    }
                    if (!PacketGetter.getImageList(list.get(iIntValue), byteBufferArr, z)) {
                        throw new MediaPipeException(MediaPipeException.StatusCode.INTERNAL.ordinal(), "There is an error getting confidence masks.");
                    }
                    for (int i2 = 0; i2 < imageListSize; i2++) {
                        ((List) optionalOf.get()).add(new ByteBufferImageBuilder(byteBufferArr[i2], imageWidthFromImageList, imageHeightFromImageList, 10).build());
                    }
                    optionalEmpty = optionalOf;
                }
                Optional optionalEmpty2 = Optional.empty();
                if (imageSegmenterOptions.outputCategoryMask()) {
                    int imageWidth = PacketGetter.getImageWidth(list.get(iIntValue2));
                    int imageHeight = PacketGetter.getImageHeight(list.get(iIntValue2));
                    if (!zIsPresent) {
                        imageDataDirectly = ByteBuffer.allocateDirect(imageWidth * imageHeight);
                        if (!PacketGetter.getImageData(list.get(iIntValue2), imageDataDirectly)) {
                            throw new MediaPipeException(MediaPipeException.StatusCode.INTERNAL.ordinal(), "There is an error getting category mask.");
                        }
                    } else {
                        imageDataDirectly = PacketGetter.getImageDataDirectly(list.get(iIntValue2));
                    }
                    optionalEmpty2 = Optional.of(new ByteBufferImageBuilder(imageDataDirectly, imageWidth, imageHeight, 8).build());
                }
                float[] float32Vector = PacketGetter.getFloat32Vector(list.get(iIntValue3));
                ArrayList arrayList2 = new ArrayList(float32Vector.length);
                for (float f : float32Vector) {
                    arrayList2.add(Float.valueOf(f));
                }
                return ImageSegmenterResult.create(optionalEmpty, optionalEmpty2, arrayList2, BaseVisionTaskApi.generateResultTimestampMs(imageSegmenterOptions.runningMode(), list.get(iIntValue4)));
            }

            /* JADX WARN: Can't rename method to resolve collision */
            @Override // com.google.mediapipe.tasks.core.OutputHandler.OutputPacketConverter
            public MPImage convertToTaskInput(List<Packet> list) {
                return new BitmapImageBuilder(AndroidPacketGetter.getBitmap(list.get(iIntValue4))).build();
            }
        });
        imageSegmenterOptions.resultListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda0(outputHandler));
        imageSegmenterOptions.errorListener().ifPresent(new FaceDetector$$ExternalSyntheticLambda1(outputHandler));
        return new ImageSegmenter(TaskRunner.create(context, TaskInfo.builder().setTaskName(ImageSegmenter.class.getSimpleName()).setTaskRunningModeName(imageSegmenterOptions.runningMode().name()).setTaskGraphName(TASK_GRAPH_NAME).setInputStreams(INPUT_STREAMS).setOutputStreams(arrayList).setTaskOptions(imageSegmenterOptions).setEnableFlowLimiting(imageSegmenterOptions.runningMode() == RunningMode.LIVE_STREAM).build(), outputHandler), imageSegmenterOptions.runningMode(), imageSegmenterOptions.resultListener().isPresent());
    }

    /* JADX INFO: renamed from: $r8$lambda$ktl_g1CgiKOzS-4I5kH2KhxyFJ8, reason: not valid java name */
    public static /* synthetic */ Integer m441$r8$lambda$ktl_g1CgiKOzS4I5kH2KhxyFJ8(List list, String str) {
        list.add(str);
        return Integer.valueOf(list.size() - 1);
    }

    private ImageSegmenter(TaskRunner taskRunner, RunningMode runningMode, boolean z) {
        super(taskRunner, runningMode, IMAGE_IN_STREAM_NAME, NORM_RECT_IN_STREAM_NAME);
        this.hasResultListener = false;
        this.labels = new ArrayList();
        this.hasResultListener = z;
        populateLabels();
    }

    private void populateLabels() {
        boolean z = false;
        for (CalculatorProto.CalculatorGraphConfig.Node node : this.runner.getCalculatorGraphConfig().getNodeList()) {
            if (node.getName().contains(TENSORS_TO_SEGMENTATION_CALCULATOR_NAME)) {
                if (z) {
                    throw new MediaPipeException(MediaPipeException.StatusCode.INTERNAL.ordinal(), "The graph has more than one mediapipe.tasks.TensorsToSegmentationCalculator.");
                }
                TensorsToSegmentationCalculatorOptionsProto.TensorsToSegmentationCalculatorOptions tensorsToSegmentationCalculatorOptions = (TensorsToSegmentationCalculatorOptionsProto.TensorsToSegmentationCalculatorOptions) node.getOptions().getExtension(TensorsToSegmentationCalculatorOptionsProto.TensorsToSegmentationCalculatorOptions.ext);
                for (int i = 0; i < tensorsToSegmentationCalculatorOptions.getLabelItemsMap().size(); i++) {
                    Long lValueOf = Long.valueOf(i);
                    if (!tensorsToSegmentationCalculatorOptions.getLabelItemsMap().containsKey(lValueOf)) {
                        throw new MediaPipeException(MediaPipeException.StatusCode.INTERNAL.ordinal(), "The lablemap have no expected key: " + lValueOf);
                    }
                    this.labels.add(tensorsToSegmentationCalculatorOptions.getLabelItemsMap().get(lValueOf).getName());
                }
                z = true;
            }
        }
    }

    public ImageSegmenterResult segment(MPImage mPImage) {
        return segment(mPImage, ImageProcessingOptions.builder().build());
    }

    public ImageSegmenterResult segment(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        return segment(mPImage, SegmentationOptions.builder().setOutputWidth(mPImage.getWidth()).setOutputHeight(mPImage.getHeight()).setImageProcessingOptions(imageProcessingOptions).build());
    }

    public ImageSegmenterResult segment(MPImage mPImage, SegmentationOptions segmentationOptions) {
        if (this.hasResultListener) {
            throw new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "ResultListener is provided in the ImageSegmenterOptions, but this method will return an ImageSegmentationResult.");
        }
        return (ImageSegmenterResult) processImageData(buildInputPackets(mPImage, segmentationOptions));
    }

    public void segmentWithResultListener(MPImage mPImage) {
        segmentWithResultListener(mPImage, ImageProcessingOptions.builder().build());
    }

    public void segmentWithResultListener(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        segmentWithResultListener(mPImage, SegmentationOptions.builder().setOutputWidth(mPImage.getWidth()).setOutputHeight(mPImage.getHeight()).setImageProcessingOptions(imageProcessingOptions).build());
    }

    public void segmentWithResultListener(MPImage mPImage, SegmentationOptions segmentationOptions) {
        if (!this.hasResultListener) {
            throw new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "ResultListener is not set in the ImageSegmenterOptions, but this method expects a ResultListener to process ImageSegmentationResult.");
        }
    }

    public ImageSegmenterResult segmentForVideo(MPImage mPImage, long j) {
        return segmentForVideo(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public ImageSegmenterResult segmentForVideo(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        return segmentForVideo(mPImage, SegmentationOptions.builder().setOutputWidth(mPImage.getWidth()).setOutputHeight(mPImage.getHeight()).setImageProcessingOptions(imageProcessingOptions).build(), j);
    }

    public ImageSegmenterResult segmentForVideo(MPImage mPImage, SegmentationOptions segmentationOptions, long j) {
        if (this.hasResultListener) {
            throw new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "ResultListener is provided in the ImageSegmenterOptions, but this method will return an ImageSegmentationResult.");
        }
        return (ImageSegmenterResult) processVideoData(buildInputPackets(mPImage, segmentationOptions), j);
    }

    public void segmentForVideoWithResultListener(MPImage mPImage, long j) {
        segmentForVideoWithResultListener(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void segmentForVideoWithResultListener(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        segmentForVideoWithResultListener(mPImage, SegmentationOptions.builder().setOutputWidth(mPImage.getWidth()).setOutputHeight(mPImage.getHeight()).setImageProcessingOptions(imageProcessingOptions).build(), j);
    }

    public void segmentForVideoWithResultListener(MPImage mPImage, SegmentationOptions segmentationOptions, long j) {
        if (!this.hasResultListener) {
            throw new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "ResultListener is not set in the ImageSegmenterOptions, but this method expects a ResultListener to process ImageSegmentationResult.");
        }
    }

    public void segmentAsync(MPImage mPImage, long j) {
        segmentAsync(mPImage, ImageProcessingOptions.builder().build(), j);
    }

    public void segmentAsync(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        segmentAsync(mPImage, SegmentationOptions.builder().setOutputWidth(mPImage.getWidth()).setOutputHeight(mPImage.getHeight()).setImageProcessingOptions(imageProcessingOptions).build(), j);
    }

    public void segmentAsync(MPImage mPImage, SegmentationOptions segmentationOptions, long j) {
        sendLiveStreamData(buildInputPackets(mPImage, segmentationOptions), j);
    }

    public List<String> getLabels() {
        return this.labels;
    }

    @AutoValue
    public static abstract class SegmentationOptions {
        abstract ImageProcessingOptions imageProcessingOptions();

        abstract int outputHeight();

        abstract int outputWidth();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract SegmentationOptions autoBuild();

            public abstract Builder setImageProcessingOptions(ImageProcessingOptions imageProcessingOptions);

            public abstract Builder setOutputHeight(int i);

            public abstract Builder setOutputWidth(int i);

            public final SegmentationOptions build() {
                SegmentationOptions segmentationOptionsAutoBuild = autoBuild();
                if (segmentationOptionsAutoBuild.outputWidth() <= 0 || segmentationOptionsAutoBuild.outputHeight() <= 0) {
                    throw new IllegalArgumentException("Both outputWidth and outputHeight must be larger than 0.");
                }
                if (segmentationOptionsAutoBuild.imageProcessingOptions().regionOfInterest().isPresent()) {
                    throw new IllegalArgumentException("ImageSegmenter doesn't support region-of-interest.");
                }
                return segmentationOptionsAutoBuild;
            }
        }

        public static Builder builder() {
            return new AutoValue_ImageSegmenter_SegmentationOptions.Builder().setImageProcessingOptions(ImageProcessingOptions.builder().build());
        }
    }

    @AutoValue
    public static abstract class ImageSegmenterOptions extends TaskOptions {
        abstract BaseOptions baseOptions();

        abstract String displayNamesLocale();

        abstract Optional<ErrorListener> errorListener();

        abstract boolean outputCategoryMask();

        abstract boolean outputConfidenceMasks();

        abstract Optional<OutputHandler.ResultListener<ImageSegmenterResult, MPImage>> resultListener();

        abstract RunningMode runningMode();

        @AutoValue.Builder
        public static abstract class Builder {
            abstract ImageSegmenterOptions autoBuild();

            public abstract Builder setBaseOptions(BaseOptions baseOptions);

            public abstract Builder setDisplayNamesLocale(String str);

            public abstract Builder setErrorListener(ErrorListener errorListener);

            public abstract Builder setOutputCategoryMask(boolean z);

            public abstract Builder setOutputConfidenceMasks(boolean z);

            public abstract Builder setResultListener(OutputHandler.ResultListener<ImageSegmenterResult, MPImage> resultListener);

            public abstract Builder setRunningMode(RunningMode runningMode);

            public final ImageSegmenterOptions build() {
                ImageSegmenterOptions imageSegmenterOptionsAutoBuild = autoBuild();
                if (imageSegmenterOptionsAutoBuild.runningMode() != RunningMode.LIVE_STREAM || imageSegmenterOptionsAutoBuild.resultListener().isPresent()) {
                    return imageSegmenterOptionsAutoBuild;
                }
                throw new IllegalArgumentException("The image segmenter is in the live stream mode, a user-defined result listener must be provided in ImageSegmenterOptions.");
            }
        }

        public static Builder builder() {
            return new AutoValue_ImageSegmenter_ImageSegmenterOptions.Builder().setRunningMode(RunningMode.IMAGE).setDisplayNamesLocale("en").setOutputConfidenceMasks(true).setOutputCategoryMask(false);
        }

        /* JADX WARN: Multi-variable type inference failed */
        @Override // com.google.mediapipe.tasks.core.TaskOptions
        public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
            ImageSegmenterGraphOptionsProto.ImageSegmenterGraphOptions.Builder displayNamesLocale = ImageSegmenterGraphOptionsProto.ImageSegmenterGraphOptions.newBuilder().setBaseOptions(BaseOptionsProto.BaseOptions.newBuilder().setUseStreamMode(runningMode() != RunningMode.IMAGE).mergeFrom(convertBaseOptionsToProto(baseOptions())).build()).setDisplayNamesLocale(displayNamesLocale());
            displayNamesLocale.setSegmenterOptions(SegmenterOptionsProto.SegmenterOptions.newBuilder());
            return (CalculatorOptionsProto.CalculatorOptions) CalculatorOptionsProto.CalculatorOptions.newBuilder().setExtension(ImageSegmenterGraphOptionsProto.ImageSegmenterGraphOptions.ext, displayNamesLocale.build()).build();
        }
    }

    private Map<String, Packet> buildInputPackets(MPImage mPImage, SegmentationOptions segmentationOptions) {
        HashMap map = new HashMap();
        map.put(this.imageStreamName, this.runner.getPacketCreator().createImage(mPImage));
        map.put(OUTPUT_SIZE_IN_STREAM_NAME, this.runner.getPacketCreator().createInt32Pair(segmentationOptions.outputWidth(), segmentationOptions.outputHeight()));
        if (!this.normRectStreamName.isEmpty()) {
            map.put(this.normRectStreamName, this.runner.getPacketCreator().createProto(BaseVisionTaskApi.convertToNormalizedRect(segmentationOptions.imageProcessingOptions(), mPImage)));
        }
        return map;
    }
}
