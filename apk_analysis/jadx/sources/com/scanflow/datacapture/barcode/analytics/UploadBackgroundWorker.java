package com.scanflow.datacapture.barcode.analytics;

import android.content.Context;
import androidx.work.Data;
import androidx.work.ListenableWorker;
import androidx.work.Worker;
import androidx.work.WorkerParameters;
import com.scanflow.datacapture.barinternal.InterfaceC0073a;
import com.scanflow.datacapture.barinternal.S;
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
public final class UploadBackgroundWorker extends Worker {
    public static final /* synthetic */ int e = 0;
    public InterfaceC0073a a;
    public String b;
    public String c;
    public String d;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public UploadBackgroundWorker(Context context, WorkerParameters workerParameters) {
        super(context, workerParameters);
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(workerParameters, "workerParameters");
        this.b = "";
        this.c = "";
        this.d = "";
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // androidx.work.Worker
    public final ListenableWorker.Result doWork() {
        Intrinsics.checkNotNullParameter("https://datacenter.scanflow.ai", "apiUrl");
        HttpLoggingInterceptor httpLoggingInterceptor = new HttpLoggingInterceptor(null, 1, 0 == true ? 1 : 0);
        httpLoggingInterceptor.setLevel(HttpLoggingInterceptor.Level.NONE);
        OkHttpClient.Builder builder = new OkHttpClient.Builder();
        TimeUnit timeUnit = TimeUnit.SECONDS;
        InterfaceC0073a interfaceC0073a = (InterfaceC0073a) new Retrofit.Builder().baseUrl("https://datacenter.scanflow.ai").client(builder.connectTimeout(20L, timeUnit).writeTimeout(20L, timeUnit).readTimeout(30L, timeUnit).addInterceptor(httpLoggingInterceptor).build()).addConverterFactory(GsonConverterFactory.create()).build().create(InterfaceC0073a.class);
        Intrinsics.checkNotNull(interfaceC0073a);
        this.a = interfaceC0073a;
        this.b = getInputData().getString("userId");
        this.c = getInputData().getString("useCase");
        this.d = getInputData().getString("imgPath");
        File file = new File(this.d);
        try {
            HashMap<String, RequestBody> map = new HashMap<>();
            RequestBody.Companion companion = RequestBody.Companion;
            MediaType.Companion companion2 = MediaType.Companion;
            MultipartBody.Part partCreateFormData = MultipartBody.Part.Companion.createFormData("file", file.getName(), companion.create(file, companion2.parse("multipart/form-data")));
            String str = this.b;
            Intrinsics.checkNotNull(str);
            RequestBody requestBodyCreate = companion.create(str, companion2.parse("text/plain"));
            String str2 = this.c;
            Intrinsics.checkNotNull(str2);
            RequestBody requestBodyCreate2 = companion.create(str2, companion2.parse("text/plain"));
            map.put("userId", requestBodyCreate);
            map.put("useCase", requestBodyCreate2);
            InterfaceC0073a interfaceC0073a2 = this.a;
            if (interfaceC0073a2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("apiService");
                interfaceC0073a2 = null;
            }
            interfaceC0073a2.a(partCreateFormData, map).enqueue(new S(file, this));
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
