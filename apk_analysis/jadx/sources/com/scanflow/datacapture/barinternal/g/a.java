package com.scanflow.datacapture.barinternal.g;

import com.scanflow.datacapture.barinternal.i.f;
import com.scanflow.datacapture.model.subscription.SubscriptionResponse;
import java.util.HashMap;
import okhttp3.MultipartBody;
import okhttp3.RequestBody;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.Header;
import retrofit2.http.Multipart;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Part;
import retrofit2.http.PartMap;

/* JADX INFO: loaded from: classes3.dex */
public interface a {
    @POST("LicenseKey/ValidateLicenseKey")
    Call<SubscriptionResponse> a(@Header("AuthKey") String str, @Body HashMap<String, String> map);

    @PUT("/optiscan/uploadfile")
    @Multipart
    Call<f> a(@Part MultipartBody.Part part, @PartMap HashMap<String, RequestBody> map);
}
