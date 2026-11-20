package android.support.multidex;

import android.content.Context;
import android.content.SharedPreferences;
import android.content.pm.ApplicationInfo;
import android.util.Log;
import java.io.BufferedOutputStream;
import java.io.Closeable;
import java.io.File;
import java.io.FileFilter;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipException;
import java.util.zip.ZipFile;
import java.util.zip.ZipOutputStream;

/* JADX INFO: loaded from: classes.dex */
abstract class MultiDexExtractor {
    private static Method sApplyMethod;

    static List load(Context context, ApplicationInfo applicationInfo, File file, boolean z) throws IOException {
        List listPerformExtractions;
        Log.i("MultiDex", "MultiDexExtractor.load(" + applicationInfo.sourceDir + ", " + z + ")");
        File file2 = new File(applicationInfo.sourceDir);
        long zipCrc = getZipCrc(file2);
        if (!z && !isModified(context, file2, zipCrc)) {
            try {
                listPerformExtractions = loadExistingExtractions(context, file2, file);
            } catch (IOException e) {
                Log.w("MultiDex", "Failed to reload existing extracted secondary dex files, falling back to fresh extraction", e);
                List listPerformExtractions2 = performExtractions(file2, file);
                putStoredApkInfo(context, getTimeStamp(file2), zipCrc, listPerformExtractions2.size() + 1);
                listPerformExtractions = listPerformExtractions2;
            }
        } else {
            Log.i("MultiDex", "Detected that extraction must be performed.");
            listPerformExtractions = performExtractions(file2, file);
            putStoredApkInfo(context, getTimeStamp(file2), zipCrc, listPerformExtractions.size() + 1);
        }
        Log.i("MultiDex", "load found " + listPerformExtractions.size() + " secondary dex files");
        return listPerformExtractions;
    }

    private static List loadExistingExtractions(Context context, File file, File file2) throws IOException {
        Log.i("MultiDex", "loading existing secondary dex files");
        String str = file.getName() + ".classes";
        int i = getMultiDexPreferences(context).getInt("dex.number", 1);
        ArrayList arrayList = new ArrayList(i);
        for (int i2 = 2; i2 <= i; i2++) {
            File file3 = new File(file2, str + i2 + ".zip");
            if (file3.isFile()) {
                arrayList.add(file3);
                if (!verifyZipFile(file3)) {
                    Log.i("MultiDex", "Invalid zip file: " + file3);
                    throw new IOException("Invalid ZIP file.");
                }
            } else {
                throw new IOException("Missing extracted secondary dex file '" + file3.getPath() + "'");
            }
        }
        return arrayList;
    }

    private static boolean isModified(Context context, File file, long j) {
        SharedPreferences multiDexPreferences = getMultiDexPreferences(context);
        return (multiDexPreferences.getLong("timestamp", -1L) == getTimeStamp(file) && multiDexPreferences.getLong("crc", -1L) == j) ? false : true;
    }

    private static long getTimeStamp(File file) {
        long jLastModified = file.lastModified();
        return jLastModified == -1 ? jLastModified - 1 : jLastModified;
    }

    private static long getZipCrc(File file) throws IOException {
        long zipCrc = ZipUtil.getZipCrc(file);
        return zipCrc == -1 ? zipCrc - 1 : zipCrc;
    }

    private static List performExtractions(File file, File file2) throws IOException {
        String str = file.getName() + ".classes";
        prepareDexDir(file2, str);
        ArrayList arrayList = new ArrayList();
        ZipFile zipFile = new ZipFile(file);
        try {
            StringBuilder sb = new StringBuilder();
            sb.append("classes");
            int i = 2;
            sb.append(2);
            sb.append(".dex");
            ZipEntry entry = zipFile.getEntry(sb.toString());
            while (entry != null) {
                File file3 = new File(file2, str + i + ".zip");
                arrayList.add(file3);
                Log.i("MultiDex", "Extraction is needed for file " + file3);
                int i2 = 0;
                boolean zVerifyZipFile = false;
                while (i2 < 3 && !zVerifyZipFile) {
                    i2++;
                    extract(zipFile, entry, file3, str);
                    zVerifyZipFile = verifyZipFile(file3);
                    StringBuilder sb2 = new StringBuilder();
                    sb2.append("Extraction ");
                    sb2.append(zVerifyZipFile ? "success" : "failed");
                    sb2.append(" - length ");
                    sb2.append(file3.getAbsolutePath());
                    sb2.append(": ");
                    sb2.append(file3.length());
                    Log.i("MultiDex", sb2.toString());
                    if (!zVerifyZipFile) {
                        file3.delete();
                        if (file3.exists()) {
                            Log.w("MultiDex", "Failed to delete corrupted secondary dex '" + file3.getPath() + "'");
                        }
                    }
                }
                if (!zVerifyZipFile) {
                    throw new IOException("Could not create zip file " + file3.getAbsolutePath() + " for secondary dex (" + i + ")");
                }
                i++;
                entry = zipFile.getEntry("classes" + i + ".dex");
            }
            try {
                zipFile.close();
                return arrayList;
            } catch (IOException e) {
                Log.w("MultiDex", "Failed to close resource", e);
                return arrayList;
            }
        } catch (Throwable th) {
            try {
                zipFile.close();
            } catch (IOException e2) {
                Log.w("MultiDex", "Failed to close resource", e2);
            }
            throw th;
        }
    }

