package com.scanflow.datacapture.analytics;

import android.content.Context;
import androidx.work.Data;
import androidx.work.ListenableWorker;
import androidx.work.Worker;
import androidx.work.WorkerParameters;
import com.scanflow.datacapture.barinternal.g.a;
import com.scanflow.datacapture.barinternal.i.f;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import java.io.File;
import java.util.HashMap;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.Intrinsics;
import okhttp3.MediaType;
import okhttp3.MultipartBody;
import okhttp3.OkHttpClient;
import okhttp3.RequestBody;
import okhttp3.logging.HttpLoggingInterceptor;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/* JADX INFO: loaded from: classes3.dex */
public final class BackgroundWorker extends Worker {
    public a a;
    public f b;
    public String c;
    public String d;
    public String e;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public BackgroundWorker(Context context, WorkerParameters workerParameters) {
        super(context, workerParameters);
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(workerParameters, "workerParameters");
        this.c = "";
        this.d = "";
        this.e = "";
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // androidx.work.Worker
    public final ListenableWorker.Result doWork() {
        Intrinsics.checkNotNullParameter("https://datacenter.scanflow.ai", "apiUrl");
        HttpLoggingInterceptor httpLoggingInterceptor = new HttpLoggingInterceptor(null, 1, 0 == true ? 1 : 0);
        httpLoggingInterceptor.setLevel(HttpLoggingInterceptor.Level.NONE);
        OkHttpClient.Builder builder = new OkHttpClient.Builder();
        TimeUnit timeUnit = TimeUnit.SECONDS;
        a aVar = (a) new Retrofit.Builder().baseUrl("https://datacenter.scanflow.ai").client(builder.connectTimeout(60L, timeUnit).writeTimeout(60L, timeUnit).readTimeout(60L, timeUnit).addInterceptor(httpLoggingInterceptor).build()).addConverterFactory(GsonConverterFactory.create()).build().create(a.class);
        Intrinsics.checkNotNull(aVar);
        this.a = aVar;
        this.c = getInputData().getString("userId");
        this.d = getInputData().getString("useCase");
        this.e = getInputData().getString("imgPath");
        File file = new File(this.e);
        try {
            HashMap<String, RequestBody> map = new HashMap<>();
            RequestBody.Companion companion = RequestBody.Companion;
            MediaType.Companion companion2 = MediaType.Companion;
            MultipartBody.Part partCreateFormData = MultipartBody.Part.Companion.createFormData("file", file.getName(), companion.create(file, companion2.parse("multipart/form-data")));
            String str = this.c;
            Intrinsics.checkNotNull(str);
            RequestBody requestBodyCreate = companion.create(str, companion2.parse("text/plain"));
            String str2 = this.d;
            Intrinsics.checkNotNull(str2);
            RequestBody requestBodyCreate2 = companion.create(str2, companion2.parse("text/plain"));
            map.put("userId", requestBodyCreate);
            map.put("useCase", requestBodyCreate2);
            a aVar2 = this.a;
            if (aVar2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("apiService");
                aVar2 = null;
            }
            aVar2.a(partCreateFormData, map).enqueue(new com.scanflow.datacapture.barinternal.a.a(this, file));
        } catch (Exception unused) {
            file.delete();
        }
        Pair[] pairArr = {TuplesKt.to("uploadsuccess", null)};
        Data.Builder builder2 = new Data.Builder();
        Pair pair = pairArr[0];
        builder2.put((String) pair.getFirst(), pair.getSecond());
        Data dataBuild = builder2.build();
        Intrinsics.checkNotNullExpressionValue(dataBuild, "dataBuilder.build()");
        ListenableWorker.Result resultSuccess = ListenableWorker.Result.success(dataBuild);
        Intrinsics.checkNotNullExpressionValue(resultSuccess, "success(...)");
        return resultSuccess;
    }
}
