package com.google.mediapipe.framework;

import android.content.Context;
import android.content.pm.PackageManager;
import android.content.res.AssetManager;
import android.text.TextUtils;
import com.google.common.base.Preconditions;
import com.google.common.flogger.FluentLogger;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;

/* JADX INFO: loaded from: classes3.dex */
public class AssetCache {
    static final String MEDIAPIPE_ASSET_CACHE_DIR = "mediapipe_asset_cache";
    private static AssetCache assetCache;
    private static final FluentLogger logger = FluentLogger.forEnclosingClass();
    private int appVersionCode;
    private Context context;
    private AssetCacheDbHelper versionDatabase;

    public static synchronized AssetCache create(Context context) {
        try {
            Preconditions.checkNotNull(context);
            if (assetCache == null) {
                assetCache = new AssetCache(context);
            }
        } catch (Throwable th) {
            throw th;
        }
        return assetCache;
    }

    public static synchronized void purgeCache(Context context) {
        AssetCacheDbHelper assetCacheDbHelper = new AssetCacheDbHelper(context);
        assetCacheDbHelper.invalidateCache(-1);
        assetCacheDbHelper.close();
    }

    public static synchronized AssetCache getAssetCache() {
        return assetCache;
    }

    public synchronized void loadAllAssets(String str) {
        String[] list;
        try {
            Preconditions.checkNotNull(str);
            try {
                list = this.context.getAssets().list(str);
            } catch (IOException e) {
                logger.atSevere().withCause(e).log("Unable to get files in assets path: %s", str);
                list = null;
            }
            if (list != null && list.length != 0) {
                for (String str2 : list) {
                    if (!TextUtils.isEmpty(str)) {
                        str2 = str + "/" + str2;
                    }
                    getAbsolutePathFromAsset(str2);
                }
                return;
            }
            logger.atWarning().log("No files to load");
        } catch (Throwable th) {
            throw th;
        }
    }

    public synchronized String getAbsolutePathFromAsset(String str) {
        InputStream inputStreamOpen;
        int i;
        AssetManager assets = this.context.getAssets();
        File defaultMediaPipeCacheDir = getDefaultMediaPipeCacheDir();
        defaultMediaPipeCacheDir.mkdir();
        File file = new File(defaultMediaPipeCacheDir.getPath(), new File(str).getName());
        if (file.exists() && (i = this.appVersionCode) != 0 && this.versionDatabase.checkVersion(str, i)) {
            return file.getAbsolutePath();
        }
        try {
            inputStreamOpen = assets.open(str);
            try {
                writeStreamToFile(inputStreamOpen, file);
                if (this.appVersionCode != 0) {
                    this.versionDatabase.insertAsset(str, file.getAbsolutePath(), this.appVersionCode);
                }
                return file.getAbsolutePath();
            } catch (IOException e) {
                e = e;
                logger.atSevere().withCause(e).log("Unable to unpack: %s", str);
                if (inputStreamOpen != null) {
                    try {
                        inputStreamOpen.close();
                    } catch (IOException unused) {
                        return null;
                    }
                }
                return null;
            }
        } catch (IOException e2) {
            e = e2;
            inputStreamOpen = null;
        }
    }

    public synchronized String[] getAvailableAssets() {
        File defaultMediaPipeCacheDir = getDefaultMediaPipeCacheDir();
        if (defaultMediaPipeCacheDir.exists()) {
            return defaultMediaPipeCacheDir.list();
        }
        return new String[0];
    }

    public File getDefaultMediaPipeCacheDir() {
        return new File(this.context.getCacheDir(), MEDIAPIPE_ASSET_CACHE_DIR);
    }

    private AssetCache(Context context) {
        this.context = context;
        this.versionDatabase = new AssetCacheDbHelper(context);
        try {
            this.appVersionCode = context.getPackageManager().getPackageInfo(context.getPackageName(), 0).versionCode;
            logger.atInfo().log("Current app version code: %d", this.appVersionCode);
            this.versionDatabase.invalidateCache(this.appVersionCode);
        } catch (PackageManager.NameNotFoundException e) {
            throw new RuntimeException("Can't get app version code.", e);
        }
    }

    private static void writeStreamToFile(InputStream inputStream, File file) throws Throwable {
        FileOutputStream fileOutputStream = null;
        try {
            FileOutputStream fileOutputStream2 = new FileOutputStream(file);
            try {
                byte[] bArr = new byte[1000];
                while (true) {
                    int i = inputStream.read(bArr);
                    if (i != -1) {
                        fileOutputStream2.write(bArr, 0, i);
                    } else {
                        fileOutputStream2.close();
                        return;
                    }
                }
            } catch (Throwable th) {
                th = th;
                fileOutputStream = fileOutputStream2;
                if (fileOutputStream != null) {
                    fileOutputStream.close();
                }
                throw th;
            }
        } catch (Throwable th2) {
            th = th2;
        }
    }
}
