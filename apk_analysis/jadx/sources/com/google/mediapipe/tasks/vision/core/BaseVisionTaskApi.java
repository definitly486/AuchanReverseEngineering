package com.google.mediapipe.tasks.vision.core;

import android.graphics.RectF;
import com.google.mediapipe.formats.proto.RectProto;
import com.google.mediapipe.framework.MediaPipeException;
import com.google.mediapipe.framework.Packet;
import com.google.mediapipe.framework.ProtoUtil;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.core.TaskResult;
import com.google.mediapipe.tasks.core.TaskRunner;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public class BaseVisionTaskApi implements AutoCloseable {
    protected static final long MICROSECONDS_PER_MILLISECOND = 1000;
    protected final String imageStreamName;
    protected final String normRectStreamName;
    protected final TaskRunner runner;
    protected final RunningMode runningMode;

    static {
        ProtoUtil.registerTypeName(RectProto.NormalizedRect.class, "mediapipe.NormalizedRect");
    }

    public BaseVisionTaskApi(TaskRunner taskRunner, RunningMode runningMode, String str, String str2) {
        this.runner = taskRunner;
        this.runningMode = runningMode;
        this.imageStreamName = str;
        this.normRectStreamName = str2;
    }

    protected TaskResult processImageData(MPImage mPImage, ImageProcessingOptions imageProcessingOptions) {
        HashMap map = new HashMap();
        map.put(this.imageStreamName, this.runner.getPacketCreator().createImage(mPImage));
        if (!this.normRectStreamName.isEmpty()) {
            map.put(this.normRectStreamName, this.runner.getPacketCreator().createProto(convertToNormalizedRect(imageProcessingOptions, mPImage)));
        }
        return processImageData(map);
    }

    protected TaskResult processImageData(Map<String, Packet> map) {
        if (this.runningMode != RunningMode.IMAGE) {
            throw new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "Task is not initialized with the image mode. Current running mode:" + this.runningMode.name());
        }
        return this.runner.process(map);
    }

    protected TaskResult processVideoData(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        HashMap map = new HashMap();
        map.put(this.imageStreamName, this.runner.getPacketCreator().createImage(mPImage));
        if (!this.normRectStreamName.isEmpty()) {
            map.put(this.normRectStreamName, this.runner.getPacketCreator().createProto(convertToNormalizedRect(imageProcessingOptions, mPImage)));
        }
        return processVideoData(map, j);
    }

    protected TaskResult processVideoData(Map<String, Packet> map, long j) {
        if (this.runningMode != RunningMode.VIDEO) {
            throw new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "Task is not initialized with the video mode. Current running mode:" + this.runningMode.name());
        }
        return this.runner.process(map, j * MICROSECONDS_PER_MILLISECOND);
    }

    protected void sendLiveStreamData(MPImage mPImage, ImageProcessingOptions imageProcessingOptions, long j) {
        HashMap map = new HashMap();
        map.put(this.imageStreamName, this.runner.getPacketCreator().createImage(mPImage));
        if (!this.normRectStreamName.isEmpty()) {
            map.put(this.normRectStreamName, this.runner.getPacketCreator().createProto(convertToNormalizedRect(imageProcessingOptions, mPImage)));
        }
        sendLiveStreamData(map, j);
    }

    protected void sendLiveStreamData(Map<String, Packet> map, long j) {
        if (this.runningMode != RunningMode.LIVE_STREAM) {
            throw new MediaPipeException(MediaPipeException.StatusCode.FAILED_PRECONDITION.ordinal(), "Task is not initialized with the live stream mode. Current running mode:" + this.runningMode.name());
        }
        this.runner.send(map, j * MICROSECONDS_PER_MILLISECOND);
    }

    @Override // java.lang.AutoCloseable
    public void close() {
        this.runner.close();
    }

    protected static RectProto.NormalizedRect convertToNormalizedRect(ImageProcessingOptions imageProcessingOptions, MPImage mPImage) {
        RectF rectF;
        float fWidth;
        float fHeight;
        if (imageProcessingOptions.regionOfInterest().isPresent()) {
            rectF = imageProcessingOptions.regionOfInterest().get();
        } else {
            rectF = new RectF(0.0f, 0.0f, 1.0f, 1.0f);
        }
        boolean z = imageProcessingOptions.rotationDegrees() % 180 != 0;
        RectProto.NormalizedRect.Builder yCenter = RectProto.NormalizedRect.newBuilder().setXCenter(rectF.centerX()).setYCenter(rectF.centerY());
        if (z) {
            fWidth = (rectF.height() * mPImage.getHeight()) / mPImage.getWidth();
        } else {
            fWidth = rectF.width();
        }
        RectProto.NormalizedRect.Builder width = yCenter.setWidth(fWidth);
        if (z) {
            fHeight = (rectF.width() * mPImage.getWidth()) / mPImage.getHeight();
        } else {
            fHeight = rectF.height();
        }
        return width.setHeight(fHeight).setRotation((imageProcessingOptions.rotationDegrees() * (-3.1415927f)) / 180.0f).build();
    }

    public static long generateResultTimestampMs(RunningMode runningMode, Packet packet) {
        if (runningMode == RunningMode.IMAGE) {
            return -1L;
        }
        return packet.getTimestamp() / MICROSECONDS_PER_MILLISECOND;
    }
}
