package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.utils;

import android.media.MediaCodec;
import android.media.MediaCodecInfo;
import android.util.LruCache;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.EncoderConfig;
import com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder.InvalidConfigException;
import java.io.IOException;

/* JADX INFO: loaded from: classes.dex */
public abstract class CodecUtil {
    private static final LruCache sCodecInfoCache = new LruCache(10);

    public static MediaCodec createCodec(EncoderConfig encoderConfig) {
        return createCodec(encoderConfig.getMimeType());
    }

    public static MediaCodecInfo findCodecAndGetCodecInfo(EncoderConfig encoderConfig) throws Throwable {
        MediaCodecInfo mediaCodecInfo;
        MediaCodec mediaCodecCreateCodec;
        String mimeType = encoderConfig.getMimeType();
        LruCache lruCache = sCodecInfoCache;
        synchronized (lruCache) {
            mediaCodecInfo = (MediaCodecInfo) lruCache.get(mimeType);
        }
        if (mediaCodecInfo != null) {
            return mediaCodecInfo;
        }
        try {
            mediaCodecCreateCodec = createCodec(mimeType);
            try {
                MediaCodecInfo codecInfo = mediaCodecCreateCodec.getCodecInfo();
                synchronized (lruCache) {
                    lruCache.put(mimeType, codecInfo);
                }
                mediaCodecCreateCodec.release();
                return codecInfo;
            } catch (Throwable th) {
                th = th;
                if (mediaCodecCreateCodec != null) {
                    mediaCodecCreateCodec.release();
                }
                throw th;
            }
        } catch (Throwable th2) {
            th = th2;
            mediaCodecCreateCodec = null;
        }
    }

    private static MediaCodec createCodec(String str) throws InvalidConfigException {
        try {
            return MediaCodec.createEncoderByType(str);
        } catch (IOException | IllegalArgumentException e) {
            throw new InvalidConfigException(e);
        }
    }
}
