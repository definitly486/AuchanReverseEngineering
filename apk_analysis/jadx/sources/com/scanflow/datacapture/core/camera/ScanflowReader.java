package com.scanflow.datacapture.core.camera;

import android.graphics.Bitmap;
import android.util.Size;
import android.view.View;
import com.google.android.material.slider.Slider;
import com.scanflow.datacapture.barinternal.c.a;
import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import com.scanflow.datacapture.config.VinNumberColorConfig;
import com.scanflow.datacapture.core.camera.manager.BeepManager;
import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import com.scanflow.datacapture.model.ScanResultSuccess;
import java.util.ArrayList;
import java.util.HashSet;
import kotlin.enums.EnumEntries;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ScanflowReader implements ICamera, ICameraControl {
    private static int LENS_FACING_FRONT;
    public static final Companion Companion = new Companion(null);
    private static String SCAN_RESULT = "SCAN_RESULT";
    private static int LENS_FACING_BACK = 1;

    public enum CameraResolutionConfig {
        SD_480P(new Size(480, 640)),
        HD_720P(new Size(720, 1280)),
        FULL_HD_1080P(new Size(1080, 1920)),
        UHD_4K(new Size(2160, 3840));

        private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());
        private final Size size;

        CameraResolutionConfig(Size size) {
            this.size = size;
        }

        public static EnumEntries<CameraResolutionConfig> getEntries() {
            return $ENTRIES;
        }

        public final Size getSize() {
            return this.size;
        }
    }

    public static final class CameraUserConfig {
        private final boolean autoZoom;
        private final Integer beepSoundResource;
        private int echanceTextCount;
        private final boolean enableTireAngleDetection;
        private final boolean enableTirePreProcessing;
        private final boolean isContinuousScan;
        private final boolean isDataTracking;
        private boolean isEnhanceTextResult;
        private final boolean isNetworkAvailable;
        private final boolean isOneTouchZoomEnabled;
        private final boolean isPerformCaptureScan;
        private double latitudeObj;
        private final String licenseInfo;
        private double longitudeObj;
        private final BeepManager mBeepManager;
        private final boolean playBeep;
        private final Size selectedResolution;
        private VinNumberColorConfig selectedVinNumberColorConfig;
        private final String switchCategory;
        private final boolean vibrate;

        public CameraUserConfig(boolean z, boolean z2, boolean z3, boolean z4, Size selectedResolution, boolean z5, BeepManager beepManager, String licenseInfo, Integer num, boolean z6, boolean z7, boolean z8, boolean z9, boolean z10, double d, double d2, boolean z11, int i, VinNumberColorConfig selectedVinNumberColorConfig, String switchCategory) {
            Intrinsics.checkNotNullParameter(selectedResolution, "selectedResolution");
            Intrinsics.checkNotNullParameter(licenseInfo, "licenseInfo");
            Intrinsics.checkNotNullParameter(selectedVinNumberColorConfig, "selectedVinNumberColorConfig");
            Intrinsics.checkNotNullParameter(switchCategory, "switchCategory");
            this.isContinuousScan = z;
            this.isPerformCaptureScan = z2;
            this.autoZoom = z3;
            this.isOneTouchZoomEnabled = z4;
            this.selectedResolution = selectedResolution;
            this.isNetworkAvailable = z5;
            this.mBeepManager = beepManager;
            this.licenseInfo = licenseInfo;
            this.beepSoundResource = num;
            this.playBeep = z6;
            this.vibrate = z7;
            this.isDataTracking = z8;
            this.enableTirePreProcessing = z9;
            this.enableTireAngleDetection = z10;
            this.latitudeObj = d;
            this.longitudeObj = d2;
            this.isEnhanceTextResult = z11;
            this.echanceTextCount = i;
            this.selectedVinNumberColorConfig = selectedVinNumberColorConfig;
            this.switchCategory = switchCategory;
        }

        public static /* synthetic */ CameraUserConfig copy$default(CameraUserConfig cameraUserConfig, boolean z, boolean z2, boolean z3, boolean z4, Size size, boolean z5, BeepManager beepManager, String str, Integer num, boolean z6, boolean z7, boolean z8, boolean z9, boolean z10, double d, double d2, boolean z11, int i, VinNumberColorConfig vinNumberColorConfig, String str2, int i2, Object obj) {
            String str3;
            VinNumberColorConfig vinNumberColorConfig2;
            boolean z12 = (i2 & 1) != 0 ? cameraUserConfig.isContinuousScan : z;
            boolean z13 = (i2 & 2) != 0 ? cameraUserConfig.isPerformCaptureScan : z2;
            boolean z14 = (i2 & 4) != 0 ? cameraUserConfig.autoZoom : z3;
            boolean z15 = (i2 & 8) != 0 ? cameraUserConfig.isOneTouchZoomEnabled : z4;
            Size size2 = (i2 & 16) != 0 ? cameraUserConfig.selectedResolution : size;
            boolean z16 = (i2 & 32) != 0 ? cameraUserConfig.isNetworkAvailable : z5;
            BeepManager beepManager2 = (i2 & 64) != 0 ? cameraUserConfig.mBeepManager : beepManager;
            String str4 = (i2 & 128) != 0 ? cameraUserConfig.licenseInfo : str;
            Integer num2 = (i2 & 256) != 0 ? cameraUserConfig.beepSoundResource : num;
            boolean z17 = (i2 & 512) != 0 ? cameraUserConfig.playBeep : z6;
            boolean z18 = (i2 & 1024) != 0 ? cameraUserConfig.vibrate : z7;
            boolean z19 = (i2 & 2048) != 0 ? cameraUserConfig.isDataTracking : z8;
            boolean z20 = (i2 & 4096) != 0 ? cameraUserConfig.enableTirePreProcessing : z9;
            boolean z21 = (i2 & 8192) != 0 ? cameraUserConfig.enableTireAngleDetection : z10;
            boolean z22 = z12;
            double d3 = (i2 & 16384) != 0 ? cameraUserConfig.latitudeObj : d;
            double d4 = (i2 & 32768) != 0 ? cameraUserConfig.longitudeObj : d2;
            boolean z23 = (i2 & 65536) != 0 ? cameraUserConfig.isEnhanceTextResult : z11;
            int i3 = (i2 & 131072) != 0 ? cameraUserConfig.echanceTextCount : i;
            boolean z24 = z23;
            VinNumberColorConfig vinNumberColorConfig3 = (i2 & 262144) != 0 ? cameraUserConfig.selectedVinNumberColorConfig : vinNumberColorConfig;
            if ((i2 & 524288) != 0) {
                vinNumberColorConfig2 = vinNumberColorConfig3;
                str3 = cameraUserConfig.switchCategory;
            } else {
                str3 = str2;
                vinNumberColorConfig2 = vinNumberColorConfig3;
            }
            return cameraUserConfig.copy(z22, z13, z14, z15, size2, z16, beepManager2, str4, num2, z17, z18, z19, z20, z21, d3, d4, z24, i3, vinNumberColorConfig2, str3);
        }

        public final boolean component1() {
            return this.isContinuousScan;
        }

        public final boolean component10() {
            return this.playBeep;
        }

        public final boolean component11() {
            return this.vibrate;
        }

        public final boolean component12() {
            return this.isDataTracking;
        }

        public final boolean component13() {
            return this.enableTirePreProcessing;
        }

        public final boolean component14() {
            return this.enableTireAngleDetection;
        }

        public final double component15() {
            return this.latitudeObj;
        }

        public final double component16() {
            return this.longitudeObj;
        }

        public final boolean component17() {
            return this.isEnhanceTextResult;
        }

        public final int component18() {
            return this.echanceTextCount;
        }

        public final VinNumberColorConfig component19() {
            return this.selectedVinNumberColorConfig;
        }

        public final boolean component2() {
            return this.isPerformCaptureScan;
        }

        public final String component20() {
            return this.switchCategory;
        }

        public final boolean component3() {
            return this.autoZoom;
        }

        public final boolean component4() {
            return this.isOneTouchZoomEnabled;
        }

        public final Size component5() {
            return this.selectedResolution;
        }

        public final boolean component6() {
            return this.isNetworkAvailable;
        }

        public final BeepManager component7() {
            return this.mBeepManager;
        }

        public final String component8() {
            return this.licenseInfo;
        }

        public final Integer component9() {
            return this.beepSoundResource;
        }

        public final CameraUserConfig copy(boolean z, boolean z2, boolean z3, boolean z4, Size selectedResolution, boolean z5, BeepManager beepManager, String licenseInfo, Integer num, boolean z6, boolean z7, boolean z8, boolean z9, boolean z10, double d, double d2, boolean z11, int i, VinNumberColorConfig selectedVinNumberColorConfig, String switchCategory) {
            Intrinsics.checkNotNullParameter(selectedResolution, "selectedResolution");
            Intrinsics.checkNotNullParameter(licenseInfo, "licenseInfo");
            Intrinsics.checkNotNullParameter(selectedVinNumberColorConfig, "selectedVinNumberColorConfig");
            Intrinsics.checkNotNullParameter(switchCategory, "switchCategory");
            return new CameraUserConfig(z, z2, z3, z4, selectedResolution, z5, beepManager, licenseInfo, num, z6, z7, z8, z9, z10, d, d2, z11, i, selectedVinNumberColorConfig, switchCategory);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof CameraUserConfig)) {
                return false;
            }
            CameraUserConfig cameraUserConfig = (CameraUserConfig) obj;
            return this.isContinuousScan == cameraUserConfig.isContinuousScan && this.isPerformCaptureScan == cameraUserConfig.isPerformCaptureScan && this.autoZoom == cameraUserConfig.autoZoom && this.isOneTouchZoomEnabled == cameraUserConfig.isOneTouchZoomEnabled && Intrinsics.areEqual(this.selectedResolution, cameraUserConfig.selectedResolution) && this.isNetworkAvailable == cameraUserConfig.isNetworkAvailable && Intrinsics.areEqual(this.mBeepManager, cameraUserConfig.mBeepManager) && Intrinsics.areEqual(this.licenseInfo, cameraUserConfig.licenseInfo) && Intrinsics.areEqual(this.beepSoundResource, cameraUserConfig.beepSoundResource) && this.playBeep == cameraUserConfig.playBeep && this.vibrate == cameraUserConfig.vibrate && this.isDataTracking == cameraUserConfig.isDataTracking && this.enableTirePreProcessing == cameraUserConfig.enableTirePreProcessing && this.enableTireAngleDetection == cameraUserConfig.enableTireAngleDetection && Double.compare(this.latitudeObj, cameraUserConfig.latitudeObj) == 0 && Double.compare(this.longitudeObj, cameraUserConfig.longitudeObj) == 0 && this.isEnhanceTextResult == cameraUserConfig.isEnhanceTextResult && this.echanceTextCount == cameraUserConfig.echanceTextCount && this.selectedVinNumberColorConfig == cameraUserConfig.selectedVinNumberColorConfig && Intrinsics.areEqual(this.switchCategory, cameraUserConfig.switchCategory);
        }

        public final boolean getAutoZoom() {
            return this.autoZoom;
        }

        public final Integer getBeepSoundResource() {
            return this.beepSoundResource;
        }

        public final int getEchanceTextCount() {
            return this.echanceTextCount;
        }

        public final boolean getEnableTireAngleDetection() {
            return this.enableTireAngleDetection;
        }

        public final boolean getEnableTirePreProcessing() {
            return this.enableTirePreProcessing;
        }

        public final double getLatitudeObj() {
            return this.latitudeObj;
        }

        public final String getLicenseInfo() {
            return this.licenseInfo;
        }

        public final double getLongitudeObj() {
            return this.longitudeObj;
        }

        public final BeepManager getMBeepManager() {
            return this.mBeepManager;
        }

        public final boolean getPlayBeep() {
            return this.playBeep;
        }

        public final Size getSelectedResolution() {
            return this.selectedResolution;
        }

        public final VinNumberColorConfig getSelectedVinNumberColorConfig() {
            return this.selectedVinNumberColorConfig;
        }

        public final String getSwitchCategory() {
            return this.switchCategory;
        }

        public final boolean getVibrate() {
            return this.vibrate;
        }

        public int hashCode() {
            int iA = a.a(this.isNetworkAvailable, (this.selectedResolution.hashCode() + a.a(this.isOneTouchZoomEnabled, a.a(this.autoZoom, a.a(this.isPerformCaptureScan, Boolean.hashCode(this.isContinuousScan) * 31, 31), 31), 31)) * 31, 31);
            BeepManager beepManager = this.mBeepManager;
            int iHashCode = (this.licenseInfo.hashCode() + ((iA + (beepManager == null ? 0 : beepManager.hashCode())) * 31)) * 31;
            Integer num = this.beepSoundResource;
            return this.switchCategory.hashCode() + ((this.selectedVinNumberColorConfig.hashCode() + ((Integer.hashCode(this.echanceTextCount) + a.a(this.isEnhanceTextResult, (Double.hashCode(this.longitudeObj) + ((Double.hashCode(this.latitudeObj) + a.a(this.enableTireAngleDetection, a.a(this.enableTirePreProcessing, a.a(this.isDataTracking, a.a(this.vibrate, a.a(this.playBeep, (iHashCode + (num != null ? num.hashCode() : 0)) * 31, 31), 31), 31), 31), 31)) * 31)) * 31, 31)) * 31)) * 31);
        }

        public final boolean isContinuousScan() {
            return this.isContinuousScan;
        }

        public final boolean isDataTracking() {
            return this.isDataTracking;
        }

        public final boolean isEnhanceTextResult() {
            return this.isEnhanceTextResult;
        }

        public final boolean isNetworkAvailable() {
            return this.isNetworkAvailable;
        }

        public final boolean isOneTouchZoomEnabled() {
            return this.isOneTouchZoomEnabled;
        }

        public final boolean isPerformCaptureScan() {
            return this.isPerformCaptureScan;
        }

        public final void setEchanceTextCount(int i) {
            this.echanceTextCount = i;
        }

        public final void setEnhanceTextResult(boolean z) {
            this.isEnhanceTextResult = z;
        }

        public final void setLatitudeObj(double d) {
            this.latitudeObj = d;
        }

        public final void setLongitudeObj(double d) {
            this.longitudeObj = d;
        }

        public final void setSelectedVinNumberColorConfig(VinNumberColorConfig vinNumberColorConfig) {
            Intrinsics.checkNotNullParameter(vinNumberColorConfig, "<set-?>");
            this.selectedVinNumberColorConfig = vinNumberColorConfig;
        }

        public String toString() {
            return "CameraUserConfig(isContinuousScan=" + this.isContinuousScan + ", isPerformCaptureScan=" + this.isPerformCaptureScan + ", autoZoom=" + this.autoZoom + ", isOneTouchZoomEnabled=" + this.isOneTouchZoomEnabled + ", selectedResolution=" + this.selectedResolution + ", isNetworkAvailable=" + this.isNetworkAvailable + ", mBeepManager=" + this.mBeepManager + ", licenseInfo=" + this.licenseInfo + ", beepSoundResource=" + this.beepSoundResource + ", playBeep=" + this.playBeep + ", vibrate=" + this.vibrate + ", isDataTracking=" + this.isDataTracking + ", enableTirePreProcessing=" + this.enableTirePreProcessing + ", enableTireAngleDetection=" + this.enableTireAngleDetection + ", latitudeObj=" + this.latitudeObj + ", longitudeObj=" + this.longitudeObj + ", isEnhanceTextResult=" + this.isEnhanceTextResult + ", echanceTextCount=" + this.echanceTextCount + ", selectedVinNumberColorConfig=" + this.selectedVinNumberColorConfig + ", switchCategory=" + this.switchCategory + ')';
        }
    }

    public static final class Companion {
        private Companion() {
        }

        public final int getLENS_FACING_BACK() {
            return ScanflowReader.LENS_FACING_BACK;
        }

        public final int getLENS_FACING_FRONT() {
            return ScanflowReader.LENS_FACING_FRONT;
        }

        public final String getSCAN_RESULT() {
            return ScanflowReader.SCAN_RESULT;
        }

        public final void setLENS_FACING_BACK(int i) {
            ScanflowReader.LENS_FACING_BACK = i;
        }

        public final void setLENS_FACING_FRONT(int i) {
            ScanflowReader.LENS_FACING_FRONT = i;
        }

        public final void setSCAN_RESULT(String str) {
            Intrinsics.checkNotNullParameter(str, "<set-?>");
            ScanflowReader.SCAN_RESULT = str;
        }

        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }
    }

    public static final class IDCardScanResult {
        private String address;
        private Bitmap backImage;
        private String bloodGroup;
        private String dateOfIssue;
        private String dob;
        private String fathername;
        private Bitmap frontImage;
        private String name;
        private Bitmap profileImage;
        private String sex;
        private String uniqueId;
        private String validTill;
        private String year;

        public IDCardScanResult() {
            this(null, null, null, null, null, null, null, null, null, null, null, null, null, 8191, null);
        }

        public static /* synthetic */ IDCardScanResult copy$default(IDCardScanResult iDCardScanResult, String str, String str2, String str3, String str4, String str5, String str6, Bitmap bitmap, Bitmap bitmap2, Bitmap bitmap3, String str7, String str8, String str9, String str10, int i, Object obj) {
            if ((i & 1) != 0) {
                str = iDCardScanResult.dob;
            }
            return iDCardScanResult.copy(str, (i & 2) != 0 ? iDCardScanResult.uniqueId : str2, (i & 4) != 0 ? iDCardScanResult.name : str3, (i & 8) != 0 ? iDCardScanResult.sex : str4, (i & 16) != 0 ? iDCardScanResult.year : str5, (i & 32) != 0 ? iDCardScanResult.address : str6, (i & 64) != 0 ? iDCardScanResult.frontImage : bitmap, (i & 128) != 0 ? iDCardScanResult.backImage : bitmap2, (i & 256) != 0 ? iDCardScanResult.profileImage : bitmap3, (i & 512) != 0 ? iDCardScanResult.fathername : str7, (i & 1024) != 0 ? iDCardScanResult.dateOfIssue : str8, (i & 2048) != 0 ? iDCardScanResult.validTill : str9, (i & 4096) != 0 ? iDCardScanResult.bloodGroup : str10);
        }

        public final String component1() {
            return this.dob;
        }

        public final String component10() {
            return this.fathername;
        }

        public final String component11() {
            return this.dateOfIssue;
        }

        public final String component12() {
            return this.validTill;
        }

        public final String component13() {
            return this.bloodGroup;
        }

        public final String component2() {
            return this.uniqueId;
        }

        public final String component3() {
            return this.name;
        }

        public final String component4() {
            return this.sex;
        }

        public final String component5() {
            return this.year;
        }

        public final String component6() {
            return this.address;
        }

        public final Bitmap component7() {
            return this.frontImage;
        }

        public final Bitmap component8() {
            return this.backImage;
        }

        public final Bitmap component9() {
            return this.profileImage;
        }

        public final IDCardScanResult copy(String str, String str2, String str3, String str4, String str5, String str6, Bitmap bitmap, Bitmap bitmap2, Bitmap bitmap3, String str7, String str8, String str9, String str10) {
            return new IDCardScanResult(str, str2, str3, str4, str5, str6, bitmap, bitmap2, bitmap3, str7, str8, str9, str10);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof IDCardScanResult)) {
                return false;
            }
            IDCardScanResult iDCardScanResult = (IDCardScanResult) obj;
            return Intrinsics.areEqual(this.dob, iDCardScanResult.dob) && Intrinsics.areEqual(this.uniqueId, iDCardScanResult.uniqueId) && Intrinsics.areEqual(this.name, iDCardScanResult.name) && Intrinsics.areEqual(this.sex, iDCardScanResult.sex) && Intrinsics.areEqual(this.year, iDCardScanResult.year) && Intrinsics.areEqual(this.address, iDCardScanResult.address) && Intrinsics.areEqual(this.frontImage, iDCardScanResult.frontImage) && Intrinsics.areEqual(this.backImage, iDCardScanResult.backImage) && Intrinsics.areEqual(this.profileImage, iDCardScanResult.profileImage) && Intrinsics.areEqual(this.fathername, iDCardScanResult.fathername) && Intrinsics.areEqual(this.dateOfIssue, iDCardScanResult.dateOfIssue) && Intrinsics.areEqual(this.validTill, iDCardScanResult.validTill) && Intrinsics.areEqual(this.bloodGroup, iDCardScanResult.bloodGroup);
        }

        public final String getAddress() {
            return this.address;
        }

        public final Bitmap getBackImage() {
            return this.backImage;
        }

        public final String getBloodGroup() {
            return this.bloodGroup;
        }

        public final String getDateOfIssue() {
            return this.dateOfIssue;
        }

        public final String getDob() {
            return this.dob;
        }

        public final String getFathername() {
            return this.fathername;
        }

        public final Bitmap getFrontImage() {
            return this.frontImage;
        }

        public final String getName() {
            return this.name;
        }

        public final Bitmap getProfileImage() {
            return this.profileImage;
        }

        public final String getSex() {
            return this.sex;
        }

        public final String getUniqueId() {
            return this.uniqueId;
        }

        public final String getValidTill() {
            return this.validTill;
        }

        public final String getYear() {
            return this.year;
        }

        public int hashCode() {
            String str = this.dob;
            int iHashCode = (str == null ? 0 : str.hashCode()) * 31;
            String str2 = this.uniqueId;
            int iHashCode2 = (iHashCode + (str2 == null ? 0 : str2.hashCode())) * 31;
            String str3 = this.name;
            int iHashCode3 = (iHashCode2 + (str3 == null ? 0 : str3.hashCode())) * 31;
            String str4 = this.sex;
            int iHashCode4 = (iHashCode3 + (str4 == null ? 0 : str4.hashCode())) * 31;
            String str5 = this.year;
            int iHashCode5 = (iHashCode4 + (str5 == null ? 0 : str5.hashCode())) * 31;
            String str6 = this.address;
            int iHashCode6 = (iHashCode5 + (str6 == null ? 0 : str6.hashCode())) * 31;
            Bitmap bitmap = this.frontImage;
            int iHashCode7 = (iHashCode6 + (bitmap == null ? 0 : bitmap.hashCode())) * 31;
            Bitmap bitmap2 = this.backImage;
            int iHashCode8 = (iHashCode7 + (bitmap2 == null ? 0 : bitmap2.hashCode())) * 31;
            Bitmap bitmap3 = this.profileImage;
            int iHashCode9 = (iHashCode8 + (bitmap3 == null ? 0 : bitmap3.hashCode())) * 31;
            String str7 = this.fathername;
            int iHashCode10 = (iHashCode9 + (str7 == null ? 0 : str7.hashCode())) * 31;
            String str8 = this.dateOfIssue;
            int iHashCode11 = (iHashCode10 + (str8 == null ? 0 : str8.hashCode())) * 31;
            String str9 = this.validTill;
            int iHashCode12 = (iHashCode11 + (str9 == null ? 0 : str9.hashCode())) * 31;
            String str10 = this.bloodGroup;
            return iHashCode12 + (str10 != null ? str10.hashCode() : 0);
        }

        public final void setAddress(String str) {
            this.address = str;
        }

        public final void setBackImage(Bitmap bitmap) {
            this.backImage = bitmap;
        }

        public final void setBloodGroup(String str) {
            this.bloodGroup = str;
        }

        public final void setDateOfIssue(String str) {
            this.dateOfIssue = str;
        }

        public final void setDob(String str) {
            this.dob = str;
        }

        public final void setFathername(String str) {
            this.fathername = str;
        }

        public final void setFrontImage(Bitmap bitmap) {
            this.frontImage = bitmap;
        }

        public final void setName(String str) {
            this.name = str;
        }

        public final void setProfileImage(Bitmap bitmap) {
            this.profileImage = bitmap;
        }

        public final void setSex(String str) {
            this.sex = str;
        }

        public final void setUniqueId(String str) {
            this.uniqueId = str;
        }

        public final void setValidTill(String str) {
            this.validTill = str;
        }

        public final void setYear(String str) {
            this.year = str;
        }

        public String toString() {
            return super.toString();
        }

        public IDCardScanResult(String str, String str2, String str3, String str4, String str5, String str6, Bitmap bitmap, Bitmap bitmap2, Bitmap bitmap3, String str7, String str8, String str9, String str10) {
            this.dob = str;
            this.uniqueId = str2;
            this.name = str3;
            this.sex = str4;
            this.year = str5;
            this.address = str6;
            this.frontImage = bitmap;
            this.backImage = bitmap2;
            this.profileImage = bitmap3;
            this.fathername = str7;
            this.dateOfIssue = str8;
            this.validTill = str9;
            this.bloodGroup = str10;
        }

        public /* synthetic */ IDCardScanResult(String str, String str2, String str3, String str4, String str5, String str6, Bitmap bitmap, Bitmap bitmap2, Bitmap bitmap3, String str7, String str8, String str9, String str10, int i, DefaultConstructorMarker defaultConstructorMarker) {
            this((i & 1) != 0 ? null : str, (i & 2) != 0 ? null : str2, (i & 4) != 0 ? null : str3, (i & 8) != 0 ? null : str4, (i & 16) != 0 ? null : str5, (i & 32) != 0 ? null : str6, (i & 64) != 0 ? null : bitmap, (i & 128) != 0 ? null : bitmap2, (i & 256) != 0 ? null : bitmap3, (i & 512) != 0 ? null : str7, (i & 1024) != 0 ? null : str8, (i & 2048) != 0 ? null : str9, (i & 4096) != 0 ? null : str10);
        }
    }

    public interface OnBarcodeScanResultCallback {
        void onBatchScanResultSuccess(ArrayList<ScanResultSuccess> arrayList);

        void onOneOfManyCodeResult(HashSet<OneOFManyCodesScanResults> hashSet);

        void onOneofManyCodeRemoved(OneOFManyCodesScanResults oneOFManyCodesScanResults);

        void onOneofManyCodeSelected(OneOFManyCodesScanResults oneOFManyCodesScanResults);

        void onScanBarcodeDetection(boolean z);

        void onScanResultFailure(String str);

        void onScanResultSuccess(ScanResultSuccess scanResultSuccess);
    }

    public interface OnCameraResultCallback {
        void onScanResultFailure(String str);

        void onScanResultSuccess(Bitmap bitmap);
    }

    public interface OnIDCardScanResultCallback {
        void onScanResultSuccess(IDCardScanResult iDCardScanResult);
    }

    public interface OnLicenseValidationCallback {
        void onLicenseFailure(String str);

        void onLicenseSuccess(String str);
    }

    public interface OnOneTouchCallback {
        void onCompleted();

        void onStarted();
    }

    public interface OnTextComponentScanResultCallback {
        void onScanResultFailure(String str);

        void onScanResultSuccess(TextComponentScanResult textComponentScanResult);
    }

    public interface OnTextComponentVinPlateScanResultCallback {
        void onScanResultFailure(String str);

        void onScanResultStatus(VinPlateFullStatusResult vinPlateFullStatusResult);

        void onScanResultSuccess(VinPlateFullScanResult vinPlateFullScanResult);
    }

    public interface OnTextComponentVinStickerScanResultCallback {
        void onScanResultFailure(String str);

        void onScanResultStatus(VinStickerFullStatusResult vinStickerFullStatusResult);

        void onScanResultSuccess(VinStickerFullScanResult vinStickerFullScanResult);
    }

    public interface OnTextScanResultCallback {
        void onScanResultFailure(String str);

        void onScanResultSuccess(TextScanResult textScanResult);
    }

    public interface OnWebServiceScanResultCallback {
        void onScanResultFailure(String str);

        void onScanResultSuccess(WebServiceScanResult webServiceScanResult);
    }

    public static final class TextComponentScanResult {
        private Bitmap image;
        private ArrayList<String> suggestedResults;
        private String text;

        public TextComponentScanResult() {
            this(null, null, null, 7, null);
        }

        /* JADX WARN: Multi-variable type inference failed */
        public static /* synthetic */ TextComponentScanResult copy$default(TextComponentScanResult textComponentScanResult, String str, Bitmap bitmap, ArrayList arrayList, int i, Object obj) {
            if ((i & 1) != 0) {
                str = textComponentScanResult.text;
            }
            if ((i & 2) != 0) {
                bitmap = textComponentScanResult.image;
            }
            if ((i & 4) != 0) {
                arrayList = textComponentScanResult.suggestedResults;
            }
            return textComponentScanResult.copy(str, bitmap, arrayList);
        }

        public final String component1() {
            return this.text;
        }

        public final Bitmap component2() {
            return this.image;
        }

        public final ArrayList<String> component3() {
            return this.suggestedResults;
        }

        public final TextComponentScanResult copy(String str, Bitmap bitmap, ArrayList<String> suggestedResults) {
            Intrinsics.checkNotNullParameter(suggestedResults, "suggestedResults");
            return new TextComponentScanResult(str, bitmap, suggestedResults);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof TextComponentScanResult)) {
                return false;
            }
            TextComponentScanResult textComponentScanResult = (TextComponentScanResult) obj;
            return Intrinsics.areEqual(this.text, textComponentScanResult.text) && Intrinsics.areEqual(this.image, textComponentScanResult.image) && Intrinsics.areEqual(this.suggestedResults, textComponentScanResult.suggestedResults);
        }

        public final Bitmap getImage() {
            return this.image;
        }

        public final ArrayList<String> getSuggestedResults() {
            return this.suggestedResults;
        }

        public final String getText() {
            return this.text;
        }

        public int hashCode() {
            String str = this.text;
            int iHashCode = (str == null ? 0 : str.hashCode()) * 31;
            Bitmap bitmap = this.image;
            return this.suggestedResults.hashCode() + ((iHashCode + (bitmap != null ? bitmap.hashCode() : 0)) * 31);
        }

        public final void setImage(Bitmap bitmap) {
            this.image = bitmap;
        }

        public final void setSuggestedResults(ArrayList<String> arrayList) {
            Intrinsics.checkNotNullParameter(arrayList, "<set-?>");
            this.suggestedResults = arrayList;
        }

        public final void setText(String str) {
            this.text = str;
        }

        public String toString() {
            return "TextComponentScanResult(text=" + this.text + ", image=" + this.image + ", suggestedResults=" + this.suggestedResults + ')';
        }

        public TextComponentScanResult(String str, Bitmap bitmap, ArrayList<String> suggestedResults) {
            Intrinsics.checkNotNullParameter(suggestedResults, "suggestedResults");
            this.text = str;
            this.image = bitmap;
            this.suggestedResults = suggestedResults;
        }

        public /* synthetic */ TextComponentScanResult(String str, Bitmap bitmap, ArrayList arrayList, int i, DefaultConstructorMarker defaultConstructorMarker) {
            this((i & 1) != 0 ? null : str, (i & 2) != 0 ? null : bitmap, (i & 4) != 0 ? new ArrayList() : arrayList);
        }
    }

    public static final class TextScanResult {
        private Float confidence;
        private Bitmap image;
        private Double latitudeObj;
        private Double longitudeObj;
        private String rawtext;
        private String text;
        private String unprocessResult;

        public TextScanResult() {
            this(null, null, null, null, null, null, null, 127, null);
        }

        public static /* synthetic */ TextScanResult copy$default(TextScanResult textScanResult, String str, Bitmap bitmap, String str2, Float f, String str3, Double d, Double d2, int i, Object obj) {
            if ((i & 1) != 0) {
                str = textScanResult.text;
            }
            if ((i & 2) != 0) {
                bitmap = textScanResult.image;
            }
            if ((i & 4) != 0) {
                str2 = textScanResult.rawtext;
            }
            if ((i & 8) != 0) {
                f = textScanResult.confidence;
            }
            if ((i & 16) != 0) {
                str3 = textScanResult.unprocessResult;
            }
            if ((i & 32) != 0) {
                d = textScanResult.latitudeObj;
            }
            if ((i & 64) != 0) {
                d2 = textScanResult.longitudeObj;
            }
            Double d3 = d;
            Double d4 = d2;
            String str4 = str3;
            String str5 = str2;
            return textScanResult.copy(str, bitmap, str5, f, str4, d3, d4);
        }

        public final String component1() {
            return this.text;
        }

        public final Bitmap component2() {
            return this.image;
        }

        public final String component3() {
            return this.rawtext;
        }

        public final Float component4() {
            return this.confidence;
        }

        public final String component5() {
            return this.unprocessResult;
        }

        public final Double component6() {
            return this.latitudeObj;
        }

        public final Double component7() {
            return this.longitudeObj;
        }

        public final TextScanResult copy(String str, Bitmap bitmap, String str2, Float f, String str3, Double d, Double d2) {
            return new TextScanResult(str, bitmap, str2, f, str3, d, d2);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof TextScanResult)) {
                return false;
            }
            TextScanResult textScanResult = (TextScanResult) obj;
            return Intrinsics.areEqual(this.text, textScanResult.text) && Intrinsics.areEqual(this.image, textScanResult.image) && Intrinsics.areEqual(this.rawtext, textScanResult.rawtext) && Intrinsics.areEqual((Object) this.confidence, (Object) textScanResult.confidence) && Intrinsics.areEqual(this.unprocessResult, textScanResult.unprocessResult) && Intrinsics.areEqual(this.latitudeObj, textScanResult.latitudeObj) && Intrinsics.areEqual(this.longitudeObj, textScanResult.longitudeObj);
        }

        public final Float getConfidence() {
            return this.confidence;
        }

        public final Bitmap getImage() {
            return this.image;
        }

        public final Double getLatitudeObj() {
            return this.latitudeObj;
        }

        public final Double getLongitudeObj() {
            return this.longitudeObj;
        }

        public final String getRawtext() {
            return this.rawtext;
        }

        public final String getText() {
            return this.text;
        }

        public final String getUnprocessResult() {
            return this.unprocessResult;
        }

        public int hashCode() {
            String str = this.text;
            int iHashCode = (str == null ? 0 : str.hashCode()) * 31;
            Bitmap bitmap = this.image;
            int iHashCode2 = (iHashCode + (bitmap == null ? 0 : bitmap.hashCode())) * 31;
            String str2 = this.rawtext;
            int iHashCode3 = (iHashCode2 + (str2 == null ? 0 : str2.hashCode())) * 31;
            Float f = this.confidence;
            int iHashCode4 = (iHashCode3 + (f == null ? 0 : f.hashCode())) * 31;
            String str3 = this.unprocessResult;
            int iHashCode5 = (iHashCode4 + (str3 == null ? 0 : str3.hashCode())) * 31;
            Double d = this.latitudeObj;
            int iHashCode6 = (iHashCode5 + (d == null ? 0 : d.hashCode())) * 31;
            Double d2 = this.longitudeObj;
            return iHashCode6 + (d2 != null ? d2.hashCode() : 0);
        }

        public final void setConfidence(Float f) {
            this.confidence = f;
        }

        public final void setImage(Bitmap bitmap) {
            this.image = bitmap;
        }

        public final void setLatitudeObj(Double d) {
            this.latitudeObj = d;
        }

        public final void setLongitudeObj(Double d) {
            this.longitudeObj = d;
        }

        public final void setRawtext(String str) {
            this.rawtext = str;
        }

        public final void setText(String str) {
            this.text = str;
        }

        public final void setUnprocessResult(String str) {
            this.unprocessResult = str;
        }

        public String toString() {
            return "TextScanResult(text=" + this.text + ", image=" + this.image + ", rawtext=" + this.rawtext + ", confidence=" + this.confidence + ", unprocessResult=" + this.unprocessResult + ", latitudeObj=" + this.latitudeObj + ", longitudeObj=" + this.longitudeObj + ')';
        }

        public TextScanResult(String str, Bitmap bitmap, String str2, Float f, String str3, Double d, Double d2) {
            this.text = str;
            this.image = bitmap;
            this.rawtext = str2;
            this.confidence = f;
            this.unprocessResult = str3;
            this.latitudeObj = d;
            this.longitudeObj = d2;
        }

        public /* synthetic */ TextScanResult(String str, Bitmap bitmap, String str2, Float f, String str3, Double d, Double d2, int i, DefaultConstructorMarker defaultConstructorMarker) {
            this((i & 1) != 0 ? null : str, (i & 2) != 0 ? null : bitmap, (i & 4) != 0 ? null : str2, (i & 8) != 0 ? null : f, (i & 16) != 0 ? null : str3, (i & 32) != 0 ? null : d, (i & 64) != 0 ? null : d2);
        }
    }

    public static final class VinPlateFullScanResult {
        private final String axle1;
        private final String axle2;
        private final String axle3;
        private final String axle4;
        private final String axle5;
        private final String gcw;
        private final String gvm;
        private final ArrayList<String> suggestedTypResults;
        private final ArrayList<String> suggestedVinResults;
        private final String typ;
        private final String vin;

        public VinPlateFullScanResult(String typ, String vin, String gvm, String str, String str2, String str3, String str4, String str5, String str6, ArrayList<String> suggestedTypResults, ArrayList<String> suggestedVinResults) {
            Intrinsics.checkNotNullParameter(typ, "typ");
            Intrinsics.checkNotNullParameter(vin, "vin");
            Intrinsics.checkNotNullParameter(gvm, "gvm");
            Intrinsics.checkNotNullParameter(suggestedTypResults, "suggestedTypResults");
            Intrinsics.checkNotNullParameter(suggestedVinResults, "suggestedVinResults");
            this.typ = typ;
            this.vin = vin;
            this.gvm = gvm;
            this.gcw = str;
            this.axle1 = str2;
            this.axle2 = str3;
            this.axle3 = str4;
            this.axle4 = str5;
            this.axle5 = str6;
            this.suggestedTypResults = suggestedTypResults;
            this.suggestedVinResults = suggestedVinResults;
        }

        /* JADX WARN: Multi-variable type inference failed */
        public static /* synthetic */ VinPlateFullScanResult copy$default(VinPlateFullScanResult vinPlateFullScanResult, String str, String str2, String str3, String str4, String str5, String str6, String str7, String str8, String str9, ArrayList arrayList, ArrayList arrayList2, int i, Object obj) {
            if ((i & 1) != 0) {
                str = vinPlateFullScanResult.typ;
            }
            if ((i & 2) != 0) {
                str2 = vinPlateFullScanResult.vin;
            }
            if ((i & 4) != 0) {
                str3 = vinPlateFullScanResult.gvm;
            }
            if ((i & 8) != 0) {
                str4 = vinPlateFullScanResult.gcw;
            }
            if ((i & 16) != 0) {
                str5 = vinPlateFullScanResult.axle1;
            }
            if ((i & 32) != 0) {
                str6 = vinPlateFullScanResult.axle2;
            }
            if ((i & 64) != 0) {
                str7 = vinPlateFullScanResult.axle3;
            }
            if ((i & 128) != 0) {
                str8 = vinPlateFullScanResult.axle4;
            }
            if ((i & 256) != 0) {
                str9 = vinPlateFullScanResult.axle5;
            }
            if ((i & 512) != 0) {
                arrayList = vinPlateFullScanResult.suggestedTypResults;
            }
            if ((i & 1024) != 0) {
                arrayList2 = vinPlateFullScanResult.suggestedVinResults;
            }
            ArrayList arrayList3 = arrayList;
            ArrayList arrayList4 = arrayList2;
            String str10 = str8;
            String str11 = str9;
            String str12 = str6;
            String str13 = str7;
            String str14 = str5;
            String str15 = str3;
            return vinPlateFullScanResult.copy(str, str2, str15, str4, str14, str12, str13, str10, str11, arrayList3, arrayList4);
        }

        public final String component1() {
            return this.typ;
        }

        public final ArrayList<String> component10() {
            return this.suggestedTypResults;
        }

        public final ArrayList<String> component11() {
            return this.suggestedVinResults;
        }

        public final String component2() {
            return this.vin;
        }

        public final String component3() {
            return this.gvm;
        }

        public final String component4() {
            return this.gcw;
        }

        public final String component5() {
            return this.axle1;
        }

        public final String component6() {
            return this.axle2;
        }

        public final String component7() {
            return this.axle3;
        }

        public final String component8() {
            return this.axle4;
        }

        public final String component9() {
            return this.axle5;
        }

        public final VinPlateFullScanResult copy(String typ, String vin, String gvm, String str, String str2, String str3, String str4, String str5, String str6, ArrayList<String> suggestedTypResults, ArrayList<String> suggestedVinResults) {
            Intrinsics.checkNotNullParameter(typ, "typ");
            Intrinsics.checkNotNullParameter(vin, "vin");
            Intrinsics.checkNotNullParameter(gvm, "gvm");
            Intrinsics.checkNotNullParameter(suggestedTypResults, "suggestedTypResults");
            Intrinsics.checkNotNullParameter(suggestedVinResults, "suggestedVinResults");
            return new VinPlateFullScanResult(typ, vin, gvm, str, str2, str3, str4, str5, str6, suggestedTypResults, suggestedVinResults);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof VinPlateFullScanResult)) {
                return false;
            }
            VinPlateFullScanResult vinPlateFullScanResult = (VinPlateFullScanResult) obj;
            return Intrinsics.areEqual(this.typ, vinPlateFullScanResult.typ) && Intrinsics.areEqual(this.vin, vinPlateFullScanResult.vin) && Intrinsics.areEqual(this.gvm, vinPlateFullScanResult.gvm) && Intrinsics.areEqual(this.gcw, vinPlateFullScanResult.gcw) && Intrinsics.areEqual(this.axle1, vinPlateFullScanResult.axle1) && Intrinsics.areEqual(this.axle2, vinPlateFullScanResult.axle2) && Intrinsics.areEqual(this.axle3, vinPlateFullScanResult.axle3) && Intrinsics.areEqual(this.axle4, vinPlateFullScanResult.axle4) && Intrinsics.areEqual(this.axle5, vinPlateFullScanResult.axle5) && Intrinsics.areEqual(this.suggestedTypResults, vinPlateFullScanResult.suggestedTypResults) && Intrinsics.areEqual(this.suggestedVinResults, vinPlateFullScanResult.suggestedVinResults);
        }

        public final String getAxle1() {
            return this.axle1;
        }

        public final String getAxle2() {
            return this.axle2;
        }

        public final String getAxle3() {
            return this.axle3;
        }

        public final String getAxle4() {
            return this.axle4;
        }

        public final String getAxle5() {
            return this.axle5;
        }

        public final String getGcw() {
            return this.gcw;
        }

        public final String getGvm() {
            return this.gvm;
        }

        public final ArrayList<String> getSuggestedTypResults() {
            return this.suggestedTypResults;
        }

        public final ArrayList<String> getSuggestedVinResults() {
            return this.suggestedVinResults;
        }

        public final String getTyp() {
            return this.typ;
        }

        public final String getVin() {
            return this.vin;
        }

        public int hashCode() {
            int iHashCode = (this.gvm.hashCode() + ((this.vin.hashCode() + (this.typ.hashCode() * 31)) * 31)) * 31;
            String str = this.gcw;
            int iHashCode2 = (iHashCode + (str == null ? 0 : str.hashCode())) * 31;
            String str2 = this.axle1;
            int iHashCode3 = (iHashCode2 + (str2 == null ? 0 : str2.hashCode())) * 31;
            String str3 = this.axle2;
            int iHashCode4 = (iHashCode3 + (str3 == null ? 0 : str3.hashCode())) * 31;
            String str4 = this.axle3;
            int iHashCode5 = (iHashCode4 + (str4 == null ? 0 : str4.hashCode())) * 31;
            String str5 = this.axle4;
            int iHashCode6 = (iHashCode5 + (str5 == null ? 0 : str5.hashCode())) * 31;
            String str6 = this.axle5;
            return this.suggestedVinResults.hashCode() + ((this.suggestedTypResults.hashCode() + ((iHashCode6 + (str6 != null ? str6.hashCode() : 0)) * 31)) * 31);
        }

        public String toString() {
            return "VinPlateFullScanResult(typ=" + this.typ + ", vin=" + this.vin + ", gvm=" + this.gvm + ", gcw=" + this.gcw + ", axle1=" + this.axle1 + ", axle2=" + this.axle2 + ", axle3=" + this.axle3 + ", axle4=" + this.axle4 + ", axle5=" + this.axle5 + ", suggestedTypResults=" + this.suggestedTypResults + ", suggestedVinResults=" + this.suggestedVinResults + ')';
        }
    }

    public static final class VinPlateFullStatusResult {
        private final boolean axle1;
        private final boolean axle2;
        private final boolean axle3;
        private final boolean axle4;
        private final boolean axle5;
        private final boolean gcw;
        private final boolean gvm;
        private final boolean typ;
        private final boolean vin;

        public VinPlateFullStatusResult(boolean z, boolean z2, boolean z3, boolean z4, boolean z5, boolean z6, boolean z7, boolean z8, boolean z9) {
            this.typ = z;
            this.vin = z2;
            this.gvm = z3;
            this.gcw = z4;
            this.axle1 = z5;
            this.axle2 = z6;
            this.axle3 = z7;
            this.axle4 = z8;
            this.axle5 = z9;
        }

        public static /* synthetic */ VinPlateFullStatusResult copy$default(VinPlateFullStatusResult vinPlateFullStatusResult, boolean z, boolean z2, boolean z3, boolean z4, boolean z5, boolean z6, boolean z7, boolean z8, boolean z9, int i, Object obj) {
            if ((i & 1) != 0) {
                z = vinPlateFullStatusResult.typ;
            }
            if ((i & 2) != 0) {
                z2 = vinPlateFullStatusResult.vin;
            }
            if ((i & 4) != 0) {
                z3 = vinPlateFullStatusResult.gvm;
            }
            if ((i & 8) != 0) {
                z4 = vinPlateFullStatusResult.gcw;
            }
            if ((i & 16) != 0) {
                z5 = vinPlateFullStatusResult.axle1;
            }
            if ((i & 32) != 0) {
                z6 = vinPlateFullStatusResult.axle2;
            }
            if ((i & 64) != 0) {
                z7 = vinPlateFullStatusResult.axle3;
            }
            if ((i & 128) != 0) {
                z8 = vinPlateFullStatusResult.axle4;
            }
            if ((i & 256) != 0) {
                z9 = vinPlateFullStatusResult.axle5;
            }
            boolean z10 = z8;
            boolean z11 = z9;
            boolean z12 = z6;
            boolean z13 = z7;
            boolean z14 = z5;
            boolean z15 = z3;
            return vinPlateFullStatusResult.copy(z, z2, z15, z4, z14, z12, z13, z10, z11);
        }

        public final boolean component1() {
            return this.typ;
        }

        public final boolean component2() {
            return this.vin;
        }

        public final boolean component3() {
            return this.gvm;
        }

        public final boolean component4() {
            return this.gcw;
        }

        public final boolean component5() {
            return this.axle1;
        }

        public final boolean component6() {
            return this.axle2;
        }

        public final boolean component7() {
            return this.axle3;
        }

        public final boolean component8() {
            return this.axle4;
        }

        public final boolean component9() {
            return this.axle5;
        }

        public final VinPlateFullStatusResult copy(boolean z, boolean z2, boolean z3, boolean z4, boolean z5, boolean z6, boolean z7, boolean z8, boolean z9) {
            return new VinPlateFullStatusResult(z, z2, z3, z4, z5, z6, z7, z8, z9);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof VinPlateFullStatusResult)) {
                return false;
            }
            VinPlateFullStatusResult vinPlateFullStatusResult = (VinPlateFullStatusResult) obj;
            return this.typ == vinPlateFullStatusResult.typ && this.vin == vinPlateFullStatusResult.vin && this.gvm == vinPlateFullStatusResult.gvm && this.gcw == vinPlateFullStatusResult.gcw && this.axle1 == vinPlateFullStatusResult.axle1 && this.axle2 == vinPlateFullStatusResult.axle2 && this.axle3 == vinPlateFullStatusResult.axle3 && this.axle4 == vinPlateFullStatusResult.axle4 && this.axle5 == vinPlateFullStatusResult.axle5;
        }

        public final boolean getAxle1() {
            return this.axle1;
        }

        public final boolean getAxle2() {
            return this.axle2;
        }

        public final boolean getAxle3() {
            return this.axle3;
        }

        public final boolean getAxle4() {
            return this.axle4;
        }

        public final boolean getAxle5() {
            return this.axle5;
        }

        public final boolean getGcw() {
            return this.gcw;
        }

        public final boolean getGvm() {
            return this.gvm;
        }

        public final boolean getTyp() {
            return this.typ;
        }

        public final boolean getVin() {
            return this.vin;
        }

        public int hashCode() {
            return Boolean.hashCode(this.axle5) + a.a(this.axle4, a.a(this.axle3, a.a(this.axle2, a.a(this.axle1, a.a(this.gcw, a.a(this.gvm, a.a(this.vin, Boolean.hashCode(this.typ) * 31, 31), 31), 31), 31), 31), 31), 31);
        }

        public String toString() {
            return "VinPlateFullStatusResult(typ=" + this.typ + ", vin=" + this.vin + ", gvm=" + this.gvm + ", gcw=" + this.gcw + ", axle1=" + this.axle1 + ", axle2=" + this.axle2 + ", axle3=" + this.axle3 + ", axle4=" + this.axle4 + ", axle5=" + this.axle5 + ')';
        }
    }

    public static final class VinStickerFullScanResult {
        private final String axleOneByTwo;
        private final String axleThreeByFour;
        private final String category;
        private final String date;
        private final String gcw;
        private final ArrayList<String> suggestedTypResults;
        private final ArrayList<String> suggestedVinResults;
        private final String type;
        private final String vin;

        public VinStickerFullScanResult(String vin, String date, String category, String str, String str2, String str3, String str4, ArrayList<String> suggestedTypResults, ArrayList<String> suggestedVinResults) {
            Intrinsics.checkNotNullParameter(vin, "vin");
            Intrinsics.checkNotNullParameter(date, "date");
            Intrinsics.checkNotNullParameter(category, "category");
            Intrinsics.checkNotNullParameter(suggestedTypResults, "suggestedTypResults");
            Intrinsics.checkNotNullParameter(suggestedVinResults, "suggestedVinResults");
            this.vin = vin;
            this.date = date;
            this.category = category;
            this.gcw = str;
            this.axleOneByTwo = str2;
            this.axleThreeByFour = str3;
            this.type = str4;
            this.suggestedTypResults = suggestedTypResults;
            this.suggestedVinResults = suggestedVinResults;
        }

        /* JADX WARN: Multi-variable type inference failed */
        public static /* synthetic */ VinStickerFullScanResult copy$default(VinStickerFullScanResult vinStickerFullScanResult, String str, String str2, String str3, String str4, String str5, String str6, String str7, ArrayList arrayList, ArrayList arrayList2, int i, Object obj) {
            if ((i & 1) != 0) {
                str = vinStickerFullScanResult.vin;
            }
            if ((i & 2) != 0) {
                str2 = vinStickerFullScanResult.date;
            }
            if ((i & 4) != 0) {
                str3 = vinStickerFullScanResult.category;
            }
            if ((i & 8) != 0) {
                str4 = vinStickerFullScanResult.gcw;
            }
            if ((i & 16) != 0) {
                str5 = vinStickerFullScanResult.axleOneByTwo;
            }
            if ((i & 32) != 0) {
                str6 = vinStickerFullScanResult.axleThreeByFour;
            }
            if ((i & 64) != 0) {
                str7 = vinStickerFullScanResult.type;
            }
            if ((i & 128) != 0) {
                arrayList = vinStickerFullScanResult.suggestedTypResults;
            }
            if ((i & 256) != 0) {
                arrayList2 = vinStickerFullScanResult.suggestedVinResults;
            }
            ArrayList arrayList3 = arrayList;
            ArrayList arrayList4 = arrayList2;
            String str8 = str6;
            String str9 = str7;
            String str10 = str5;
            String str11 = str3;
            return vinStickerFullScanResult.copy(str, str2, str11, str4, str10, str8, str9, arrayList3, arrayList4);
        }

        public final String component1() {
            return this.vin;
        }

        public final String component2() {
            return this.date;
        }

        public final String component3() {
            return this.category;
        }

        public final String component4() {
            return this.gcw;
        }

        public final String component5() {
            return this.axleOneByTwo;
        }

        public final String component6() {
            return this.axleThreeByFour;
        }

        public final String component7() {
            return this.type;
        }

        public final ArrayList<String> component8() {
            return this.suggestedTypResults;
        }

        public final ArrayList<String> component9() {
            return this.suggestedVinResults;
        }

        public final VinStickerFullScanResult copy(String vin, String date, String category, String str, String str2, String str3, String str4, ArrayList<String> suggestedTypResults, ArrayList<String> suggestedVinResults) {
            Intrinsics.checkNotNullParameter(vin, "vin");
            Intrinsics.checkNotNullParameter(date, "date");
            Intrinsics.checkNotNullParameter(category, "category");
            Intrinsics.checkNotNullParameter(suggestedTypResults, "suggestedTypResults");
            Intrinsics.checkNotNullParameter(suggestedVinResults, "suggestedVinResults");
            return new VinStickerFullScanResult(vin, date, category, str, str2, str3, str4, suggestedTypResults, suggestedVinResults);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof VinStickerFullScanResult)) {
                return false;
            }
            VinStickerFullScanResult vinStickerFullScanResult = (VinStickerFullScanResult) obj;
            return Intrinsics.areEqual(this.vin, vinStickerFullScanResult.vin) && Intrinsics.areEqual(this.date, vinStickerFullScanResult.date) && Intrinsics.areEqual(this.category, vinStickerFullScanResult.category) && Intrinsics.areEqual(this.gcw, vinStickerFullScanResult.gcw) && Intrinsics.areEqual(this.axleOneByTwo, vinStickerFullScanResult.axleOneByTwo) && Intrinsics.areEqual(this.axleThreeByFour, vinStickerFullScanResult.axleThreeByFour) && Intrinsics.areEqual(this.type, vinStickerFullScanResult.type) && Intrinsics.areEqual(this.suggestedTypResults, vinStickerFullScanResult.suggestedTypResults) && Intrinsics.areEqual(this.suggestedVinResults, vinStickerFullScanResult.suggestedVinResults);
        }

        public final String getAxleOneByTwo() {
            return this.axleOneByTwo;
        }

        public final String getAxleThreeByFour() {
            return this.axleThreeByFour;
        }

        public final String getCategory() {
            return this.category;
        }

        public final String getDate() {
            return this.date;
        }

        public final String getGcw() {
            return this.gcw;
        }

        public final ArrayList<String> getSuggestedTypResults() {
            return this.suggestedTypResults;
        }

        public final ArrayList<String> getSuggestedVinResults() {
            return this.suggestedVinResults;
        }

        public final String getType() {
            return this.type;
        }

        public final String getVin() {
            return this.vin;
        }

        public int hashCode() {
            int iHashCode = (this.category.hashCode() + ((this.date.hashCode() + (this.vin.hashCode() * 31)) * 31)) * 31;
            String str = this.gcw;
            int iHashCode2 = (iHashCode + (str == null ? 0 : str.hashCode())) * 31;
            String str2 = this.axleOneByTwo;
            int iHashCode3 = (iHashCode2 + (str2 == null ? 0 : str2.hashCode())) * 31;
            String str3 = this.axleThreeByFour;
            int iHashCode4 = (iHashCode3 + (str3 == null ? 0 : str3.hashCode())) * 31;
            String str4 = this.type;
            return this.suggestedVinResults.hashCode() + ((this.suggestedTypResults.hashCode() + ((iHashCode4 + (str4 != null ? str4.hashCode() : 0)) * 31)) * 31);
        }

        public String toString() {
            return "VinStickerFullScanResult(vin=" + this.vin + ", date=" + this.date + ", category=" + this.category + ", gcw=" + this.gcw + ", axleOneByTwo=" + this.axleOneByTwo + ", axleThreeByFour=" + this.axleThreeByFour + ", type=" + this.type + ", suggestedTypResults=" + this.suggestedTypResults + ", suggestedVinResults=" + this.suggestedVinResults + ')';
        }
    }

    public static final class VinStickerFullStatusResult {
        private final boolean axleOneByTwo;
        private final boolean axleThreeByFour;
        private final boolean category;
        private final boolean date;
        private final boolean gcw;
        private final boolean type;
        private final boolean vin;

        public VinStickerFullStatusResult(boolean z, boolean z2, boolean z3, boolean z4, boolean z5, boolean z6, boolean z7) {
            this.vin = z;
            this.date = z2;
            this.category = z3;
            this.gcw = z4;
            this.axleOneByTwo = z5;
            this.axleThreeByFour = z6;
            this.type = z7;
        }

        public static /* synthetic */ VinStickerFullStatusResult copy$default(VinStickerFullStatusResult vinStickerFullStatusResult, boolean z, boolean z2, boolean z3, boolean z4, boolean z5, boolean z6, boolean z7, int i, Object obj) {
            if ((i & 1) != 0) {
                z = vinStickerFullStatusResult.vin;
            }
            if ((i & 2) != 0) {
                z2 = vinStickerFullStatusResult.date;
            }
            if ((i & 4) != 0) {
                z3 = vinStickerFullStatusResult.category;
            }
            if ((i & 8) != 0) {
                z4 = vinStickerFullStatusResult.gcw;
            }
            if ((i & 16) != 0) {
                z5 = vinStickerFullStatusResult.axleOneByTwo;
            }
            if ((i & 32) != 0) {
                z6 = vinStickerFullStatusResult.axleThreeByFour;
            }
            if ((i & 64) != 0) {
                z7 = vinStickerFullStatusResult.type;
            }
            boolean z8 = z6;
            boolean z9 = z7;
            boolean z10 = z5;
            boolean z11 = z3;
            return vinStickerFullStatusResult.copy(z, z2, z11, z4, z10, z8, z9);
        }

        public final boolean component1() {
            return this.vin;
        }

        public final boolean component2() {
            return this.date;
        }

        public final boolean component3() {
            return this.category;
        }

        public final boolean component4() {
            return this.gcw;
        }

        public final boolean component5() {
            return this.axleOneByTwo;
        }

        public final boolean component6() {
            return this.axleThreeByFour;
        }

        public final boolean component7() {
            return this.type;
        }

        public final VinStickerFullStatusResult copy(boolean z, boolean z2, boolean z3, boolean z4, boolean z5, boolean z6, boolean z7) {
            return new VinStickerFullStatusResult(z, z2, z3, z4, z5, z6, z7);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof VinStickerFullStatusResult)) {
                return false;
            }
            VinStickerFullStatusResult vinStickerFullStatusResult = (VinStickerFullStatusResult) obj;
            return this.vin == vinStickerFullStatusResult.vin && this.date == vinStickerFullStatusResult.date && this.category == vinStickerFullStatusResult.category && this.gcw == vinStickerFullStatusResult.gcw && this.axleOneByTwo == vinStickerFullStatusResult.axleOneByTwo && this.axleThreeByFour == vinStickerFullStatusResult.axleThreeByFour && this.type == vinStickerFullStatusResult.type;
        }

        public final boolean getAxleOneByTwo() {
            return this.axleOneByTwo;
        }

        public final boolean getAxleThreeByFour() {
            return this.axleThreeByFour;
        }

        public final boolean getCategory() {
            return this.category;
        }

        public final boolean getDate() {
            return this.date;
        }

        public final boolean getGcw() {
            return this.gcw;
        }

        public final boolean getType() {
            return this.type;
        }

        public final boolean getVin() {
            return this.vin;
        }

        public int hashCode() {
            return Boolean.hashCode(this.type) + a.a(this.axleThreeByFour, a.a(this.axleOneByTwo, a.a(this.gcw, a.a(this.category, a.a(this.date, Boolean.hashCode(this.vin) * 31, 31), 31), 31), 31), 31);
        }

        public String toString() {
            return "VinStickerFullStatusResult(vin=" + this.vin + ", date=" + this.date + ", category=" + this.category + ", gcw=" + this.gcw + ", axleOneByTwo=" + this.axleOneByTwo + ", axleThreeByFour=" + this.axleThreeByFour + ", type=" + this.type + ')';
        }
    }

    public static final class WebServiceScanResult {
        private Bitmap image;
        private String text;

        /* JADX WARN: Multi-variable type inference failed */
        public WebServiceScanResult() {
            this(null, 0 == true ? 1 : 0, 3, 0 == true ? 1 : 0);
        }

        public static /* synthetic */ WebServiceScanResult copy$default(WebServiceScanResult webServiceScanResult, String str, Bitmap bitmap, int i, Object obj) {
            if ((i & 1) != 0) {
                str = webServiceScanResult.text;
            }
            if ((i & 2) != 0) {
                bitmap = webServiceScanResult.image;
            }
            return webServiceScanResult.copy(str, bitmap);
        }

        public final String component1() {
            return this.text;
        }

        public final Bitmap component2() {
            return this.image;
        }

        public final WebServiceScanResult copy(String str, Bitmap bitmap) {
            return new WebServiceScanResult(str, bitmap);
        }

        public boolean equals(Object obj) {
            if (this == obj) {
                return true;
            }
            if (!(obj instanceof WebServiceScanResult)) {
                return false;
            }
            WebServiceScanResult webServiceScanResult = (WebServiceScanResult) obj;
            return Intrinsics.areEqual(this.text, webServiceScanResult.text) && Intrinsics.areEqual(this.image, webServiceScanResult.image);
        }

        public final Bitmap getImage() {
            return this.image;
        }

        public final String getText() {
            return this.text;
        }

        public int hashCode() {
            String str = this.text;
            int iHashCode = (str == null ? 0 : str.hashCode()) * 31;
            Bitmap bitmap = this.image;
            return iHashCode + (bitmap != null ? bitmap.hashCode() : 0);
        }

        public final void setImage(Bitmap bitmap) {
            this.image = bitmap;
        }

        public final void setText(String str) {
            this.text = str;
        }

        public String toString() {
            return "WebServiceScanResult(text=" + this.text + ", image=" + this.image + ')';
        }

        public WebServiceScanResult(String str, Bitmap bitmap) {
            this.text = str;
            this.image = bitmap;
        }

        public /* synthetic */ WebServiceScanResult(String str, Bitmap bitmap, int i, DefaultConstructorMarker defaultConstructorMarker) {
            this((i & 1) != 0 ? null : str, (i & 2) != 0 ? null : bitmap);
        }
    }

    public abstract ScanflowReader bindFlashlightView(View view);

    public abstract ScanflowReader bindSliderView(Slider slider);

    public abstract void captureBatchInventory();

    public abstract void captureToScan();

    public abstract ScanflowReader doValidateLicense();

    public abstract ScanflowReader doValidateLicenseWithRetry();

    public abstract ScanflowReader enableSplitView(boolean z);

    public abstract ScanflowReader enableTouchZoom(boolean z);

    public abstract ScanflowReader performOneTouchClick();

    public abstract ScanflowReader resetOneToManyCodes();

    public abstract ScanflowReader setAutoExposure(boolean z);

    public abstract ScanflowReader setAutoFlashlight(boolean z);

    public abstract ScanflowReader setAutoZoom(boolean z);

    public abstract ScanflowReader setBeepSoundResource(int i);

    public abstract ScanflowReader setCameraResolution(CameraResolutionConfig cameraResolutionConfig);

    public abstract ScanflowReader setEchanceTextCount(int i);

    public abstract ScanflowReader setEnableDataTracking(boolean z);

    public abstract ScanflowReader setEnableLocationTracking(boolean z);

    public abstract ScanflowReader setEnableTireAngleDetection(boolean z);

    public abstract ScanflowReader setEnableTirePreProcessing(boolean z);

    public abstract ScanflowReader setEnhanceTextResult(boolean z);

    public abstract ScanflowReader setIsBatchScanning(boolean z);

    public abstract ScanflowReader setIsContinuousScan(boolean z);

    public abstract ScanflowReader setOnBarcodeScanResultCallback(OnBarcodeScanResultCallback onBarcodeScanResultCallback);

    public abstract ScanflowReader setOnCameraResultCallback(OnCameraResultCallback onCameraResultCallback);

    public abstract ScanflowReader setOnIDCardScanResultCallback(OnIDCardScanResultCallback onIDCardScanResultCallback);

    public abstract ScanflowReader setOnLicenseValidationCallback(OnLicenseValidationCallback onLicenseValidationCallback);

    public abstract ScanflowReader setOnOneTouchCallback(OnOneTouchCallback onOneTouchCallback);

    public abstract ScanflowReader setOnTextComponentScanResultCallback(OnTextComponentScanResultCallback onTextComponentScanResultCallback);

    public abstract ScanflowReader setOnTextComponentVinPlateScanResultCallback(OnTextComponentVinPlateScanResultCallback onTextComponentVinPlateScanResultCallback);

    public abstract ScanflowReader setOnTextComponentVinStickerScanResultCallback(OnTextComponentVinStickerScanResultCallback onTextComponentVinStickerScanResultCallback);

    public abstract ScanflowReader setOnTextScanResultCallback(OnTextScanResultCallback onTextScanResultCallback);

    public abstract ScanflowReader setOnWebServiceScanResultCallback(OnWebServiceScanResultCallback onWebServiceScanResultCallback);

    public abstract ScanflowReader setOneToManyCodes(boolean z);

    public abstract ScanflowReader setOneToManyCodesKeepCurrent(boolean z);

    public abstract ScanflowReader setPlayBeep(boolean z);

    public abstract ScanflowReader setQrBarcodeDetection(boolean z);

    public abstract ScanflowReader setSwitchCategory(String str);

    public abstract ScanflowReader setVibrate(boolean z);

    public abstract ScanflowReader setVinNumberColor(VinNumberColorConfig vinNumberColorConfig);

    public abstract ScanflowReader updateConfidenceValue(float f);
}
