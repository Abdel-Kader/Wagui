package md591579f5b976f4344f660431d7e528b2b;


public class PickerRender
	extends md51558244f76c53b6aeda52c8a337f2c37.PickerRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Wagui.Droid.PickerRender, Wagui.Android", PickerRender.class, __md_methods);
	}


	public PickerRender (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == PickerRender.class)
			mono.android.TypeManager.Activate ("Wagui.Droid.PickerRender, Wagui.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PickerRender (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PickerRender.class)
			mono.android.TypeManager.Activate ("Wagui.Droid.PickerRender, Wagui.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public PickerRender (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PickerRender.class)
			mono.android.TypeManager.Activate ("Wagui.Droid.PickerRender, Wagui.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