    private static void putStoredApkInfo(Context context, long j, long j2, int i) {
        SharedPreferences.Editor editorEdit = getMultiDexPreferences(context).edit();
        editorEdit.putLong("timestamp", j);
        editorEdit.putLong("crc", j2);
        editorEdit.putInt("dex.number", i);
        apply(editorEdit);
    }

    private static SharedPreferences getMultiDexPreferences(Context context) {
        return context.getSharedPreferences("multidex.version", 4);
    }

    private static void prepareDexDir(File file, final String str) throws IOException {
        mkdirChecked(file.getParentFile());
        mkdirChecked(file);
        File[] fileArrListFiles = file.listFiles(new FileFilter() { // from class: android.support.multidex.MultiDexExtractor.1
            @Override // java.io.FileFilter
            public boolean accept(File file2) {
                return !file2.getName().startsWith(str);
            }
        });
        if (fileArrListFiles == null) {
            Log.w("MultiDex", "Failed to list secondary dex dir content (" + file.getPath() + ").");
            return;
        }
        for (File file2 : fileArrListFiles) {
            Log.i("MultiDex", "Trying to delete old file " + file2.getPath() + " of size " + file2.length());
            if (!file2.delete()) {
                Log.w("MultiDex", "Failed to delete old file " + file2.getPath());
            } else {
                Log.i("MultiDex", "Deleted old file " + file2.getPath());
            }
        }
    }

    private static void mkdirChecked(File file) throws IOException {
        file.mkdir();
        if (file.isDirectory()) {
            return;
        }
        File parentFile = file.getParentFile();
        if (parentFile == null) {
            Log.e("MultiDex", "Failed to create dir " + file.getPath() + ". Parent file is null.");
        } else {
            Log.e("MultiDex", "Failed to create dir " + file.getPath() + ". parent file is a dir " + parentFile.isDirectory() + ", a file " + parentFile.isFile() + ", exists " + parentFile.exists() + ", readable " + parentFile.canRead() + ", writable " + parentFile.canWrite());
        }
        throw new IOException("Failed to create cache directory " + file.getPath());
    }

    private static void extract(ZipFile zipFile, ZipEntry zipEntry, File file, String str) throws IOException {
        InputStream inputStream = zipFile.getInputStream(zipEntry);
        File fileCreateTempFile = File.createTempFile(str, ".zip", file.getParentFile());
        Log.i("MultiDex", "Extracting " + fileCreateTempFile.getPath());
        try {
            ZipOutputStream zipOutputStream = new ZipOutputStream(new BufferedOutputStream(new FileOutputStream(fileCreateTempFile)));
            try {
                ZipEntry zipEntry2 = new ZipEntry("classes.dex");
                zipEntry2.setTime(zipEntry.getTime());
                zipOutputStream.putNextEntry(zipEntry2);
                byte[] bArr = new byte[16384];
                for (int i = inputStream.read(bArr); i != -1; i = inputStream.read(bArr)) {
                    zipOutputStream.write(bArr, 0, i);
                }
                zipOutputStream.closeEntry();
                zipOutputStream.close();
                Log.i("MultiDex", "Renaming to " + file.getPath());
                if (!fileCreateTempFile.renameTo(file)) {
                    throw new IOException("Failed to rename \"" + fileCreateTempFile.getAbsolutePath() + "\" to \"" + file.getAbsolutePath() + "\"");
                }
                closeQuietly(inputStream);
                fileCreateTempFile.delete();
            } catch (Throwable th) {
                zipOutputStream.close();
                throw th;
            }
        } catch (Throwable th2) {
            closeQuietly(inputStream);
            fileCreateTempFile.delete();
            throw th2;
        }
    }

    static boolean verifyZipFile(File file) {
        try {
            try {
                new ZipFile(file).close();
                return true;
            } catch (IOException unused) {
                Log.w("MultiDex", "Failed to close zip file: " + file.getAbsolutePath());
                return false;
            }
        } catch (ZipException e) {
            Log.w("MultiDex", "File " + file.getAbsolutePath() + " is not a valid zip file.", e);
            return false;
        } catch (IOException e2) {
            Log.w("MultiDex", "Got an IOException trying to open zip file: " + file.getAbsolutePath(), e2);
            return false;
        }
    }

    private static void closeQuietly(Closeable closeable) {
        try {
            closeable.close();
        } catch (IOException e) {
            Log.w("MultiDex", "Failed to close resource", e);
        }
    }

    static {
        try {
            sApplyMethod = SharedPreferences.Editor.class.getMethod("apply", null);
        } catch (NoSuchMethodException unused) {
            sApplyMethod = null;
        }
    }

    private static void apply(SharedPreferences.Editor editor) {
        Method method = sApplyMethod;
        if (method != null) {
            try {
                method.invoke(editor, null);
                return;
            } catch (IllegalAccessException | InvocationTargetException unused) {
            }
        }
        editor.commit();
    }
}
