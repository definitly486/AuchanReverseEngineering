package com.scanflow.datacapture.barinternal;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.charset.Charset;
import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.Iterator;
import javax.crypto.Cipher;
import javax.crypto.CipherInputStream;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.GCMParameterSpec;
import javax.crypto.spec.SecretKeySpec;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.m, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0095m {
    public static File a(Context activity, String KEY) throws NoSuchPaddingException, NoSuchAlgorithmException, IOException, InvalidKeyException, InvalidAlgorithmParameterException {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(KEY, "KEY");
        ArrayList arrayList = new ArrayList();
        for (int i = 1; i < 13; i++) {
            if (i == 12) {
                File file = t.a(activity, "epart11.tflite");
                Intrinsics.checkNotNullParameter(activity, "activity");
                Intrinsics.checkNotNullParameter(file, "file");
                Intrinsics.checkNotNullParameter(KEY, "KEY");
                File file2 = new File(activity.getCacheDir(), "part11.tflite");
                FileInputStream fileInputStream = new FileInputStream(file);
                FileOutputStream fileOutputStream = new FileOutputStream(file2);
                Charset charset = Charsets.UTF_8;
                byte[] bytes = KEY.getBytes(charset);
                Intrinsics.checkNotNullExpressionValue(bytes, "getBytes(...)");
                SecretKeySpec secretKeySpec = new SecretKeySpec(bytes, "AES");
                Cipher cipher = Cipher.getInstance("AES/GCM/NoPadding");
                byte[] bytes2 = KEY.getBytes(charset);
                Intrinsics.checkNotNullExpressionValue(bytes2, "getBytes(...)");
                cipher.init(2, secretKeySpec, new GCMParameterSpec(128, bytes2));
                CipherInputStream cipherInputStream = new CipherInputStream(fileInputStream, cipher);
                byte[] bArr = new byte[8];
                while (true) {
                    int i2 = cipherInputStream.read(bArr);
                    if (i2 == -1) {
                        break;
                    }
                    fileOutputStream.write(bArr, 0, i2);
                }
                fileOutputStream.flush();
                fileOutputStream.close();
                cipherInputStream.close();
                arrayList.add(file2);
            } else {
                StringBuilder sb = new StringBuilder("part");
                sb.append(i - 1);
                sb.append(".tflite");
                arrayList.add(new File(t.a(activity, sb.toString()).getPath()));
            }
        }
        try {
            return a(activity, arrayList);
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public static File a(Context activity, ArrayList files) throws IOException {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(files, "files");
        File file = new File(activity.getCacheDir(), "efficientdet-lite2_1.0.5.tflite");
        BufferedOutputStream bufferedOutputStream = new BufferedOutputStream(new FileOutputStream(file));
        Iterator it = files.iterator();
        Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
        while (it.hasNext()) {
            Object next = it.next();
            Intrinsics.checkNotNullExpressionValue(next, "next(...)");
            RandomAccessFile randomAccessFile = new RandomAccessFile((File) next, "r");
            long j = 8192;
            long length = randomAccessFile.length() / j;
            long length2 = randomAccessFile.length() % j;
            for (long j2 = 0; j2 < length; j2++) {
                byte[] bArr = new byte[(int) j];
                if (randomAccessFile.read(bArr) != -1) {
                    bufferedOutputStream.write(bArr);
                }
            }
            if (length2 > 0) {
                byte[] bArr2 = new byte[(int) length2];
                if (randomAccessFile.read(bArr2) != -1) {
                    bufferedOutputStream.write(bArr2);
                }
            }
            randomAccessFile.close();
        }
        bufferedOutputStream.close();
        return file;
    }
}
