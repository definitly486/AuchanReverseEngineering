package com.scanflow.datacapture.core.camera.manager;

import android.content.Context;
import android.content.res.AssetFileDescriptor;
import android.media.MediaPlayer;
import android.os.Vibrator;
import com.scanflow.datacapture.R;
import com.scanflow.datacapture.utils.LogUtils;
import java.io.Closeable;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class BeepManager implements MediaPlayer.OnErrorListener, Closeable {
    public static final Companion Companion = new Companion(null);
    private static final long VIBRATE_DURATION = 200;
    private final Integer beepResource;
    private final Context context;
    private MediaPlayer mediaPlayer;
    private boolean playBeep;
    private boolean vibrate;
    private Vibrator vibrator;

    public static final class Companion {
        private Companion() {
        }

        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }
    }

    public BeepManager(Context context, Integer num) {
        Intrinsics.checkNotNullParameter(context, "context");
        this.context = context;
        this.beepResource = num;
        updatePrefs();
    }

    private final MediaPlayer buildMediaPlayer(Context context, Integer num) {
        MediaPlayer mediaPlayer = new MediaPlayer();
        try {
            AssetFileDescriptor assetFileDescriptorOpenRawResourceFd = context.getResources().openRawResourceFd(num != null ? num.intValue() : R.raw.beep);
            mediaPlayer.setDataSource(assetFileDescriptorOpenRawResourceFd.getFileDescriptor(), assetFileDescriptorOpenRawResourceFd.getStartOffset(), assetFileDescriptorOpenRawResourceFd.getLength());
            mediaPlayer.setOnErrorListener(this);
            mediaPlayer.setAudioStreamType(3);
            mediaPlayer.setLooping(false);
            mediaPlayer.prepare();
            return mediaPlayer;
        } catch (Exception e) {
            LogUtils.Companion.w(e);
            mediaPlayer.release();
            return null;
        }
    }

    private final synchronized void updatePrefs() {
        try {
            if (this.mediaPlayer == null) {
                this.mediaPlayer = buildMediaPlayer(this.context, this.beepResource);
            }
            if (this.vibrator == null) {
                Object systemService = this.context.getSystemService("vibrator");
                Intrinsics.checkNotNull(systemService, "null cannot be cast to non-null type android.os.Vibrator");
                this.vibrator = (Vibrator) systemService;
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    @Override // java.io.Closeable, java.lang.AutoCloseable
    public synchronized void close() {
        try {
            MediaPlayer mediaPlayer = this.mediaPlayer;
            if (mediaPlayer != null) {
                Intrinsics.checkNotNull(mediaPlayer);
                mediaPlayer.release();
                this.mediaPlayer = null;
            }
        } catch (Exception e) {
            LogUtils.Companion.e(e);
        }
    }

    @Override // android.media.MediaPlayer.OnErrorListener
    public synchronized boolean onError(MediaPlayer mp, int i, int i2) {
        Intrinsics.checkNotNullParameter(mp, "mp");
        close();
        updatePrefs();
        return true;
    }

    public final synchronized void playBeepSoundAndVibrate() {
        MediaPlayer mediaPlayer;
        try {
            if (this.playBeep && (mediaPlayer = this.mediaPlayer) != null) {
                Intrinsics.checkNotNull(mediaPlayer);
                mediaPlayer.start();
            }
            if (this.vibrate) {
                Vibrator vibrator = this.vibrator;
                Intrinsics.checkNotNull(vibrator);
                vibrator.vibrate(200L);
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public final void setPlayBeep(boolean z) {
        this.playBeep = z;
    }

    public final void setVibrate(boolean z) {
        this.vibrate = z;
    }
}
