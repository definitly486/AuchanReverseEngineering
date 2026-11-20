package com.scanflow.datacapture.barinternal;

import java.util.HashMap;
import okhttp3.MultipartBody;
import okhttp3.RequestBody;
import retrofit2.Call;
import retrofit2.http.Multipart;
import retrofit2.http.PUT;
import retrofit2.http.Part;
import retrofit2.http.PartMap;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.a, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public interface InterfaceC0073a {
    @PUT("/optiscan/uploadfile")
    @Multipart
    Call<Object> a(@Part MultipartBody.Part part, @PartMap HashMap<String, RequestBody> map);
}
